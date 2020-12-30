// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.Commanding;

namespace SsdtProjectHelperCommanding
{
    [SuppressMessage("NDepend", "ND1207:NonStaticClassesShouldBeInstantiatedOrTurnedToStatic", Justification = "Used by MEF")]
    public class DatapatchWrapperCommandArgs : EditorCommandArgs
    {
        public DatapatchWrapperCommandArgs(ITextView textView, ITextBuffer textBuffer)
            : base(textView, textBuffer)
        {
        }
    }
}
