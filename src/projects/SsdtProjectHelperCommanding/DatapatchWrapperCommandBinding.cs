/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using Microsoft.VisualStudio.Editor.Commanding;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;

namespace SsdtProjectHelperCommanding
{
    [SuppressMessage("NDepend", "ND1207:NonStaticClassesShouldBeInstantiatedOrTurnedToStatic", Justification = "Used by MEF")]
    public class DatapatchWrapperCommandBinding
    {
        private const int DatapatchWrapperCommandId = 0x0100;
        private const string DatapatchWrapperCommandSet = "2b5c526e-368f-47c2-81e3-3ea1eb7c79c7";

        [Export]
        [CommandBinding(DatapatchWrapperCommandSet, DatapatchWrapperCommandId, typeof(DatapatchWrapperCommandArgs))]
        [SuppressMessage("NDepend", "ND1805:FieldsShouldBeDeclaredAsPrivate", Justification = "Used by MEF")]
        [SuppressMessage("NDepend", "ND1702:PotentiallyDeadFields", Justification = "Used by MEF")]
        [SuppressMessage("NDepend", "ND1802:FieldsThatCouldHaveALowerVisibility", Justification = "Used by MEF")]
        internal CommandBindingDefinition _datapatchWrapperCommandBinding;
    }
}
