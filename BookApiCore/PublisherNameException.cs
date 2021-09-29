using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApiCore
{
    [Serializable]
    public class PublisherNameException : Exception
    {
        public string PublisherName { get; set; }

        public PublisherNameException()
        {

        }

        public PublisherNameException(string message): base(message)
        {

        }

        public PublisherNameException(Exception inner,string message) : base(message, inner)
        {

        }
        public PublisherNameException(string message, string publisherName) : this(message) 
        {
            PublisherName = publisherName;
        }
    }
}
