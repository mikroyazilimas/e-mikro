using E_Mikro.Models.Contentful.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Mikro.Models.Contentful
{
    public class Video : ContentfulBaseModel
    {
        public string Title { get; set; }
        public Media VideoFile { get; set; }
        public string VideoUrl { get; set; }
        public Media VideoPoster { get; set; }
        public int Order { get; set; }
    }
}