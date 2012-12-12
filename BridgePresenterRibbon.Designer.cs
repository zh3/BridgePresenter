namespace BridgePresenter
{
    partial class BridgePresenterRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public BridgePresenterRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.bridgePresenter = this.Factory.CreateRibbonGroup();
            this.jointSlideShowMenu = this.Factory.CreateRibbonMenu();
            this.setupJointShowsButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.bridgePresenter.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.bridgePresenter);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // bridgePresenter
            // 
            this.bridgePresenter.Items.Add(this.jointSlideShowMenu);
            this.bridgePresenter.Label = "Bridge Presenter";
            this.bridgePresenter.Name = "bridgePresenter";
            // 
            // jointSlideShowMenu
            // 
            this.jointSlideShowMenu.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.jointSlideShowMenu.Items.Add(this.setupJointShowsButton);
            this.jointSlideShowMenu.ItemSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.jointSlideShowMenu.Label = "Joint Slide Show";
            this.jointSlideShowMenu.Name = "jointSlideShowMenu";
            this.jointSlideShowMenu.OfficeImageId = "SlideShowCustomMenu";
            this.jointSlideShowMenu.ShowImage = true;
            // 
            // setupJointShowsButton
            // 
            this.setupJointShowsButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.setupJointShowsButton.Label = "Joint Shows...";
            this.setupJointShowsButton.Name = "setupJointShowsButton";
            this.setupJointShowsButton.OfficeImageId = "SlideShowCustomMenu";
            this.setupJointShowsButton.ShowImage = true;
            this.setupJointShowsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.setupJointShowsButton_Click);
            // 
            // BridgePresenterRibbon
            // 
            this.Name = "BridgePresenterRibbon";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.BridgePresenterRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.bridgePresenter.ResumeLayout(false);
            this.bridgePresenter.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup bridgePresenter;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu jointSlideShowMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton setupJointShowsButton;
    }

    partial class ThisRibbonCollection
    {
        internal BridgePresenterRibbon Ribbon1
        {
            get { return this.GetRibbon<BridgePresenterRibbon>(); }
        }
    }
}
