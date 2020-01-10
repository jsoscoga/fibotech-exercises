using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.ViewModels
{
    /// <summary>
    /// Class for returning to Views
    /// </summary>
    public class ImageViewModel
    {
        public string RelativePath { get; set; }
        public List<Face> Faces { get; set; }
    }
}