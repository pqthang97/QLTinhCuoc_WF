namespace QLCuocDT
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnNew = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBtnKhachHang = new DevExpress.XtraNavBar.NavBarItem();
            this.navBtnSim = new DevExpress.XtraNavBar.NavBarItem();
            this.navBtnRegister = new DevExpress.XtraNavBar.NavBarItem();
            this.btnBillCharge = new DevExpress.XtraNavBar.NavBarItem();
            this.btnImport = new DevExpress.XtraNavBar.NavBarItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barBtnNew,
            this.barBtnUpdate,
            this.barBtnDelete,
            this.barBtnRefresh});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1091, 150);
            // 
            // barBtnNew
            // 
            this.barBtnNew.Caption = "Thêm mới";
            this.barBtnNew.Id = 1;
            this.barBtnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnNew.ImageOptions.Image")));
            this.barBtnNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnNew.ImageOptions.LargeImage")));
            this.barBtnNew.Name = "barBtnNew";
            this.barBtnNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnNew_ItemClick);
            // 
            // barBtnUpdate
            // 
            this.barBtnUpdate.Caption = "Cập nhật";
            this.barBtnUpdate.Id = 2;
            this.barBtnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnUpdate.ImageOptions.Image")));
            this.barBtnUpdate.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnUpdate.ImageOptions.LargeImage")));
            this.barBtnUpdate.Name = "barBtnUpdate";
            this.barBtnUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnUpdate_ItemClick);
            // 
            // barBtnDelete
            // 
            this.barBtnDelete.Caption = "Xóa";
            this.barBtnDelete.Id = 3;
            this.barBtnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnDelete.ImageOptions.Image")));
            this.barBtnDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnDelete.ImageOptions.LargeImage")));
            this.barBtnDelete.Name = "barBtnDelete";
            this.barBtnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnDelete_ItemClick);
            // 
            // barBtnRefresh
            // 
            this.barBtnRefresh.Caption = "Làm mới";
            this.barBtnRefresh.Id = 4;
            this.barBtnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtnRefresh.ImageOptions.Image")));
            this.barBtnRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtnRefresh.ImageOptions.LargeImage")));
            this.barBtnRefresh.Name = "barBtnRefresh";
            this.barBtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnRefresh_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Chức năng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnUpdate);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtnRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tác vụ";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBtnKhachHang,
            this.navBtnSim,
            this.navBtnRegister,
            this.btnBillCharge,
            this.btnImport});
            this.navBarControl1.Location = new System.Drawing.Point(0, 150);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 177;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(177, 564);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Danh mục";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBtnKhachHang),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBtnSim),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBtnRegister),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnBillCharge),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnImport)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBtnKhachHang
            // 
            this.navBtnKhachHang.Caption = "Khách hàng";
            this.navBtnKhachHang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBtnKhachHang.ImageOptions.LargeImage")));
            this.navBtnKhachHang.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBtnKhachHang.ImageOptions.SmallImage")));
            this.navBtnKhachHang.Name = "navBtnKhachHang";
            this.navBtnKhachHang.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBtnKhachHang_LinkClicked);
            // 
            // navBtnSim
            // 
            this.navBtnSim.Caption = "Thông tin Sim";
            this.navBtnSim.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBtnSim.ImageOptions.SmallImage")));
            this.navBtnSim.Name = "navBtnSim";
            this.navBtnSim.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBtnSim_LinkClicked);
            // 
            // navBtnRegister
            // 
            this.navBtnRegister.Caption = "Hóa đơn đăng ký";
            this.navBtnRegister.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBtnRegister.ImageOptions.SmallImage")));
            this.navBtnRegister.Name = "navBtnRegister";
            this.navBtnRegister.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBtnRegister_LinkClicked);
            // 
            // btnBillCharge
            // 
            this.btnBillCharge.Caption = "Hóa đơn tính cước";
            this.btnBillCharge.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBillCharge.ImageOptions.LargeImage")));
            this.btnBillCharge.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnBillCharge.ImageOptions.SmallImage")));
            this.btnBillCharge.Name = "btnBillCharge";
            this.btnBillCharge.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnBillCharge_LinkClicked);
            // 
            // btnImport
            // 
            this.btnImport.Caption = "Nhập chi tiết cước";
            this.btnImport.ImageOptions.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnImport.ImageOptions.SmallImage")));
            this.btnImport.Name = "btnImport";
            this.btnImport.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnImport_LinkClicked);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 714);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Quản lý tính cước điện thoại";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBtnKhachHang;
        private DevExpress.XtraNavBar.NavBarItem navBtnSim;
        private DevExpress.XtraNavBar.NavBarItem navBtnRegister;
        private DevExpress.XtraBars.BarButtonItem barBtnNew;
        private DevExpress.XtraBars.BarButtonItem barBtnUpdate;
        private DevExpress.XtraBars.BarButtonItem barBtnDelete;
        private DevExpress.XtraBars.BarButtonItem barBtnRefresh;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraNavBar.NavBarItem btnBillCharge;
        private DevExpress.XtraNavBar.NavBarItem btnImport;
    }
}

