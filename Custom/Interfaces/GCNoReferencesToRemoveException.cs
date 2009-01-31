using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.Interfaces
{
	public class GCNoReferencesToRemoveException :ApplicationException 
	{
		

		        public GCNoReferencesToRemoveException()
        {         }

        public GCNoReferencesToRemoveException(string message)
            :base(message)
				{  }

		public GCNoReferencesToRemoveException(string message, Exception inner)
            : base(message, inner)
		{  }
	}
}
