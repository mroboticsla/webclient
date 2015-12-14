using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebService
{
    public partial class checkSerial : System.Web.UI.Page
    {
        AsynchronousClient rcc = new AsynchronousClient();
        //ControllerService.ControllerClient rcc = new ControllerService.ControllerClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String mn = Request.QueryString["callback"];
                Response.Clear();
                Response.ContentType = "application/text";
                String[] checkData = AsynchronousClient.CheckReader();
                if (checkData != null)
                {
                    if (checkData.Length == 2)
                    {
                        string serial = checkData[0];
                        string validation = checkData[1];
                        Response.Write(mn + "([{\"serial\":\"" + serial + "\", \"validation\":\"" + validation + "\"}])");
                    }
                    else
                    {
                        string serial = checkData[0];
                        string validation = checkData[0];
                        Response.Write(mn + "([{\"serial\":\"ERROR\", \"validation\":\"ERROR\"}])");
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