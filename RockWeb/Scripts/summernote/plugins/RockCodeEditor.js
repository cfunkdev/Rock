﻿var RockCodeEditor = function (context, keepEditorContent) {
    var ui = $.summernote.ui;
    initializeCodeEditor(context);

    function initializeCodeEditor(context) {
        // Prevent CodeEditor from being repeatedly re-initialized
        if (typeof context.options.codeEditorOptions.initialized === 'undefined') {
            var $codeEditor = $('#codeeditor-div-' + context.options.codeEditorOptions.controlId);
            var $codeEditorContainer = $codeEditor.closest('.code-editor-container');
            $codeEditorContainer.hide();

            var $inCodeEditorModeHiddenField = $('#' + context.options.codeEditorOptions.inCodeEditorModeHiddenFieldId);
            $inCodeEditorModeHiddenField.val("0");
            // move code editor into summernote div
            var element = $codeEditorContainer.detach();
            context.layoutInfo.editingArea.closest('.note-editor').append(element);
            context.options.codeEditorOptions.initialized = true;
        }
    }

    // create button
    var button = ui.button({
        contents: '<i class="fa fa-code"/>',
        tooltip: 'Code Editor',
        className: 'btn-codeview note-codeview-keep', // swap out the default btn-codeview with the RockCodeEditor
        click: function () {

            var $codeEditor = $('#codeeditor-div-' + context.options.codeEditorOptions.controlId);
            var $codeEditorContainer = $codeEditor.closest('.code-editor-container');
            var $inCodeEditorModeHiddenField = $('#' + context.options.codeEditorOptions.inCodeEditorModeHiddenFieldId);

            if ($codeEditorContainer.is(':visible')) {
                // toggle to WYSIWYG mode (unless there are lava commands)

                context.invoke('toolbar.updateCodeview', true);

                /*
                    KA 06-JUN-2022:
                    context.code() is checked first because of a well known issue with summernote where the code property is not updated with the current text content when in code editor mode https://github.com/summernote/summernote/issues/94,
                    thus when used in conjuction with Rock.controls.emailEditor.textComponentHelper, we can't always rely on ace.edit($codeEditor.attr('id')).getValue() to return the current value. But since Rock.controls.emailEditor.textComponentHelper updates
                    the code property everytime the user switches betwen text components we first call context.code(), if it has any value other than the default value we use that instead, if not then we fall back to ace.edit($codeEditor.attr('id')).getValue()                    
                */
                let content = context.code();
                if (content == '<p><br></p>') {
                    content = ace.edit($codeEditor.attr('id')).getValue();
                }

                // check if there are lava commands
                var hasLavaCommandsRegEx = /{%.*%\}/;

                var hasLavaCommands = hasLavaCommandsRegEx.test(content);

                if (!hasLavaCommands) {
                    $('.js-wysiwyg-warning').hide();
                    context.code(content);
                    context.layoutInfo.editingArea.show();
                    context.layoutInfo.editor.removeClass('code-editor-visible');
                    context.layoutInfo.statusbar.show();
                    $codeEditorContainer.hide();
                    $inCodeEditorModeHiddenField.val("0");
                    context.invoke('toolbar.updateCodeview', false);
                } else {
                    if ($('.js-wysiwyg-warning').length == 0) {
                        var $warning = $('<div class="alert alert-warning js-wysiwyg-warning"><button class="close" aria-hidden="true" type="button" data-dismiss="alert"><i class="fa fa-times"></i></button>The markup contains content that may not be compatible with the visual editor.</div>');
                        $warning.insertBefore(context.layoutInfo.editor);
                    }

                    $('.js-wysiwyg-warning').show();
                }
            } else {
                // toggle to CodeEditor mode
                $codeEditorContainer.height(context.layoutInfo.editingArea.height());

                // make sure it has at least some usable height
                if ($codeEditorContainer.height() < 100) {
                    $codeEditorContainer.height(100)
                }

                context.layoutInfo.editingArea.hide();
                context.layoutInfo.editor.addClass('code-editor-visible');
                context.layoutInfo.statusbar.hide();

                // HtmlEditor.cs will initialize this with keepEditorContent = true and set the codeEditor content instead of the summernoteNote editor content
                // this will prevent bad html or scripts from trying to render when startInCodeEditor mode is enabled
                if (!keepEditorContent) {
                    let content = context.code();
                    var editor = ace.edit($codeEditor.attr('id'));
                    editor.setValue(content);
                    editor.resize();
                }
                $codeEditorContainer.show();

                // set the hiddenfield so we know which editor to get the value from on postback
                $inCodeEditorModeHiddenField.val("1");
                context.invoke('toolbar.updateCodeview', true);
            }
        }
    });

    return button.render();   // return button as jquery object
}
