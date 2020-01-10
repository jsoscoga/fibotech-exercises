using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WSImage
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FileUploader" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FileUploader.svc or FileUploader.svc.cs at the Solution Explorer and start debugging.
    public class FileUploader : IFileUploader
    {

        public string UploadImageFile(byte[] imageFile, string fileName)
        {
            return "Hecho";
        }
    }
}
