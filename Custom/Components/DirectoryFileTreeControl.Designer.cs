namespace Custom.Components
{
	partial class DirectoryFileTreeControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryFileTreeControl));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.tsNode = new System.Windows.Forms.ToolStripDropDownButton();
			this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNode});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(247, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.treeView1.ImageIndex = 1;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(3, 28);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.Size = new System.Drawing.Size(241, 346);
			this.treeView1.TabIndex = 1;
			// 
			// tsNode
			// 
			this.tsNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsNode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandAllToolStripMenuItem,
            this.collapseAllToolStripMenuItem});
			this.tsNode.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsNode.Name = "tsNode";
			this.tsNode.Size = new System.Drawing.Size(83, 22);
			this.tsNode.Text = "Node Control";
			// 
			// expandAllToolStripMenuItem
			// 
			this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
			this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.expandAllToolStripMenuItem.Text = "Expand All";
			// 
			// collapseAllToolStripMenuItem
			// 
			this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
			this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.collapseAllToolStripMenuItem.Text = "Collapse All";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "Folder_Open.png");
			this.imageList1.Images.SetKeyName(1, "Folder_Closed.png");
			// 
			// imageList2
			// 
			this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// DirectoryFileTreeControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "DirectoryFileTreeControl";
			this.Size = new System.Drawing.Size(247, 377);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ToolStripDropDownButton tsNode;
		private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ImageList imageList2;
	}
}
