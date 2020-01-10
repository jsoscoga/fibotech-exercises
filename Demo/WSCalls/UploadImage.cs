using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.WSCalls
{
    /// <summary>
    /// Class for calling to WS UploadImage by reference
    /// </summary>
    public class UploadImage
    {
        /// <summary>
        /// Returns a response in JSON formatted
        /// </summary>
        /// <param name="imageBase64"></param>
        /// <param name="fileName"></param>
        /// <returns>string</returns>
        public static string Upload(byte[] imageBase64, string fileName)
        {
            // Creation of WCF Instance
            UploadImageReference.UploadImage uploading = new UploadImageReference.UploadImage();

            // Returning a WCF Instance response in JSON formatted
            return uploading.Upload(imageBase64, fileName);
        }
    }
}