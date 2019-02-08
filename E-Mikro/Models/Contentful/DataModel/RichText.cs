using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful.DataModel
{
    public class RichText
    {
        public object Data { get; set; }
        public List<RichTextContent> Content { get; set; }
        public string NodeType { get; set; }
    }

    public class RichTextContent
    {
        public object Marks { get; set; }
        public DataTarget Data { get; set; }
        public string Value { get; set; }
        public string NodeType { get; set; }
    }
}