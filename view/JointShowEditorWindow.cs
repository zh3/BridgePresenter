﻿using BridgePresenter.Model;

namespace BridgePresenter.View
{
    // Designer can't support abstract class 1 level up in hierarchy. Use workaround.
#if DEBUG
    public partial class JointShowEditorWindow : MockJointShowEditorWindow
#else
    public partial class JointShowEditorWindow : BaseJointShowEditorWindow
#endif
    {


        public JointShowEditorWindow(IJointShowModel model) : base(model)
        {
            InitializeComponent();
        }
    }
}