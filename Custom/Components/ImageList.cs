using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Custom.Components
{
	public partial class ImageList : Component
	{
		public ImageList()
		{
			InitializeComponent();
			imageList1.ColorDepth = ColorDepth.Depth32Bit;
		}

		public ImageList(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public Size ImagesSize
		{
			get{
				return imageList1.ImageSize;
			}
			set{
				imageList1.ImageSize=value;
			}
		}

		public System.Windows.Forms.ImageList GetImageList
		{
			get
			{
				return imageList1;
			}
		}

		public void SetImageList(System.Windows.Forms.ImageList.ImageCollection images)
		{
			foreach (Image i in images)
			{
				imageList1.Images.Add(i);
			}			
		}
	}
}
