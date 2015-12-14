using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebService
{
    public partial class enroll : System.Web.UI.Page
    {
        AsynchronousClient rcc = new AsynchronousClient();
        //ControllerService.ControllerClient rcc = new ControllerService.ControllerClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Object[] minSet = new Object[10];
            String[] minSetStrings = new String[10];
            
            try
            {
                String mn = Request.QueryString["callback"];
                String activeLFD = Request.QueryString["LFD"];

                bool useLFD = false;

                //String[] minData = Request.Form.GetValues("minData");
                String[] minData = AsynchronousClient.readMinData();

                for (int i = 0; i < minSetStrings.Length; i++)
                {
                    minSetStrings[i] = "";
                }

                if (minData != null)
                {
                    minSetStrings = minData;
                }

                Response.Clear();
                Response.ContentType = "application/text";

                if (activeLFD != null)
                {
                    if (activeLFD.Equals("true"))
                    {
                        useLFD = true;
                    }
                }

                String[] fpData = AsynchronousClient.StartFingerPrint(minSetStrings, useLFD);
                //String[] fpData = rcc.StartFingerPrintServer(minSetStrings);
                if (fpData != null)
                {
                    if (fpData.Length == 1)
                    {
                        string fpMin = fpData[0];
                        Response.Write(mn + "([{\"data\":\"\", \"min\":\"" + fpMin + "\",\"quality\":0}])");
                    }
                    else
                    {
                        string fpMin = fpData[0];
                        string fpImage = fpData[1];
                        string fpMinQ = fpData[2];
                        Response.Write(mn + "([{\"data\":\"" + fpImage + "\", \"min\":\"" + fpMin + "\",\"quality\":" + fpMinQ + "}])");
                        //Response.Write(mn);
                    }
                }
                else
                {
                    Response.Write("");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Response.Write("");
            }
        }
    }
}