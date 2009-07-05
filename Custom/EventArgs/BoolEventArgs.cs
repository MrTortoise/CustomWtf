using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.EventArguments
{
	class BoolEventArgs   : EventArgs 
	{
		protected bool mOldValue;
		protected bool mNewValue;

		public BoolEventArgs(bool theOldValue, bool theNewValue)
		{
			mOldValue = theOldValue;
			mNewValue = theNewValue;
		}

		public bool OldValue
		{
			get { return mOldValue; }
			set { mOldValue = value; }
		}

		public bool NewValue
		{
			get { return mNewValue; }
			set { mNewValue = value; }
		}
	}
}
