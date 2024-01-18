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

namespace Rock.Plugin.HotFixes
{
    /// <summary>
    /// Plug-in migration
    /// </summary>
    /// <seealso cref="Rock.Plugin.Migration" />
    [MigrationNumber( 194, "1.16.3" )]
    public class MigratoinRollupForV17_0_3 : Migration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            RemoveLegacyPreferences();
            ReplaceFavIconUp();
            AddUpdatePersistedDatasetServiceUp();
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            // Down migrations are not yet supported in plug-in migrations.
        }

        /// <summary>
        /// DH: Add Run-Once job for Rock.Jobs.PostUpdateJobs.PostV17RemoveLegacyPreferencesPostMigration
        /// </summary>
        private void RemoveLegacyPreferences()
        {
            // note: the cronExpression was chosen at random. It is provided as it is mandatory in the Service Job. Feel free to change it if needed.
            RockMigrationHelper.AddPostUpdateServiceJob(
                name: "Rock Update Helper v17.0 - Remove Legacy Preferences Post Migration Job.",
                description: "This job removes the legacy user preferences from the Attribute and AttributeValue tables.",
                jobType: "Rock.Jobs.PostUpdateJobs.PostV17RemoveLegacyPreferencesPostMigration",
                cronExpression: "0 0 21 1/1 * ? *",
                guid: Rock.SystemGuid.ServiceJob.DATA_MIGRATIONS_170_REMOVE_LEGACY_PREFERENCES );
        }

        /// <summary>
        /// JC: Replace the binary content of the default icon file.
        /// The old file has a circular shape
        /// while the new file has a square shape with rounded corners.
        /// </summary>
        private void ReplaceFavIconUp()
        {
            Sql( @"
    --Replace the old original Fav Icon Binary File content with the value of the new icon
    DECLARE @oldIcon VARBINARY( MAX ) = 0x89504E470D0A1A0A0000000D49484452000000C0000000C0080600000052DC6C07000000017352474200AECE1CE90000000467414D410000B18F0BFC61050000001974455874536F6674776172650041646F626520496D616765526561647971C9653C0000147B49444154785EEDDD6BD01C55990770B7586F1FD6FDB4A5E896B5A501E4B6885C2468291731145A968B5F30BA8A6ED62D0B763752BB24908BE1B6262001431010638004595012944A2A68022810562808E112D935140410A34B32F3DEAF33EDF3EFB7676AE69DFFBCEFF44C779FA74F3FA7EA57541EE672FA9CA7939933DDCF79CBC18BE798E41C2AE68A2F8A4BC4F56283D82A7E23F68AD7C4C1C8B808A2FFD662F8FF781C1E8FE7E1F9781DBC1E5E17AF8FF761EF6F62A24133ABF78979E2628104DD25460492392B78BF6704DE1FFD407FD02FD65FD3060D9A26878813C5B7C4BDE275C112520BF40FFD447FD16FF49F1D97113468E6FCAD58207E2ACA82255A5EA0FF380E1C0F8E8B1D6F61D160411D25568867054B245FE0F8709C385E360E85428305F241B144F89EF4EDE0B871FC1807363EDEA341CFBD5D60356587A80A9618458371C078CC17181F366E5EA2414F7D40AC1607044B023305E38371C278B171F40A0D7AE664718F98146CC20D87F1C2B861FCD8B87A81063D7196F8B560936BE2C1387E5AB071CE351ACCB9D3C423824DA4E90DC615E3CBC63D976830A73E22B60B36712659F8C27C8260F3902B349833B82E669DA8083659261D186F8C7BAEAF4BA2C19C789BC01AF680601364B281F1C73C603ED83CA9468339F031B147B009316E603E302F6CBED4A241C5DE25D60AFBB8A313E605F3837962F3A70E0D2A75A6C0B5F26CE08D2E98A74F09368FAAD0A032F869FE1AA1FE6FFDD28A1382FE5BFE3118DCF8AFA1FE1F7C25285D76127D6C0160BE306FAA2FADA0414570C5226E366103AC4279D599C1E823EB83CAC1D78376AD527A23187DF4F6A0EF9AB3E86B780EF3A7F6CA531A540217AC0D0A36A8CE952EFF6830B6EBE74150AD4469DE4193C78EEDBA3F285F3197BEA6C78604E693CDB35334E8D85B05EE816503A9C2C0AD5F0D2AFD7F8AB23A7EAB0E1E0806D6FD137D6DCF615E31BF6CDE9DA04187DE2D7E25D8E0A930B8F1DF826072224AE51E5A653218BC73217D0FCFE1BA22CC339BFFCCD1A023478B97051B3415FA6F9E2FC93F1E6570024D5E0B5F9AD97B79EE1581F9667990291A74E00C8192206CB054C0975D7C7449BA55874AE16BB3F7F45C4960699BE543666830635F1563820D920A58DEACBCF94A94B2C937BC76E9B293E97B7B0EF590CE172C2F32418319FA77A1FBB6C44B8E0C26F6EE8C5235BD36B1F7F1F0BD681FFC86F95F28587EA48E0633820BA8D880A832F6D4E62845D36F634FFF2C38B8E830DA8F02582A589EA48A0633F01DC1064195E1ADD744A9995DC37BB2BE14C44AC1F225353498321C243B7855B0441954AB515A66D8E43D07EFBA88F6A920323D09683045F8678E1DB42AFD6BBF1054C787A38CCCBEE1BDD107D6B782582658FE248E0653822F3AEC605529AF3C3D95E5CEB80D7D28AF3A83F6B12032F9624C8329F892505F84AAB4FCF860F20F2F4629E8BEA12FE813EB6B01205F90372C9F12438309C38F5CAAD7F9438B8FC864B9336E439FD037DA67FF216F903F2CAF124183093A56E4A2BAF2E8E3774629A7AFA16FACCF0581FC411EB1FCEA190D26E46FC43EC10E4A95E12DABA254D3DB86B7ACA47D2F08DC61F61EC1F2AC273498005CF2AAFAAACE9A81DBFE25BC32537D933EA2AFEC180A025791267E29350D26E03AC10E4295FE35E73A5DEE8CDBD0D7BE35FF408FA520703F01CBB7AED1608FCE13ACF3AA94AFFA785029FF214AADFC34F4197D67C7541028E1CEF2AE2B34D88323056E7F631D57A3B4EC3855CB9D715BB83CBAF4587A6C0580FC4AEC1E631AECD23B84FE9D56161F118CBFB03D4AA5FC361C438197479167EF142C0F63A1C12EAD11ACB3AA8CEEDC10A550FE1B2A4DB0632C881B04CBC35868B00BA81DAFFE97DEA14DCBA3D4F1A7E198D8B11600F2ADE73D0B6830A6BF12EA2BB60DACFF463E963BE3362C8FAEFB3A3DE60240DE21FF585E76840663BA51B0CEA9D1B7FA334175A43FCA18FF1A8E0DC7C88EBD00907F2C2F3B428331A01AB0EA9285E5AB3E96CBE5CEB80DC788625D6C0C3C87FCEBBA2A350D7608351F5597282F2D393698D8F74C9422FE371C2B8E998D85E790875DD520A5C10E2D16AC333A2C3ADC8BE5CEB86DECD96D45BDAF18F9C8F2744634D8015C98D42F5847541879E8E628258AD770EC6C4C3C877C8C7DC11C0D7660BD609D506168D3B228158ADB06EF5944C7C673B70996AF6DD1E02C4E146ABFF8A2D460A2E50BF3DA8A5976117989FC64794BD1E02CD46E45DAB7FA1CAF973BE3368C4501CB2E620B5796B7140DCE009B24B337750EA505D32C5F18A7E1CBF7F8730F447F72DB0A5A76B1E3CDBC697006B82981BDA153A525C7A859EEAC2D456A5A829D78F9C9A2955DC48EF62C7F5BD0601BF3047B33B7161D169614D4D0A65FAB8F9D60B4FC0857C0B28BC85796C74D68B00D95B7388E3C785334C56E5BBBCB11345D8631FCC0752DFDF3183EADB03C6E4283C42982BD89532821E8A47CE1F436CBFDBA033F5A103EC6792B5ED945E42DCBE73A1A24EE16EC0D9CD1B4DCD9C925C96A2EC5C6F26871CA2E226F593ED7D1E03473C484606FE0445ABBB574D346776EA47D64461FBB237A96DB365576B110CBA3C85BE42FCBEB100D4EA3AAC283B6E5CE58B7252ABA1D73F28F7B8B527611F9CBF23A44830D709FEF9B82BD70F632DAADA5933655B7F3C3BC9F33D074437E5876D1FFE551E46FDB2B4569B0014A50B017CD9EE2E5CEB834956419FD9FBB681F3DD3B6940A0D367850B017CC9C8BDD5A580B6BF7DF702EED631C780D2D45B90AB02B0DF298E5F78C2700BE3CA8B8D13D2FCB9D71A929CB2863EB79D945E431FD32DC1268B05CB017CB94EBDD5A1ADBF0D6AB691F7BA1EA5F36BF9747E9AE332D81062F0AF6429951B5DC996289722DA5D92BE5FD3E975D7C4EB4E4794B20729C602F92194DBBB54CAD967C88F63311EA56B7BC5D1E6D29A9D8F48706970BF602D92860424C9DF0FF1BBDABDB36BE6787AF65175788A65C6FFA4303A7353EB57C24087F315D793AED631A8AF291CF21E47553AE37FD21F27EC19E9C89A27F290CBFF44F8C46BD70DB3C2DBBF85E51CFF7C6C4AFF9A6604F4C5DB82C58AD44C3EFB0E1AAC91F2FA47DCC82AA65DFF5DFA07DCCB105A29EEF8D895FB359B027A64AD772A7FB1F8686B75D1BF5C66DF3B0ECE23DA29EEF8D890F8788CC77759CBA34607F34E46EDBD8D3F7D13E664EDBA51F579ECAFB993FC86FE4393D018E17EC49A9D1B7DCA9E8E230AC86BDF49BA8776E9B67651791E7F404B840B027A4039707EFD9110DB1DB16564F587122EFA743EA2EFFF6E3BEE20B053D01EE12EC09A950B5DCA9F80691707974B81CF5D66DF3A4EC22F29C9E00AF0AF684C40D6DFE7634A48E1B6E11BC793EEDA326AA6E01BD7729ED638E20CF5B4E00AC8FB207274ED3559079BA497CF0EE8BA38E3B6E7E945D0C7F0F683C01CE16EC81899A2A1332108DA4DB36B2E346DA47CDB454BD0E9747BF3B8FF6312790EF4D27C07F0AF6C0C468BA132AB785A2B03CBA7B4B74146E5BCECB2E22DF9B4E803B047B6022C25281AFEE8E86CE6DC392DEC14B8FA2FDCC03556517F7EDD2B574DCB90DA2E904D82DD8037BA7A81A822FC562C3E5D1D2EFA3A372DB72FAAF6978615CE309302CD8037B36F2D02DD150B96DE1E7D66BCFA67DCC234D651747B6AFA57D540CF95E3F01B0B50C7B50CF545544F370C388811F9E6F2B6ADD7B6FED0448A5F667B876AD6172A479B076DD96AABF64BE7F1EEDA352A7D64E80C4EBFFA8FAE7B9009BC68D3EB23E3A5AB72D676517E7D74E804B1B823D0BBFA01D78351A12B76DFCF95FF872FDCACC342D34FCFFCB79B9AFF8D2DA099058FD4F5D4B74C5DA381AC73AF9C66FA3A377DB725276F1FADA0990CC6F00F89166D7FDD110B86DE135EC57CCE5FDF498AAB28B4FFC84F651910DB513605B43B06BAA7EA6F7EB2EA658FAAEFF9CDD5DD7996DB513E089866077161D1EF47DEFF32A94FFEB13BC8F59917FFAB11A822B5E477EB92618DDB9212C429B252D371985CBA31B2EE0E3E4DE13B513606F43D074A9EFEAB3C2E4AB0EF745B36F0D4D71D9C5976A27C0FE86A089095F3E471FBD5DCD6F1E1A5B75E04D8D6517F7D54E80CC6F84F705FED6D772CBA2F6A6B0EC62B976024C36044D8750354ECB8A4B5EDAF88B0F6B2ABB583F01D8FF3433D054CD226F6DE4E15BE9983A3061274097F065D75A97AD5A55731FB69D005DE8BBEEB3F685B7C736F9FB3D1A2E51A9FF0B60DF0162D0F26B77DE1B2EE566E39BA1FA77005B05EA5069E9DF07D5F191680AADF5D2C23BC9C81867A87E02D8EF001D0A4BBA584BA4E1D26936C619AAFF0EF05243D0CC60F881D5D1F4594BA239FE71ACFE4B70EFD7021504AE70B4965CC3B55B6C9C33F264ED0448E46AD022D052CCD797E6F88B70FD6AD0546B02F964ECC97BA3A9B39644737C0F71FD7E80C4EE08F31DCA295A4BAE95BFF3493ACE19A9DF1196E83DC13E1BDC70613475D67A6DD5A1B2EB1FC3EAF704275E15C257A51527D8AFC009B5B1DD5BE91867A85E15E2D486A099C5F80BBF8CA6D05A2F6D60FD3FD3F1CD50BD2E506A95E17CD47FD379D1145AEBB64DEEFF9D86CBA2EB95E120B5DAA03ED252A23CAF6D60DDD7E9B86608F9FE178D2700AAE5B2071AA274D94941A5FF4FD1745A8BD3B0371C1BD38CB55487B6DF0262EABFE5CB613D4C6B9DB7F1FF7B544BC1AC8DA2E904487D87181FA122326EF0B0367B1B7B765B50BAF4683A8E0EB4EC1093C91E613E1A79F0A6688AADB1561D1B0A867E7EA5B61AAD2D7B8465B64BA4775012F2E99F45D36DADD670B9F3C8AF6E0DCA979FC2C7CDAD965D2221B37D827D535A728C9AA2C06813AF3C259FB71F8BE785EDE18F535D7BFABEB04CFBF0FD574D5DE5B9E8703A560ABC26C29C9F7E0264BA53BC6FC2B2F04A6A0421991527A06B6D778ABF40B027980EF5AD3EC73606D1EF42414F80E3057B828921DC1A4AC9F2E8D0A665B48F05F711414F804384DD209F00249E8AE6E9E6803D407E23CFE90900F709F6441393AEFD12CEA17D2CA09F887ABE37267ECD37057BA2896BD161B641B83E0B443DDF1B13BFE6FD823DD17441DF9E69C7D07E1648B8FE5FD398F88DECC2B80495AF3C554D15E9B01895AE5F64B3145E00D7A8E90F0D2E17EC054C976CDF64152E134DB9DEF487061F16EC054C0F7007948ADB29B16FD75D17D13E7AEE68D194EB4D7F98E645C15EC4F46068D3F2280B1DB7E22D8F3E275AF2BC25D060B9602F647A845D2335345CAC565E7526EDA3879689963C6F0934384C54057B31D38BC547D8F268B690C773444B9EB704A67948B017343D2A2D3B4ECD164B137B776AB94B2B2DC86396DFB39E00562F2845A88C6CCBA399401EB3FC9EF50478873820D88B9A04F4AF3937DC485A431BDE7A0DED63CEBD2990C72CBF673D01C0EA86A62CDC74C39647D382FC65791DA2C169F0E5C1F6104BD9F096955116BA6DF8D7A87FED17681F7308794BBFFCD6D02071B7606F6012847A391A9A47CBA3C85B96CF7534489C22D81B98242D3E225C91D1D0B04285CDC0693FF30379CBF2B98E06DBF8B5606F6212A46907FA9C2F8F3E22581E37A1C136E609F6462661E595A7851F4334B4D1C77F4CFB9803C85796C74D68700638ABD89B9984E18BA82D8F76ED51C1F2B7050DCEE034C1DED0A460F0CE85E1D2A4F356AD844BB5AC8F4A214F59FEB6A0C159EC10EC4D4D0AF0B7AF8696A3E5D10705CB5B8A066771A2A808F6E62605634F6D8ED2D06DAB94F7BBDED87A36B8E80DF9C9F296A2C10EDC2658074C1A2E39D296473B83BC64F9DA160D76005B2A0D08D60993026CCEA7A6ECE29E1D1AB6379A0EF988BC64F9DA160D7668B1601D3129C1AFB37A964755ECF2D208F9C8F2744634D8A1B70BBB6D3263FD37CFD7537671F3B7691F1D401E221F599ECE880663C07293DD35963135BBD25426352C8F22FF4E172C3F67458331FD50B08E99148D6CBF31CA42B7AD3A3210967C617DCC08F28FE565476830A6BF16D8708075CEA445D1AE34B8ABCDD1F228F20EF9C7F2B22334D8854F0BFB2894352C8F6A29BBF8DAEEB00C24ED673A906F1D5DEF33131AECD20D8275D4A448DDAE34D92D8FAE152C0F63A1C12EBD53584D5107FABE3B4F4FD9C5877F40FB98B0E705F28DE5612C34D883A3C490609D3629D2B52BCD72DAC78420BF5A4A1C768B067B64A5541C19FAE99228051DB7CA649A6517BF2C58DE758506136095241CD1B52B4DE2CBA3D70B966F5DA3C104BC55D82D942E60579AE77F11A5A1DB5639F06A9265177133D6DB04CBB7AED16042DE2DECF70107F4ED4AD3F3F228F2E850C1F2AC273498A06385ED3AE940F98AB97ACA2EEEBABF97B28BC81FE411CBAF9ED160C2CE1063821D9C499107BBD2206F903F2CAF12418329F892B05F8A1D18F8D182705546431BFCEFFFA07D6C03F982BC61F994181A4CC9B7043B5093B29CEE4A837C617994281A4C1176E960076B523674EF52F918728B73C35B5675F27D80EEE692061A4CD92AC10EDA18B85AB0BC49050D66C04E02C3202F58BEA4860633B254B04130C594D9C79E463498A185C256878A0DF39FC9175E86063376BE18176C708CDF30EF5F132C2F3241830E9C294A820D92F1137EE1C5BCB37CC80C0D3A826BBC5F116CB08C5FF689C4AEE9EF050D3A840BE8EC2A52BFE1AA4ECC339BFFCCD1A063B894FA7B820D9EC937CC2BE697CDBB1334A804EE2CB3DB2BFD80796CBB59B54B34A808EE31DE25D8A09A7C7846601ED9FC3A4783CAA0E6E3B5C27E2FC817CC17E6ADAB9A9D59A141A53E25EC0EB37C785D60BED83CAA42838ABD4BDC286C871A9D302FDF179827367FEAD0600E7C5CEC116C128C1BBF159817365F6AD1604EE0B3E512613BD5B885F1C73CA8FEACDF0E0DE60CAA05AC13F6B1285B186F8C7B2AD51AB242833975B2C016996CB24CB230CE1F156C1E728506730EBB8560A7703671A63718D7AE7763D188063D81DAF1B8EE844DA489E731D1732D7E8D68D033F868748F98146C720D87F1C2B879F151A71D1AF4D407048AF61E106CC2CD148C0FC609E3C5C6D12B34E8392CD7A1E0D243C22EAF988271C078605C72B99CD92D1A2C900F0ADC8CFD9C6089E13B1C378E1FE3C0C6C77B345850B8627185F07D9B271C1F8E53ED159A59A24133E7EFC405E23E91F7EAD6E83F8E03C783E362C75B5834689A1C224E1217894D02573AB244D302FD433FD15FF4FB2F053B2E2368D0CCEA7DE26C71B1D828768B11C112322D783FBC2FDE1FFD407FD02FD65FD3060D9AAEE1BA98B9E28BE212813DAD3688ADE209F19278431C8CD4AE5FC27F6B31FC7F3C0E8FC7F3F07CBC0E5E0FAF8BD7CFF5F5379AD0A031C530E72D7F068CF79FD77AF9B6C60000000049454E44AE426082
    DECLARE @newIcon VARBINARY( MAX ) = 0x89504E470D0A1A0A0000000D49484452000000C0000000C0080600000052DC6C070000000467414D410000B18F0BFC6105000000097048597300000B1300000B1301009A9C1800000AFF49444154785EED9DCF6E135718C5F3083C82253C94256A1FA0F401CA0B14099674956C62D35590DA4AEC02DDB1A274895421D15D5964018B56AA940D7487BCA08004498610201002EE7C9E6B489C6BFB8E7DFF9C7BEF39D20F29B18927CE773CF7FBE6CCCC826F95CBC5A9B25B2C969DF66AC5ADB27BA2276C758B3EC987C1DFBD53AC57B5B036A805A9896EFBB42A9374542EB58ED5BF5CB156FDE2E5E81B41C808E5C0143F1C3F57765B2D554671498A7EE362715E15BDEE9724C488A1195469614B0A7FB37BE252B5E1FCA427B6E9496DC1EE1558F8C4133DA83D82342E5B6C62897F7ACF4336CDF572A7B8A2D93042BC51F508ABAA24FDA9EC9E6C6D758A75DD061112809EB7DEA05EF270AD4FE070BF2492D1A6E6850981C15983BCD9F96249F78284A0B1D9692FA9B2B5237EF293D8B0B627506B7EED8B1082CCDC3DC160DAC3193F89958EE48AE6980EB1F849F448E274A9754C95B4B978908BA442E383655CF793D468D40F70E9639F72E5CBFE8BCBDF7C42BED63D8F38A3A7CA7BB238F2B4C7CB6B67FBBB77AFF7F71FFFDBD749BE2F8F6F5F39A3FDFFC42E65A7BDA2CA5C2F4E7DEC2085FFFEE1DFAACCCDB4573DFFC5E5D3DA9F472C2153A1490DB1CAF4EBFF3331E2EDBD5F5549CFA637777ED1FE5C6287897B017EFACF8EACE9C72D759AEADD3FBF6B5F835860DC5E806BFFF9B055FC43D104EED0C6247802FBECEC56CB16177A7DFB27EDEB91B95953655FAB6E7EB54F24537055FC43BDBCF69DF675C97C1C5A0671F9331BDB57CFA83275A70F5BFF713AE4806AC5B3A8CA9FCB9F5990A294E2F4A1FDC70F78E0CC3E9F9741D5173CC5B101528CBE8A7F2836C596E914E5A0F899FB69CEDE833BAA2CFD8AC708ECF26CB93825CB9F45DD83448FEBA6779A5EDDEC68B78B3467D00754FFACEA1E244779FDC7CFAA0CC3E9E39B6D36C59690AB52B30136C4C7C4C754D27FB029B640A77D4B1A605EE06A0A3E273EA6DA7BF897765B49237ACCFF4C21C4C4C7546FEF5DD76E3331460CA07D8028424D7C4CC5B8C47CD00013083DF13115E312B343038C0161E2632A59A27132341B348006A4898FA91897980D1A6004C4898FA91897680E0D7000E4898FA9189768060D708079CFE745D1CE8D0BDADF8F1C850650C432F13111E312E6D00015AF6E7655E9A42359CAB1299E4EF606904FCA8FBB2F55D9A425C625A693B501629EF8988A7189C9646D00DB97324115E312E3C9D600A94C7C4CB57DE55BEDFB903B591A20A5898FA91897D0939D01766E7CAF4A223F312E7194AC0C90F2C4C7548C4B1C261B03E430F13115E3129FC9C600B94C7C4CC5B8444D1606C86DE26322C6256A9237408E131F53312E91B801D0263E1FB61E5586BCAABEC250EE7189640D8038F19133CD64DBD04C90735C224903204E7C5EDFFEF1D036CA381249B9C625923440D33B34BAD69BEA137F741BCB4B5FF5F79F604DA6728C4B246700B4A677D21ABBDE533D52CF0CAF1CE312491900ADF8A5B8A715945CD30749B9C525923100DAA54C4C8A7F88ACBF9194535C2209032036BD4DAFD6B60B76B02E97B844F40640BC9489AEE935E17DD52F202987B844F40640BB78EDEEDDD967EA684D710E7189A80D80D6F44A03A9DBCE26482F8374002FF5B844B40640BB786D93A6771A721F3024A51C9788D20068139F8FBBF6970A8C4BF8213A03204E7C5C358B8C4BB8272A03A434F13141E212484DB128B5B84454064869E2638AECF1D09AE2942643D11820C5898F298C4BB8230A03A43CF13185710937C01B2087898F298C4BD807DA00394D7C4C413B8720F63B54C21A20B7898F29F58702E312B6803500DAA54C7C4C7C4C615CC21E9006403CB145B79D21615CC20E700640BB5D5188898F298C4BCC0F9401A4D09076ED21273EA6A01D1C8C2D2E016380BAB9C36A7A472F6582085A5C429AE298E212300640BB782DC2C4C714B43D674C71090803A04D7C6459A1DB4E641897988DE006409CF8C43AD2635CA239410D8078F1DA5876DDE3605CA219C10C80B66E15C90126DDB6C606E312E6043100273E6EA9DF5FC6254C0862004E7CDCC3B88419DE0DC0898F3F1897988E570370E2E31FB4B8045A53ECCD009CF884032D2E217B26DD7686C08B0138F1090BE312E3716E004E7C3040FB1042894B3837400CB72BCA05C6258EE2D400684D6FCA131F53D0E212A1CF217066004E7C70418B4B843C87C09901647DE713D9BD4F02A9F85F5CFEA6DAA6B383B3DF5C23D33779AD83C8F7D08612F237D2BD57AE71DE03901A293C39B11E6D2080A25071091AC031F247451B04A02A445C820670885CD2116DA9812EDF71091AC01168438098E4332E41033800ED62BE31CA575C8206B08CACF9A9F9E5AB29A6012CC3298F3DF9E80768008BC8DC9DB22BD7C70768008BF0D3DFBE5CEF0568004BC8812ECA8D5CF60234802538F971279759211AC0127BF7B1CEBA4A496F1D5E608B06B004E30EEEE4B20FA0012CC106D89DE4BDD5BDE736A0012C4103B8130D10015C02B913974011208D1AE546EFEEFFA97DCF6D40035882635077E2183402E4DA3B941BF1405824BCAFD6AA945DED3F79A07DAF6D41035844825B945DB93E2F8006B00CF702F62497B2D1BDC736A1012C23EB559E076C473C212652D0AEBE16A37C5DBF95067004DAD5D76292CFEBB7D2000E613FD04C1F77B7FB3B372E68DF4B57D0000E41BB2E3FB2E4C2C53ED6FCA3D0008E61533C5EF2E120CB9D9037CBA0013CB0F31BD6EDA186776811739A30BCC0B02DE4EE3C28172BA6013C8176B33ADF9720448506F0C83BB0C468E89B5320400378449AE2FD275837090F79730A046800CFC89A1A6D328472C7C610D000019026104972CAA11853B7ADA9430304022D2E8170C7C610D00001418B4B4893AEDBCE94A10102831697F079730A046880C020C625E460956E5B53840600401A50A4B844A83B3686800600012D2E2193A11C9A621A0008C625FC43038081169748BD29A601C0408C4BF8BA636308680040D0E212C3F8B46E5B638706008571093FD000C020C62574DB1933340038687189D4CE21A00122002D2E91D23904344004302EE10E1A2012189770030D10118C4BD88706880CB8B884C3DB17F980068810C625EC41034408E312F6A001228571093BD0001123A34824C51897A00122072D2E11DB3904344002302E313B344022302E311B344022302E311B344042A0C52562688A6980C490793C92D02FB95819E0444FF7008917B4B804F025177B3440A2302E6140A7585F28BBED5BDA0749D420C6257CDF02753AEDB5CA00C5AAFE41123B684D31DA390465A7BD2A0658D43D48D200312E81D2144BED2F94CBC529DD83241D1897D0532EB7BF5E10555F94A30F92B4605C62844E510E8A5F547D63EDC8134872302E7190AA011E8A7D401E48038A169708750E41D9397E4E957F658095D631DD93487AC82517199728FA4FBBAD962AFF5AD537B90CCA04C6250E2C7F86DA582ECEEB9F4C5224E7B8C4A1E5CF506A19C4695046641A97E8A9923FAAB2D35ED1FC079228399E43B059D5B82AF7A3E25E203F328B4BF48E34BFA3E25E203FE45357F60436B021577109EDDA5F2746A449828C5FFB8FEA79B77D5AF3030889964FB91F536D32264D12A16A7C5755599B4B35C4EBA33F8C90C8305FFA8CEA69F764ABFA019C0A9158993EF59926F60324561AAFFBC769E3226312242E364C479EA6AA1A8925DD0B1182C6A69CEAE842DC131074AC7FF28FAAEE0978A08CC0515A5BF34F533D1DA20908089D627DEE69CF2CE2C132121A39C8D55B6A1D5325E95F5C129140F4BC2D794C549F51462310E7941333FD2125BD816C1C8D401C3028FCA0CB9D26AAF7086D9E684FE6A4BD2639FE680A7F54B257386006E68AC834AA1AA98ABE5B2C465BF493248D8BFC72D2BD2B5348E2944BA6FC90BF7945FB96D482D4C4B3E5E2942A134F5A58F81F9905C6FAE952D5C20000000049454E44AE426082

    UPDATE bfd
    SET Content = @newIcon
    FROM
        [dbo].[Site] s
        INNER JOIN[BinaryFile] bf ON bf.Id = s.FavIconBinaryFileId
        INNER JOIN[BinaryFileData] bfd ON bfd.Id = s.FavIconBinaryFileId
    WHERE bfd.Content = @oldIcon" );
        }

        /// <summary>
        /// JC: ReplaceFavIcon Down
        /// </summary>
        private void ReplaceFavIconDown()
        {
            Sql( @"
    -- Replace the new Fav Icon Binary File content with the value of original icon
    DECLARE @oldIcon VARBINARY( MAX ) = 0x89504E470D0A1A0A0000000D49484452000000C0000000C0080600000052DC6C07000000017352474200AECE1CE90000000467414D410000B18F0BFC61050000001974455874536F6674776172650041646F626520496D616765526561647971C9653C0000147B49444154785EEDDD6BD01C55990770B7586F1FD6FDB4A5E896B5A501E4B6885C2468291731145A968B5F30BA8A6ED62D0B763752BB24908BE1B6262001431010638004595012944A2A68022810562808E112D935140410A34B32F3DEAF33EDF3EFB7676AE69DFFBCEFF44C779FA74F3FA7EA57541EE672FA9CA7939933DDCF79CBC18BE798E41C2AE68A2F8A4BC4F56283D82A7E23F68AD7C4C1C8B808A2FFD662F8FF781C1E8FE7E1F9781DBC1E5E17AF8FF761EF6F62A24133ABF78979E2628104DD25460492392B78BF6704DE1FFD407FD02FD65FD3060D9A26878813C5B7C4BDE275C112520BF40FFD447FD16FF49F1D97113468E6FCAD58207E2ACA82255A5EA0FF380E1C0F8E8B1D6F61D160411D25568867054B245FE0F8709C385E360E85428305F241B144F89EF4EDE0B871FC1807363EDEA341CFBD5D60356587A80A9618458371C078CC17181F366E5EA2414F7D40AC1607044B023305E38371C278B171F40A0D7AE664718F98146CC20D87F1C2B861FCD8B87A81063D7196F8B560936BE2C1387E5AB071CE351ACCB9D3C423824DA4E90DC615E3CBC63D976830A73E22B60B36712659F8C27C8260F3902B349833B82E669DA8083659261D186F8C7BAEAF4BA2C19C789BC01AF680601364B281F1C73C603ED83CA9468339F031B147B009316E603E302F6CBED4A241C5DE25D60AFBB8A313E605F3837962F3A70E0D2A75A6C0B5F26CE08D2E98A74F09368FAAD0A032F869FE1AA1FE6FFDD28A1382FE5BFE3118DCF8AFA1FE1F7C25285D76127D6C0160BE306FAA2FADA0414570C5226E366103AC4279D599C1E823EB83CAC1D78376AD527A23187DF4F6A0EF9AB3E86B780EF3A7F6CA531A540217AC0D0A36A8CE952EFF6830B6EBE74150AD4469DE4193C78EEDBA3F285F3197BEA6C78604E693CDB35334E8D85B05EE816503A9C2C0AD5F0D2AFD7F8AB23A7EAB0E1E0806D6FD137D6DCF615E31BF6CDE9DA04187DE2D7E25D8E0A930B8F1DF826072224AE51E5A653218BC73217D0FCFE1BA22CC339BFFCCD1A023478B97051B3415FA6F9E2FC93F1E6570024D5E0B5F9AD97B79EE1581F9667990291A74E00C8192206CB054C0975D7C7449BA55874AE16BB3F7F45C4960699BE543666830635F1563820D920A58DEACBCF94A94B2C937BC76E9B293E97B7B0EF590CE172C2F32418319FA77A1FBB6C44B8E0C26F6EE8C5235BD36B1F7F1F0BD681FFC86F95F28587EA48E0633820BA8D880A832F6D4E62845D36F634FFF2C38B8E830DA8F02582A589EA48A0633F01DC1064195E1ADD744A9995DC37BB2BE14C44AC1F225353498321C243B7855B0441954AB515A66D8E43D07EFBA88F6A920323D09683045F8678E1DB42AFD6BBF1054C787A38CCCBEE1BDD107D6B782582658FE248E0653822F3AEC605529AF3C3D95E5CEB80D7D28AF3A83F6B12032F9624C8329F892505F84AAB4FCF860F20F2F4629E8BEA12FE813EB6B01205F90372C9F12438309C38F5CAAD7F9438B8FC864B9336E439FD037DA67FF216F903F2CAF124183093A56E4A2BAF2E8E3774629A7AFA16FACCF0581FC411EB1FCEA190D26E46FC43EC10E4A95E12DABA254D3DB86B7ACA47D2F08DC61F61EC1F2AC273498005CF2AAFAAACE9A81DBFE25BC32537D933EA2AFEC180A025791267E29350D26E03AC10E4295FE35E73A5DEE8CDBD0D7BE35FF408FA520703F01CBB7AED1608FCE13ACF3AA94AFFA785029FF214AADFC34F4197D67C7541028E1CEF2AE2B34D88323056E7F631D57A3B4EC3855CB9D715BB83CBAF4587A6C0580FC4AEC1E631AECD23B84FE9D56161F118CBFB03D4AA5FC361C438197479167EF142C0F63A1C12EAD11ACB3AA8CEEDC10A550FE1B2A4DB0632C881B04CBC35868B00BA81DAFFE97DEA14DCBA3D4F1A7E198D8B11600F2ADE73D0B6830A6BF12EA2BB60DACFF463E963BE3362C8FAEFB3A3DE60240DE21FF585E76840663BA51B0CEA9D1B7FA334175A43FCA18FF1A8E0DC7C88EBD00907F2C2F3B428331A01AB0EA9285E5AB3E96CBE5CEB80DC788625D6C0C3C87FCEBBA2A350D7608351F5597282F2D393698D8F74C9422FE371C2B8E998D85E790875DD520A5C10E2D16AC333A2C3ADC8BE5CEB86DECD96D45BDAF18F9C8F2744634D8015C98D42F5847541879E8E628258AD770EC6C4C3C877C8C7DC11C0D7660BD609D506168D3B228158ADB06EF5944C7C673B70996AF6DD1E02C4E146ABFF8A2D460A2E50BF3DA8A5976117989FC64794BD1E02CD46E45DAB7FA1CAF973BE3368C4501CB2E620B5796B7140DCE009B24B337750EA505D32C5F18A7E1CBF7F8730F447F72DB0A5A76B1E3CDBC697006B82981BDA153A525C7A859EEAC2D456A5A829D78F9C9A2955DC48EF62C7F5BD0601BF3047B33B7161D169614D4D0A65FAB8F9D60B4FC0857C0B28BC85796C74D68B00D95B7388E3C785334C56E5BBBCB11345D8631FCC0752DFDF3183EADB03C6E4283C42982BD89532821E8A47CE1F436CBFDBA033F5A103EC6792B5ED945E42DCBE73A1A24EE16EC0D9CD1B4DCD9C925C96A2EC5C6F26871CA2E226F593ED7D1E03473C484606FE0445ABBB574D346776EA47D64461FBB237A96DB365576B110CBA3C85BE42FCBEB100D4EA3AAC283B6E5CE58B7252ABA1D73F28F7B8B527611F9CBF23A44830D709FEF9B82BD70F632DAADA5933655B7F3C3BC9F33D074437E5876D1FFE551E46FDB2B4569B0014A50B017CD9EE2E5CEB834956419FD9FBB681F3DD3B6940A0D367850B017CC9C8BDD5A580B6BF7DF702EED631C780D2D45B90AB02B0DF298E5F78C2700BE3CA8B8D13D2FCB9D71A929CB2863EB79D945E431FD32DC1268B05CB017CB94EBDD5A1ADBF0D6AB691F7BA1EA5F36BF9747E9AE332D81062F0AF6429951B5DC996289722DA5D92BE5FD3E975D7C4EB4E4794B20729C602F92194DBBB54CAD967C88F63311EA56B7BC5D1E6D29A9D8F48706970BF602D92860424C9DF0FF1BBDABDB36BE6787AF65175788A65C6FFA4303A7353EB57C24087F315D793AED631A8AF291CF21E47553AE37FD21F27EC19E9C89A27F290CBFF44F8C46BD70DB3C2DBBF85E51CFF7C6C4AFF9A6604F4C5DB82C58AD44C3EFB0E1AAC91F2FA47DCC82AA65DFF5DFA07DCCB105A29EEF8D895FB359B027A64AD772A7FB1F8686B75D1BF5C66DF3B0ECE23DA29EEF8D890F8788CC77759CBA34607F34E46EDBD8D3F7D13E664EDBA51F579ECAFB993FC86FE4393D018E17EC49A9D1B7DCA9E8E230AC86BDF49BA8776E9B67651791E7F404B840B027A4039707EFD9110DB1DB16564F587122EFA743EA2EFFF6E3BEE20B053D01EE12EC09A950B5DCA9F80691707974B81CF5D66DF3A4EC22F29C9E00AF0AF684C40D6DFE7634A48E1B6E11BC793EEDA326AA6E01BD7729ED638E20CF5B4E00AC8FB207274ED3559079BA497CF0EE8BA38E3B6E7E945D0C7F0F683C01CE16EC81899A2A1332108DA4DB36B2E346DA47CDB454BD0E9747BF3B8FF6312790EF4D27C07F0AF6C0C468BA132AB785A2B03CBA7B4B74146E5BCECB2E22DF9B4E803B047B6022C25281AFEE8E86CE6DC392DEC14B8FA2FDCC03556517F7EDD2B574DCB90DA2E904D82DD8037BA7A81A822FC562C3E5D1D2EFA3A372DB72FAAF6978615CE309302CD8037B36F2D02DD150B96DE1E7D66BCFA67DCC234D651747B6AFA57D540CF95E3F01B0B50C7B50CF545544F370C388811F9E6F2B6ADD7B6FED0448A5F667B876AD6172A479B076DD96AABF64BE7F1EEDA352A7D64E80C4EBFFA8FAE7B9009BC68D3EB23E3A5AB72D676517E7D74E804B1B823D0BBFA01D78351A12B76DFCF95FF872FDCACC342D34FCFFCB79B9AFF8D2DA099058FD4F5D4B74C5DA381AC73AF9C66FA3A377DB725276F1FADA0990CC6F00F89166D7FDD110B86DE135EC57CCE5FDF498AAB28B4FFC84F651910DB513605B43B06BAA7EA6F7EB2EA658FAAEFF9CDD5DD7996DB513E089866077161D1EF47DEFF32A94FFEB13BC8F59917FFAB11A822B5E477EB92618DDB9212C429B252D371985CBA31B2EE0E3E4DE13B513606F43D074A9EFEAB3C2E4AB0EF745B36F0D4D71D9C5976A27C0FE86A089095F3E471FBD5DCD6F1E1A5B75E04D8D6517F7D54E80CC6F84F705FED6D772CBA2F6A6B0EC62B976024C36044D8750354ECB8A4B5EDAF88B0F6B2ABB583F01D8FF3433D054CD226F6DE4E15BE9983A3061274097F065D75A97AD5A55731FB69D005DE8BBEEB3F685B7C736F9FB3D1A2E51A9FF0B60DF0162D0F26B77DE1B2EE566E39BA1FA77005B05EA5069E9DF07D5F191680AADF5D2C23BC9C81867A87E02D8EF001D0A4BBA584BA4E1D26936C619AAFF0EF05243D0CC60F881D5D1F4594BA239FE71ACFE4B70EFD7021504AE70B4965CC3B55B6C9C33F264ED0448E46AD022D052CCD797E6F88B70FD6AD0546B02F964ECC97BA3A9B39644737C0F71FD7E80C4EE08F31DCA295A4BAE95BFF3493ACE19A9DF1196E83DC13E1BDC70613475D67A6DD5A1B2EB1FC3EAF704275E15C257A51527D8AFC009B5B1DD5BE91867A85E15E2D486A099C5F80BBF8CA6D05A2F6D60FD3FD3F1CD50BD2E506A95E17CD47FD379D1145AEBB64DEEFF9D86CBA2EB95E120B5DAA03ED252A23CAF6D60DDD7E9B86608F9FE178D2700AAE5B2071AA274D94941A5FF4FD1745A8BD3B0371C1BD38CB55487B6DF0262EABFE5CB613D4C6B9DB7F1FF7B544BC1AC8DA2E904487D87181FA122326EF0B0367B1B7B765B50BAF4683A8E0EB4EC1093C91E613E1A79F0A6688AADB1561D1B0A867E7EA5B61AAD2D7B8465B64BA4775012F2E99F45D36DADD670B9F3C8AF6E0DCA979FC2C7CDAD965D2221B37D827D535A728C9AA2C06813AF3C259FB71F8BE785EDE18F535D7BFABEB04CFBF0FD574D5DE5B9E8703A560ABC26C29C9F7E0264BA53BC6FC2B2F04A6A0421991527A06B6D778ABF40B027980EF5AD3EC73606D1EF42414F80E3057B828921DC1A4AC9F2E8D0A665B48F05F711414F804384DD209F00249E8AE6E9E6803D407E23CFE90900F709F6441393AEFD12CEA17D2CA09F887ABE37267ECD37057BA2896BD161B641B83E0B443DDF1B13BFE6FD823DD17441DF9E69C7D07E1648B8FE5FD398F88DECC2B80495AF3C554D15E9B01895AE5F64B3145E00D7A8E90F0D2E17EC054C976CDF64152E134DB9DEF487061F16EC054C0F7007948ADB29B16FD75D17D13E7AEE68D194EB4D7F98E645C15EC4F46068D3F2280B1DB7E22D8F3E275AF2BC25D060B9602F647A845D2335345CAC565E7526EDA3879689963C6F0934384C54057B31D38BC547D8F268B690C773444B9EB704A67948B017343D2A2D3B4ECD164B137B776AB94B2B2DC86396DFB39E00562F2845A88C6CCBA399401EB3FC9EF50478873820D88B9A04F4AF3937DC485A431BDE7A0DED63CEBD2990C72CBF673D01C0EA86A62CDC74C39647D382FC65791DA2C169F0E5C1F6104BD9F096955116BA6DF8D7A87FED17681F7308794BBFFCD6D02071B7606F6012847A391A9A47CBA3C85B96CF7534489C22D81B98242D3E225C91D1D0B04285CDC0693FF30379CBF2B98E06DBF8B5606F6212A46907FA9C2F8F3E22581E37A1C136E609F6462661E595A7851F4334B4D1C77F4CFB9803C85796C74D68700638ABD89B9984E18BA82D8F76ED51C1F2B7050DCEE034C1DED0A460F0CE85E1D2A4F356AD844BB5AC8F4A214F59FEB6A0C159EC10EC4D4D0AF0B7AF8696A3E5D10705CB5B8A066771A2A808F6E62605634F6D8ED2D06DAB94F7BBDED87A36B8E80DF9C9F296A2C10EDC2658074C1A2E39D296473B83BC64F9DA160D76005B2A0D08D60993026CCEA7A6ECE29E1D1AB6379A0EF988BC64F9DA160D7668B1601D3129C1AFB37A964755ECF2D208F9C8F2744634D8A1B70BBB6D3263FD37CFD7537671F3B7691F1D401E221F599ECE880663C07293DD35963135BBD25426352C8F22FF4E172C3F67458331FD50B08E99148D6CBF31CA42B7AD3A3210967C617DCC08F28FE565476830A6BF16D8708075CEA445D1AE34B8ABCDD1F228F20EF9C7F2B22334D8854F0BFB2894352C8F6A29BBF8DAEEB00C24ED673A906F1D5DEF33131AECD20D8275D4A448DDAE34D92D8FAE152C0F63A1C12EBD53584D5107FABE3B4F4FD9C5877F40FB98B0E705F28DE5612C34D883A3C490609D3629D2B52BCD72DAC78420BF5A4A1C768B067B64A5541C19FAE99228051DB7CA649A6517BF2C58DE758506136095241CD1B52B4DE2CBA3D70B966F5DA3C104BC55D82D942E60579AE77F11A5A1DB5639F06A9265177133D6DB04CBB7AED16042DE2DECF70107F4ED4AD3F3F228F2E850C1F2AC273498A06385ED3AE940F98AB97ACA2EEEBABF97B28BC81FE411CBAF9ED160C2CE1063821D9C499107BBD2206F903F2CAF12418329F892B05F8A1D18F8D182705546431BFCEFFFA07D6C03F982BC61F994181A4CC9B7043B5093B29CEE4A837C617994281A4C1176E960076B523674EF52F918728B73C35B5675F27D80EEE692061A4CD92AC10EDA18B85AB0BC49050D66C04E02C3202F58BEA4860633B254B04130C594D9C79E463498A185C256878A0DF39FC9175E86063376BE18176C708CDF30EF5F132C2F3241830E9C294A820D92F1137EE1C5BCB37CC80C0D3A826BBC5F116CB08C5FF689C4AEE9EF050D3A840BE8EC2A52BFE1AA4ECC339BFFCCD1A063B894FA7B820D9EC937CC2BE697CDBB1334A804EE2CB3DB2BFD80796CBB59B54B34A808EE31DE25D8A09A7C7846601ED9FC3A4783CAA0E6E3B5C27E2FC817CC17E6ADAB9A9D59A141A53E25EC0EB37C785D60BED83CAA42838ABD4BDC286C871A9D302FDF179827367FEAD0600E7C5CEC116C128C1BBF159817365F6AD1604EE0B3E512613BD5B885F1C73CA8FEACDF0E0DE60CAA05AC13F6B1285B186F8C7B2AD51AB242833975B2C016996CB24CB230CE1F156C1E728506730EBB8560A7703671A63718D7AE7763D188063D81DAF1B8EE844DA489E731D1732D7E8D68D033F868748F98146C720D87F1C2B879F151A71D1AF4D407048AF61E106CC2CD148C0FC609E3C5C6D12B34E8392CD7A1E0D243C22EAF988271C078605C72B99CD92D1A2C900F0ADC8CFD9C6089E13B1C378E1FE3C0C6C77B345850B8627185F07D9B271C1F8E53ED159A59A24133E7EFC405E23E91F7EAD6E83F8E03C783E362C75B5834689A1C224E1217894D02573AB244D302FD433FD15FF4FB2F053B2E2368D0CCEA7DE26C71B1D828768B11C112322D783FBC2FDE1FFD407FD02FD65FD3060D9AAEE1BA98B9E28BE212813DAD3688ADE209F19278431C8CD4AE5FC27F6B31FC7F3C0E8FC7F3F07CBC0E5E0FAF8BD7CFF5F5379AD0A031C530E72D7F068CF79FD77AF9B6C60000000049454E44AE426082
    DECLARE @newIcon VARBINARY( MAX ) = 0x89504E470D0A1A0A0000000D49484452000000C0000000C0080600000052DC6C070000000467414D410000B18F0BFC6105000000097048597300000B1300000B1301009A9C1800000AFF49444154785EED9DCF6E135718C5F3083C82253C94256A1FA0F401CA0B14099674956C62D35590DA4AEC02DDB1A274895421D15D5964018B56AA940D7487BCA08004498610201002EE7C9E6B489C6BFB8E7DFF9C7BEF39D20F29B18927CE773CF7FBE6CCCC826F95CBC5A9B25B2C969DF66AC5ADB27BA2276C758B3EC987C1DFBD53AC57B5B036A805A9896EFBB42A9374542EB58ED5BF5CB156FDE2E5E81B41C808E5C0143F1C3F57765B2D554671498A7EE362715E15BDEE9724C488A1195469614B0A7FB37BE252B5E1FCA427B6E9496DC1EE1558F8C4133DA83D82342E5B6C62897F7ACF4336CDF572A7B8A2D93042BC51F508ABAA24FDA9EC9E6C6D758A75DD061112809EB7DEA05EF270AD4FE070BF2492D1A6E6850981C15983BCD9F96249F78284A0B1D9692FA9B2B5237EF293D8B0B627506B7EED8B1082CCDC3DC160DAC3193F89958EE48AE6980EB1F849F448E274A9754C95B4B978908BA442E383655CF793D468D40F70E9639F72E5CBFE8BCBDF7C42BED63D8F38A3A7CA7BB238F2B4C7CB6B67FBBB77AFF7F71FFFDBD749BE2F8F6F5F39A3FDFFC42E65A7BDA2CA5C2F4E7DEC2085FFFEE1DFAACCCDB4573DFFC5E5D3DA9F472C2153A1490DB1CAF4EBFF3331E2EDBD5F5549CFA637777ED1FE5C6287897B017EFACF8EACE9C72D759AEADD3FBF6B5F835860DC5E806BFFF9B055FC43D104EED0C6247802FBECEC56CB16177A7DFB27EDEB91B95953655FAB6E7EB54F24537055FC43BDBCF69DF675C97C1C5A0671F9331BDB57CFA83275A70F5BFF713AE4806AC5B3A8CA9FCB9F5990A294E2F4A1FDC70F78E0CC3E9F9741D5173CC5B101528CBE8A7F2836C596E914E5A0F899FB69CEDE833BAA2CFD8AC708ECF26CB93825CB9F45DD83448FEBA6779A5EDDEC68B78B3467D00754FFACEA1E244779FDC7CFAA0CC3E9E39B6D36C59690AB52B30136C4C7C4C754D27FB029B640A77D4B1A605EE06A0A3E273EA6DA7BF897765B49237ACCFF4C21C4C4C7546FEF5DD76E3331460CA07D8028424D7C4CC5B8C47CD00013083DF13115E312B343038C0161E2632A59A27132341B348006A4898FA91897980D1A6004C4898FA91897680E0D7000E4898FA9189768060D708079CFE745D1CE8D0BDADF8F1C850650C432F13111E312E6D00015AF6E7655E9A42359CAB1299E4EF606904FCA8FBB2F55D9A425C625A693B501629EF8988A7189C9646D00DB97324115E312E3C9D600A94C7C4CB57DE55BEDFB903B591A20A5898FA91897D0939D01766E7CAF4A223F312E7194AC0C90F2C4C7548C4B1C261B03E430F13115E3129FC9C600B94C7C4CC5B8444D1606C86DE26322C6256A9237408E131F53312E91B801D0263E1FB61E5586BCAABEC250EE7189640D8038F19133CD64DBD04C90735C224903204E7C5EDFFEF1D036CA381249B9C625923440D33B34BAD69BEA137F741BCB4B5FF5F79F604DA6728C4B246700B4A677D21ABBDE533D52CF0CAF1CE312491900ADF8A5B8A715945CD30749B9C525923100DAA54C4C8A7F88ACBF9194535C2209032036BD4DAFD6B60B76B02E97B844F40640BC9489AEE935E17DD52F202987B844F40640BB78EDEEDDD967EA684D710E7189A80D80D6F44A03A9DBCE26482F8374002FF5B844B40640BB786D93A6771A721F3024A51C9788D20068139F8FBBF6970A8C4BF8213A03204E7C5C358B8C4BB8272A03A434F13141E212484DB128B5B84454064869E2638AECF1D09AE2942643D11820C5898F298C4BB8230A03A43CF13185710937C01B2087898F298C4BD807DA00394D7C4C413B8720F63B54C21A20B7898F29F58702E312B6803500DAA54C7C4C7C4C615CC21E9006403CB145B79D21615CC20E700640BB5D5188898F298C4BCC0F9401A4D09076ED21273EA6A01D1C8C2D2E016380BAB9C36A7A472F6582085A5C429AE298E212300640BB782DC2C4C714B43D674C71090803A04D7C6459A1DB4E641897988DE006409CF8C43AD2635CA239410D8078F1DA5876DDE3605CA219C10C80B66E15C90126DDB6C606E312E6043100273E6EA9DF5FC6254C0862004E7CDCC3B88419DE0DC0898F3F1897988E570370E2E31FB4B8045A53ECCD009CF884032D2E217B26DD7686C08B0138F1090BE312E3716E004E7C3040FB1042894B3837400CB72BCA05C6258EE2D400684D6FCA131F53D0E212A1CF217066004E7C70418B4B843C87C09901647DE713D9BD4F02A9F85F5CFEA6DAA6B383B3DF5C23D33779AD83C8F7D08612F237D2BD57AE71DE03901A293C39B11E6D2080A25071091AC031F247451B04A02A445C820670885CD2116DA9812EDF71091AC01168438098E4332E41033800ED62BE31CA575C8206B08CACF9A9F9E5AB29A6012CC3298F3DF9E80768008BC8DC9DB22BD7C70768008BF0D3DFBE5CEF0568004BC8812ECA8D5CF60234802538F971279759211AC0127BF7B1CEBA4A496F1D5E608B06B004E30EEEE4B20FA0012CC106D89DE4BDD5BDE736A0012C4103B8130D10015C02B913974011208D1AE546EFEEFFA97DCF6D40035882635077E2183402E4DA3B941BF1405824BCAFD6AA945DED3F79A07DAF6D41035844825B945DB93E2F8006B00CF702F62497B2D1BDC736A1012C23EB559E076C473C212652D0AEBE16A37C5DBF95067004DAD5D76292CFEBB7D2000E613FD04C1F77B7FB3B372E68DF4B57D0000E41BB2E3FB2E4C2C53ED6FCA3D0008E61533C5EF2E120CB9D9037CBA0013CB0F31BD6EDA186776811739A30BCC0B02DE4EE3C28172BA6013C8176B33ADF9720448506F0C83BB0C468E89B5320400378449AE2FD275837090F79730A046800CFC89A1A6D328472C7C610D000019026104972CAA11853B7ADA9430304022D2E8170C7C610D00001418B4B4893AEDBCE94A10102831697F079730A046880C020C625E460956E5B53840600401A50A4B844A83B3686800600012D2E2193A11C9A621A0008C625FC43038081169748BD29A601C0408C4BF8BA636308680040D0E212C3F8B46E5B638706008571093FD000C020C62574DB1933340038687189D4CE21A00122002D2E91D23904344004302EE10E1A2012189770030D10118C4BD88706880CB8B884C3DB17F980068810C625EC41034408E312F6A001228571093BD0001123A34824C51897A00122072D2E11DB3904344002302E313B344022302E311B344022302E311B344042A0C52562688A6980C490793C92D02FB95819E0444FF7008917B4B804F025177B3440A2302E6140A7585F28BBED5BDA0749D420C6257CDF02753AEDB5CA00C5AAFE41123B684D31DA390465A7BD2A0658D43D48D200312E81D2144BED2F94CBC529DD83241D1897D0532EB7BF5E10555F94A30F92B4605C62844E510E8A5F547D63EDC8134872302E7190AA011E8A7D401E48038A169708750E41D9397E4E957F658095D631DD93487AC82517199728FA4FBBAD962AFF5AD537B90CCA04C6250E2C7F86DA582ECEEB9F4C5224E7B8C4A1E5CF506A19C4695046641A97E8A9923FAAB2D35ED1FC079228399E43B059D5B82AF7A3E25E203F328B4BF48E34BFA3E25E203FE45357F60436B021577109EDDA5F2746A449828C5FFB8FEA79B77D5AF3030889964FB91F536D32264D12A16A7C5755599B4B35C4EBA33F8C90C8305FFA8CEA69F764ABFA019C0A9158993EF59926F60324561AAFFBC769E3226312242E364C479EA6AA1A8925DD0B1182C6A69CEAE842DC131074AC7FF28FAAEE0978A08CC0515A5BF34F533D1DA20908089D627DEE69CF2CE2C132121A39C8D55B6A1D5325E95F5C129140F4BC2D794C549F51462310E7941333FD2125BD816C1C8D401C3028FCA0CB9D26AAF7086D9E684FE6A4BD2639FE680A7F54B257386006E68AC834AA1AA98ABE5B2C465BF493248D8BFC72D2BD2B5348E2944BA6FC90BF7945FB96D482D4C4B3E5E2942A134F5A58F81F9905C6FAE952D5C20000000049454E44AE426082

    UPDATE bfd
    SET Content = @oldIcon
    FROM
        [dbo].[Site] s
        INNER JOIN[BinaryFile] bf ON bf.Id = s.FavIconBinaryFileId

        INNER JOIN[BinaryFileData] bfd ON bfd.Id = s.FavIconBinaryFileId
    WHERE bfd.Content = @newIcon" );
        }

        /// <summary>
        /// JDR: Add the UpdatePersistedDataset job to ServiceJobs out of the box
        /// If the job is already there, update the cron expression to run every minute
        /// </summary>
        private void AddUpdatePersistedDatasetServiceUp()
        {
            Sql( $@"
          IF NOT EXISTS (
              SELECT 1
              FROM [ServiceJob]
              WHERE [Guid] = '{SystemGuid.ServiceJob.UPDATE_PERSISTED_DATASETS}'
          )
          BEGIN
              INSERT INTO [ServiceJob] (
                  [IsSystem],
                  [IsActive],
                  [Name],
                  [Description],
                  [Class],
                  [CronExpression],
                  [NotificationStatus],
                  [Guid]
              ) VALUES (
                  1, -- IsSystem
                  1, -- IsActive
                  'Update Persisted Datasets', -- Name
                  'This job will update persisted datasets.', -- Description
                  'Rock.Jobs.UpdatePersistedDatasets', -- Class
                  '0 * * * * ?', -- CronExpression to run every minute
                  1, -- NotificationStatus
                  '{SystemGuid.ServiceJob.UPDATE_PERSISTED_DATASETS}' -- Guid
              );
          END
          ELSE
          BEGIN
              -- Update the cron expression if the job already exists
              UPDATE [ServiceJob]
              SET [CronExpression] = '0 * * * * ?' -- CronExpression to run every minute
              WHERE [Guid] = '{SystemGuid.ServiceJob.UPDATE_PERSISTED_DATASETS}';
          END" );

        }
    }
}
