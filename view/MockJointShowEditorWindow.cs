using System;
using System.Windows.Forms;
using BridgePresenter.Model;

namespace BridgePresenter.View
{
    public class MockJointShowEditorWindow : BaseJointShowEditorWindow
    {
        public MockJointShowEditorWindow(IJointShow showModel)
            : base(showModel)
        {
        }

        public MockJointShowEditorWindow()
            : base(null)
        {
        }

        public override string ShowName
        {
            get { throw new NotImplementedException(); }
        }

        protected override DataGridView ShowOrderView
        {
            get { throw new NotImplementedException(); }
        }

        protected override DataGridView ImportedShowsView
        {
            get { throw new NotImplementedException(); }
        }

        public override void CloseWindow()
        {
            throw new NotImplementedException();
        }

        public override string[] PromptForPresentationsToImport()
        {
            throw new NotImplementedException();
        }

        public override void ShowWindow()
        {
            throw new NotImplementedException();
        }
    }
}
