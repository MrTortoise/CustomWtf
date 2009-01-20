using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Custom.Components;


namespace Custom.Components
{
	public partial class DirectoryListView : UserControl
	{
		public enum ItemType
		{
			file,
			folder
		};

		public DirectoryListView()
		{
			InitializeComponent();
			
		}

		private void btnViewToggle_Click(object sender, EventArgs e)
		{
		
		}

		public void AddItem(string value, ItemType theItemType)
		{
			switch (theItemType)
			{
				case ItemType.file:
					mListView.Items.Add(new ListViewItem(value,2));
					break;
				case ItemType.folder:
					mListView.Items.Add(new ListViewItem(value,4));
					break;
			}
		}

		private void toggleViewToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			switch (mListView.View)
			{
				case View.Details:
					mListView.View = View.LargeIcon;
					break;
				case View.LargeIcon:
					mListView.View = View.List;
					break;
				case View.List:
					mListView.View = View.SmallIcon;
					break;
				case View.SmallIcon:
					mListView.View = View.Tile;
					break;
				case View.Tile:
					//	mListView.View = View.Details;
					mListView.View = View.LargeIcon;
					break;
			}	
		}


	}
}
