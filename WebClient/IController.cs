using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReaderController" in both code and config file together.
    [ServiceContract]
    public interface IController
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        void resetResponse();

        [OperationContract]
        void StartReader(string clientIP);

        [OperationContract]
        string ReadData(string clientIP);

        [OperationContract]
        string[] StartFingerPrint(String[] minutiaCompareList, bool useLFD);

        [OperationContract]
        string[] StartFingerPrintServer(String[] minutiaCompareList);

        [OperationContract]
        bool buildMinData(String minData);

        [OperationContract]
        String[] readMinData();
    }
}