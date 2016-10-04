using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PushService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPushService
    {

        [OperationContract]
        void Register(string strURI);

        [OperationContract]
        void Unregister(string strURI);

        [OperationContract]
        void SendToastNotification(string strTitle, string strSubtitle);

        [OperationContract]
        void SendTileNotification(int nCount, string strTitle, string strBackground);

        [OperationContract]
        void SendRawNotification(string strMessage);
    }
}
