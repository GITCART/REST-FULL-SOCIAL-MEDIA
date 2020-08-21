using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.Exceptions
{
    public class BusnissException: Exception
    {
        public BusnissException()
        {

        }

        public BusnissException(string message): base(message) { }



    }
}
