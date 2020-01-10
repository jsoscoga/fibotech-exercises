using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFImage
{
    /// <summary>
    /// Interface where WebService methods are declared
    /// </summary>
    [ServiceContract]
    public interface IUploadImage
    {

        [OperationContract]
        string Upload(byte[] imageFile, string fileName);
    }
}
