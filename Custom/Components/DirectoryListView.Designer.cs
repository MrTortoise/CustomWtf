namespace Custom.Components
{
	partial class DirectoryListView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryListView));
			this.mListView = new System.Windows.Forms.ListView();
			this.LargeImageList = new System.Windows.Forms.ImageList(this.components);
			this.smallImageList = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mListView
			// 
			this.mListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mListView.LargeImageList = this.LargeImageList;
			this.mListView.Location = new System.Drawing.Point(5, 34);
			this.mListView.Margin = new System.Windows.Forms.Padding(4);
			this.mListView.Name = "mListView";
			this.mListView.Size = new System.Drawing.Size(289, 374);
			this.mListView.SmallImageList = this.smallImageList;
			this.mListView.TabIndex = 0;
			this.mListView.UseCompatibleStateImageBehavior = false;
			// 
			// LargeImageList
			// 
			this.LargeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargeImageList.ImageStream")));
			this.LargeImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.LargeImageList.Images.SetKeyName(0, "Monitor.png");
			this.LargeImageList.Images.SetKeyName(1, "Image_File.png");
			this.LargeImageList.Images.SetKeyName(2, "Generic_Document.png");
			this.LargeImageList.Images.SetKeyName(3, "generic_picture.png");
			this.LargeImageList.Images.SetKeyName(4, "Folder_Back.png");
			// 
			// smallImageList
			// 
			this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
			this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.smallImageList.Images.SetKeyName(0, "Monitor.png");
			this.smallImageList.Images.SetKeyName(1, "Image_File.png");
			this.smallImageList.Images.SetKeyName(2, "Generic_Document.png");
			this.smallImageList.Images.SetKeyName(3, "generic_picture.png");
			this.smallImageList.Images.SetKeyName(4, "Folder_Back.png");
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(301, 27);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(96, 24);
			this.toolStripButton1.Text = "Toggle View";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// DirectoryListView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.mListView);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DirectoryListView";
			this.Size = new System.Drawing.Size(301, 416);
			this.Resize += new System.EventHandler(this.DirectoryListView_Resize);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView mListView;
		private System.Windows.Forms.ImageList smallImageList;
		private System.Windows.Forms.ImageList LargeImageList;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;

	}
}
