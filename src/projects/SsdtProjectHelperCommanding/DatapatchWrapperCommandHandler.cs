// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using DatapatchWrapper;
using Microsoft.VisualStudio.Commanding;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace SsdtProjectHelperCommanding
{
    [Export(typeof(ICommandHandler))]
    [ContentType("text")]
    [Name(nameof(DatapatchWrapperCommandHandler))]
    public class DatapatchWrapperCommandHandler : ICommandHandler<DatapatchWrapperCommandArgs>
    {
        public string DisplayName => "Wrap sql script as datapatch";

        [Import]
        private readonly IEditorOperationsFactoryService _editorOperations = null;

        public CommandState GetCommandState(DatapatchWrapperCommandArgs args)
        {
            return !args.SubjectBuffer.ContentType.IsOfType("SQL Server Tools") ? CommandState.Unavailable : CommandState.Available;
        }

        public bool ExecuteCommand(DatapatchWrapperCommandArgs args, CommandExecutionContext context)
        {
            using (context.OperationContext.AddScope(allowCancellation: false, description: "Wrapping. Producing datapatch structure..."))
            {
                IEditorOperations editorOperations = _editorOperations.GetEditorOperations(args.TextView);
                DatapatchBuilder.WrapScriptAsDatapatch(editorOperations);
            }

            return true;
        }
    }
}
