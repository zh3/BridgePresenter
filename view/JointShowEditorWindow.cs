using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgePresenter
{
    // Designer can't support abstract class 1 level up in hierarchy. Use workaround.
#if DEBUG
    public partial class JointShowEditorWindow : MockJointShowEditorWindow
#else
    public partial class JointShowEditorWindow : BaseJointShowEditorWindow
#endif
    {
        public JointShowEditorWindow()
        {
            InitializeComponent();
        }
    }
}
