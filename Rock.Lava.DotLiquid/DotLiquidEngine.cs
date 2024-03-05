﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DotLiquid;

namespace Rock.Lava.DotLiquid
{
    /// <summary>
    /// Initialization class for the DotLiquid Templating Engine.
    /// </summary>
    public partial class DotLiquidEngine : LavaEngineBase
    {
        private Guid _engineIdentifier = new Guid( "165E5E74-4923-4E25-B330-A27DB3A59CE7" );

        /// <summary>
        /// The descriptive name of the engine.
        /// </summary>
        public override string EngineName
        {
            get
            {
                return "DotLiquid";
            }
        }

        /// <summary>
        /// The type specifier for the framework.
        /// </summary>
        public override Guid EngineIdentifier
        {
            get
            {
                return _engineIdentifier;
            }
        }

        /// <summary>
        /// Create a new template context containing the specified merge fields.
        /// </summary>
        /// <param name="mergeFields"></param>
        /// <returns></returns>

        protected override ILavaRenderContext OnCreateRenderContext()
        {
            // Create a new DotLiquid Context.
            // Set the flag to rethrow exceptions generated by the DotLiquid framework, so they can be intercepted and handled as Lava errors.
            var dotLiquidContext = new global::DotLiquid.Context( new List<Hash>(), new Hash(), new Hash(), rethrowErrors: true );

            var context = new DotLiquidRenderContext( dotLiquidContext );

            return context;
        }

        /// <summary>
        /// Configure the DotLiquid engine with the specified options.
        /// </summary>
        public override void OnSetConfiguration( LavaEngineConfigurationOptions options )
        {
            // DotLiquid uses a RubyDateFormat by default,
            // but since we aren't using Ruby, we want to disable that
            Liquid.UseRubyDateFormat = false;

            /* 2020-05-20 MDP (actually this comment was here a long time ago)
                NOTE: This means that all the built in template filters,
                and the RockFilters, will use CSharpNamingConvention.

                For example the dotliquid documentation says to do this for formatting dates: 
                {{ some_date_value | date:"MMM dd, yyyy" }}

                However, if CSharpNamingConvention is enabled, it needs to be: 
                {{ some_date_value | Date:"MMM dd, yyyy" }}
            */

            Template.NamingConvention = new global::DotLiquid.NamingConventions.CSharpNamingConvention();

            if ( options.FileSystem == null )
            {
                options.FileSystem = new DotLiquidFileSystem( new LavaNullFileSystem() );
            }

            Template.FileSystem = new DotLiquidFileSystem( options.FileSystem );

            Template.RegisterSafeType( typeof( Enum ), o => o.ToString() );
            Template.RegisterSafeType( typeof( DBNull ), o => null );

            // Register all Types that implement LavaDataDictionary interfaces as safe to render.
            RegisterSafeType( typeof( ILavaDataDictionary ) );
            RegisterSafeType( typeof( ILavaDataDictionarySource ) );

            // Register all Types that are decorated with the LavaType custom attribute.
            RegisterLavaTypesAsSafeTypes();

            RegisterValueTypeTransformers();
        }

        private void RegisterValueTypeTransformers()
        {
            // Register transformers to unbox Lava library proxy objects.
            Template.RegisterValueTypeTransformer( typeof( DotLiquidLavaDataDictionaryProxy ),
                ( value ) =>
                {
                    return ( ( ILiquidFrameworkDataObjectProxy ) value ).GetProxiedDataObject();
                } );
        }

        private void RegisterLavaTypesAsSafeTypes()
        {
            // Register Types that use the LavaTypeAttribute, because it is not recognized by DotLiquid as safe to render.
            var assemblyDefinition = typeof( LavaTypeAttribute ).Assembly.GetName().Name;

            var errors = string.Empty;

            // Get the list of assemblies to search.
            // We are only interested in those that hold a reference to the assembly that defines the LavaTypeAttribute,
            // so we can exclude system assemblies.
            var candidateAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where( x => !x.GlobalAssemblyCache
                    && !x.FullName.StartsWith( "System." )
                    && !x.FullName.StartsWith( "Microsoft." ) )
                .ToList();

            var searchAssemblies = candidateAssemblies.Where( x => x.GetName().Name == assemblyDefinition
                || x.GetReferencedAssemblies().Any( a => a.Name == assemblyDefinition ) )
                .ToList();

            foreach ( var assembly in searchAssemblies )
            {
                var registeringTypeName = "(none)";

                try
                {
                    foreach ( var type in assembly.GetTypes() )
                    {
                        registeringTypeName = type.Name;

                        var lavaInfo = LavaDataHelper.GetLavaTypeInfo( type );

                        if ( lavaInfo.HasLavaTypeAttribute )
                        {
                            RegisterSafeType( type, lavaInfo.VisiblePropertyNames );
                        }
                    }
                }
                catch ( Exception ex )
                {
                    errors += $"\n[{ assembly.FullName }:{ registeringTypeName }] { ex.Message }";
                }
            }

            if ( !string.IsNullOrWhiteSpace( errors ) )
            {
                throw new LavaException( "Lava Engine Initialization Error. The following Lava Types could not be registered:" + errors );
            }
        }

        /// <summary>
        /// Register the filters implemented by the provided System.Type entries so they can be used to resolve templates.
        /// </summary>
        /// <param name="implementingType"></param>
        protected override void OnRegisterFilters( Type implementingType )
        {
            var methodsGroupedByName = implementingType.GetMethods( BindingFlags.Public | BindingFlags.Static ).AsQueryable().GroupBy( k => k.Name, v => v );

            foreach ( var methodGroup in methodsGroupedByName )
            {
                var filterName = methodGroup.Key;
                var filterMethodInfos = methodGroup.OrderBy( m => m.GetParameters().Length ).ToList();

                // Define the DotLiquid-compatible function that will wrap the Lava filter.
                // When the wrapper function is executed by DotLiquid, it performs some necessary pre-processing before executing the Lava filter.
                Func<Context, List<object>, object> filterFunctionWrapper = ( Context context, List<object> args ) =>
                {
                    // Get the filter method that best matches the provided argument list.
                    MethodInfo filterMethodInfo = null;

                    if ( filterMethodInfos.Count == 1 )
                    {
                        filterMethodInfo = filterMethodInfos.First();
                    }
                    else
                    {
                        // Find the method that best matches the provided list of arguments.                                
                        filterMethodInfo = GetMatchedFilterFunction( filterMethodInfos, args.Count );
                    }

                    var parameterInfos = filterMethodInfo.GetParameters();

                    GetLavaFilterCompatibleArguments( filterName, args, parameterInfos, context );

                    // Execute the static filter function and return the result.
                    var result = filterMethodInfo.Invoke( null, args.ToArray() );

                    return result;
                };

                // Register the set of filters for each method name.
                Strainer.RegisterFilter( methodGroup.Key, filterFunctionWrapper );
            }
        }

        /// <summary>
        /// Register the filters implemented by the provided System.Type entries so they can be used to resolve templates.
        /// </summary>
        /// <param name="implementingType"></param>
        /// <param name="filterName"></param>
        protected override void OnRegisterFilter( MethodInfo filterMethodInfo, string filterName )
        {
            // Define the DotLiquid-compatible function that will wrap the Lava filter.
            // When the wrapper function is executed by DotLiquid, it performs some necessary pre-processing before executing the Lava filter.
            Func<Context, List<object>, object> filterFunctionWrapper = ( Context context, List<object> args ) =>
            {
                var parameterInfos = filterMethodInfo.GetParameters();

                filterName = filterName ?? filterMethodInfo.Name;

                GetLavaFilterCompatibleArguments( filterName, args, parameterInfos, context );

                // Execute the static filter function and return the result.
                var result = filterMethodInfo.Invoke( null, args.ToArray() );

                return result;
            };

            // Register the filter with DotLiquid.
            Strainer.RegisterFilter( filterName, filterFunctionWrapper );
        }

        /// <summary>
        /// Translate a set of DotLiquid filter arguments to a set of arguments that are compatible with a Lava filter.
        /// </summary>
        private void GetLavaFilterCompatibleArguments( string filterName, List<object> args, ParameterInfo[] lavaFilterFunctionParams, Context dotLiquidContext )
        {
            // Unwrap proxy objects.
            for ( int i = 0; i < args.Count; i++ )
            {
                if ( args[i] is ILiquidFrameworkDataObjectProxy proxy )
                {
                    args[i] = proxy.GetProxiedDataObject();
                }

                if ( args[i] is DropProxy )
                {
                    args[i] = ( ( DropProxy ) args[i] ).ConvertToValueType();
                }
            }

            // Inject the render context if it is requested.
            if ( lavaFilterFunctionParams.Length > 0 && lavaFilterFunctionParams[0].ParameterType == typeof( ILavaRenderContext ) )
            {
                var renderContext = new DotLiquidRenderContext( dotLiquidContext );

                InitializeRenderContext( renderContext );

                args.Insert( 0, renderContext );
            }

            // Add in any missing parameters with the default values defined for the filter method.
            if ( lavaFilterFunctionParams.Length > args.Count )
            {
                for ( int i = args.Count; i < lavaFilterFunctionParams.Length; ++i )
                {
                    if ( ( lavaFilterFunctionParams[i].Attributes & ParameterAttributes.HasDefault ) != ParameterAttributes.HasDefault )
                    {
                        throw new LavaException( "Error - Filter '{0}' does not have a default value for '{1}' and no value was supplied", filterName, lavaFilterFunctionParams[i].Name );
                    }
                    args.Add( lavaFilterFunctionParams[i].DefaultValue );
                }
            }
        }

        /// <summary>
        /// Get the filter method that best matches the supplied argument list.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="suppliedArgsCount"></param>
        /// <returns></returns>
        private MethodInfo GetMatchedFilterFunction( List<MethodInfo> candidateMethodInfoList, int suppliedArgsCount )
        {
            // Subtract the mandatory input object from the count of supplied filter arguments.
            if ( suppliedArgsCount > 0 )
            {
                suppliedArgsCount--;
            }

            foreach ( var methodInfo in candidateMethodInfoList )
            {
                bool isMatch = true;

                var parameterInfos = methodInfo.GetParameters();

                // Remove the input object that the filter is being applied to and the optional Lava context parameter from the count of required user-supplied arguments.
                var functionArgumentOffset = 1;

                var filterArgumentCount = parameterInfos.Length - 1;

                // If the filter accepts a context, it must be the first argument.
                if ( filterArgumentCount > 0 && parameterInfos[0].ParameterType == typeof( ILavaRenderContext ) )
                {
                    filterArgumentCount--;
                    functionArgumentOffset++;
                }

                if ( filterArgumentCount < suppliedArgsCount )
                {
                    continue;
                }
                else if ( filterArgumentCount == suppliedArgsCount )
                {
                    return methodInfo;
                }
                else
                {
                    // Number of filter arguments exceeds supplied arguments, so check if the additional parameters have default values.
                    for ( int i = suppliedArgsCount + functionArgumentOffset - 1; i < filterArgumentCount + functionArgumentOffset; i++ )
                    {
                        if ( ( parameterInfos[i].Attributes & ParameterAttributes.HasDefault ) != ParameterAttributes.HasDefault )
                        {
                            // No match
                            isMatch = false;
                            break;
                        }
                    }

                    if ( isMatch )
                    {
                        return methodInfo;
                    }
                }

            }

            // If an exact match could not be found, take the function with the most parameters and try to fill in the remainder with default values.
            return candidateMethodInfoList.LastOrDefault();
        }

        /// <summary>
        /// Register a specific System.Type as available for referencing in a Lava template.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="allowedMembers"></param>
        public override void RegisterSafeType( Type type, IEnumerable<string> allowedMembers )
        {
            // Check if any LavaType attributes are implemented.
            string[] allowedMembersArray;

            if ( allowedMembers == null )
            {
                allowedMembersArray = LavaDataHelper.GetLavaTypeInfo( type ).VisiblePropertyNames.ToArray();
            }
            else
            {
                allowedMembersArray = allowedMembers.ToArray();
            }

            // If no members of the Type are allowed, do not register it.
            if ( !allowedMembersArray.Any() )
            {
                return;
            }

            // Register the Type and if necessary, provide a converter function to return a Type that supports the IDictionary<string,object> interface required by DotLiquid.
            if ( typeof( IDictionary<string, object> ).IsAssignableFrom( type ) )
            {
                // This Type does not require conversion, it can be accessed directly by DotLiquid.
                Template.RegisterSafeType( type, allowedMembersArray );

                return;
            }
            else if ( typeof( Rock.Lava.ILavaDataDictionary ).IsAssignableFrom( type ) )
            {
                Template.RegisterSafeType( type,
                    ( obj ) =>
                    {
                        // Return a wrapper for the Lava dictionary that supports the IDictionary<string, object> interface.
                        return new DotLiquidLavaDataDictionaryProxy( obj as ILavaDataDictionary );
                    } );
            }
            else if ( typeof( Rock.Lava.ILavaDataDictionarySource ).IsAssignableFrom( type ) )
            {
                Template.RegisterSafeType( type,
                    ( obj ) =>
                    {
                        // Get the Lava Dictionary and return it in a wrapper that supports the IDictionary<string, object> interface.
                        var lavaDictionary = ( ( Rock.Lava.ILavaDataDictionarySource ) obj ).GetLavaDataDictionary();

                        return new DotLiquidLavaDataDictionaryProxy( lavaDictionary );
                    } );
            }
            else
            {
                // Wrap the object in a DotLiquid compatible proxy that supports the IDictionary<string, object> interface.
                Template.RegisterSafeType( type,
                    ( obj ) =>
                    {
                        return new DropProxy( obj, allowedMembersArray );
                    } );
            }
        }

        /// <summary>
        /// Register a Lava Tag element.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factoryMethod"></param>
        public override void RegisterTag( string name, Func<string, ILavaTag> factoryMethod )
        {
            if ( name == null )
            {
                throw new ArgumentException( "Name must be specified." );
            }

            name = name.Trim().ToLower();

            base.RegisterTag( name, factoryMethod );

            DotLiquidTagProxy.RegisterFactory( name, factoryMethod );

            // Register the proxy for the specified tag name.
            Template.RegisterTag<DotLiquidTagProxy>( name );
        }

        /// <summary>
        /// Register a Lava Block element.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factoryMethod"></param>
        public override void RegisterBlock( string name, Func<string, ILavaBlock> factoryMethod )
        {
            if ( name == null )
            {
                throw new ArgumentException( "Name must be specified." );
            }

            name = name.Trim().ToLower();

            base.RegisterBlock( name, factoryMethod );

            DotLiquidBlockProxy.RegisterFactory( name, factoryMethod );

            // DotLiquid regards a Block as a special type of Tag.
            Template.RegisterTag<DotLiquidBlockProxy>( name );
        }

        /// <summary>
        /// Render the Lava template using the DotLiquid rendering engine.
        /// </summary>
        /// <param name="inputTemplate"></param>
        /// <param name="output"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override LavaRenderResult OnRenderTemplate( ILavaTemplate template, LavaRenderParameters parameters )
        {
            var result = new LavaRenderResult();

            var renderSettings = new RenderParameters();

            // Set the flag to rethrow exceptions generated by the DotLiquid framework, so they can be intercepted and handled as Lava errors.
            // Note that this flag is required in addition to the Context(rethrowErrors) constructor parameter.
            renderSettings.RethrowErrors = true;

            var templateContext = parameters.Context as DotLiquidRenderContext;

            if ( templateContext == null )
            {
                throw new LavaException( "Invalid LavaContext parameter. This context type is not compatible with the DotLiquid templating engine." );
            }

            var dotLiquidContext = templateContext.DotLiquidContext;

            renderSettings.Context = dotLiquidContext;

            if ( parameters.ShouldEncodeStringsAsXml )
            {
                renderSettings.ValueTypeTransformers = new Dictionary<Type, Func<object, object>>();
                renderSettings.ValueTypeTransformers.Add( typeof( string ), EncodeStringTransformer );
            }

            // Call the Render method of the underlying DotLiquid template.
            var templateProxy = template as DotLiquidTemplateProxy;

            if ( templateProxy == null )
            {
                throw new Exception( "Render failed. The provided template instance is not compatible with the DotLiquid engine." );
            }

            result.Text = templateProxy.DotLiquidTemplate.Render( renderSettings );

            if ( renderSettings.Context.Errors != null )
            {
                if ( renderSettings.Context.Errors.Count > 1 )
                {
                    result.Error = new AggregateException( renderSettings.Context.Errors );
                }
                else
                {
                    result.Error = renderSettings.Context.Errors.FirstOrDefault();
                }
            }

            return result;
        }

        /// <summary>
        /// Encodes string values that are processed by a lava filter
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        private static object EncodeStringTransformer( object s )
        {
            string val = ( s as string );

            if ( !string.IsNullOrEmpty( val ) )
            {
                return val.EncodeXml();
            }
            else
            {
                return s;
            }
        }

        protected override ILavaTemplate OnParseTemplate( string inputTemplate )
        {
            // Create a new DotLiquid template and wrap it in a proxy for use with the Lava engine.
            var dotLiquidTemplate = CreateNewDotLiquidTemplate( inputTemplate );

            var lavaTemplate = new DotLiquidTemplateProxy( dotLiquidTemplate, inputTemplate );

            return lavaTemplate;
        }

        /// <summary>
        /// Compare two objects for equivalence according to the applicable Lava equality rules for the input object types.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>True if the two objects are considered equal.</returns>
        public override bool AreEqualValue( object left, object right )
        {
            var condition = global::DotLiquid.Condition.Operators["=="];

            return condition( left, right );
        }

        /// <inheritdoc />
        public override List<string> GetRegisteredFilterNames()
        {
            var strainerType = typeof( Strainer );
            var filtersField = strainerType.GetField( "Filters", BindingFlags.NonPublic | BindingFlags.Static );

            var filters = filtersField.GetValue( null ) as Dictionary<string, Type>;

            var filterNames = filters.Keys
                .Select( k => k )
                .OrderBy( k => k )
                .ToList();
            return filterNames;
        }

        private Template CreateNewDotLiquidTemplate( string inputTemplate )
        {
            var liquidTemplate = ConvertToLiquid( inputTemplate );

            var template = Template.Parse( liquidTemplate );

            /* 
             * 2/19/2020 - JPH
             * The DotLiquid library's Template object was not originally designed to be thread safe, but a PR has since
             * been merged into that repository to add this functionality (https://github.com/dotliquid/dotliquid/pull/220).
             * We have cherry-picked the PR's changes into our DotLiquid project, allowing the Template to operate safely
             * in a multithreaded context, which can happen often with our cached Template instances.
             *
             * Reason: Rock Issue #4084, Weird Behavior with Lava Includes
             */
            template.MakeThreadSafe();

            return template;
        }
    }
}
