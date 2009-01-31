using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.Interfaces
{
	public class GCObjectStillHasReferencesException   :ApplicationException 
	{

			

		public GCObjectStillHasReferencesException()
        {         }

		public object SouceObject
		{ get { return Source; } }

        public GCObjectStillHasReferencesException(string message)
            :base(message)
				{  }

		public GCObjectStillHasReferencesException(string message, Exception inner)
            : base(message, inner)
		{  }
	}
}
