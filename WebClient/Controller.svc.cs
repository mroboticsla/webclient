using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReaderController" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReaderController.svc or ReaderController.svc.cs at the Solution Explorer and start debugging.
    public class BMController : IController
    {
        public void DoWork()
        {
            
        }

        public void resetResponse()
        {
            AsynchronousClient.resetResponse();
        }

        public void StartReader(string clientIP)
        {
            AsynchronousClient.StartClient(clientIP);
        }
        
        public string ReadData(string clientIP)
        {
            return AsynchronousClient.ReadData(clientIP);
        }

        public String[] StartFingerPrint(String[] minutiaCompareList, bool useLFD)
        {
            return AsynchronousClient.StartFingerPrint(minutiaCompareList, useLFD);
        }

        public String[] StartFingerPrintServer(String[] minutiaCompareList)
        {
            return AsynchronousClient.StartFingerPrintServer(minutiaCompareList);
        }

        public bool buildMinData(String minData)
        {
            return AsynchronousClient.buildMinData(minData);
        }

        public String[] readMinData()
        {
            return AsynchronousClient.readMinData();
        }
    }
}