using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSImage
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFileUploader" in both code and config file together.
    [ServiceContract]
    public interface IFileUploader
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UploadImage")]
        string UploadImageFile(byte[] imageFile, string fileName);
    }
}
