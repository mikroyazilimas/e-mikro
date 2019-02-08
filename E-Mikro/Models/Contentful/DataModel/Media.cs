using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful.DataModel
{
    public class Media : ContentfulBaseModel
    {
        public MediaItem Fields { get; set; }
    }

    public class MediaItem
    {
        public string Title { get; set; }
        public FileInfo File { get; set; }
    }

    public class FileInfo
    {
        public string Url { get; set; }
        public FileDetail Details { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }

    public class FileDetail
    {
        public int Size { get; set; }
        public FileSize Image { get; set; }
    }

    public class FileSize
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}