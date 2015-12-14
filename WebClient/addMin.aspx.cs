using System;
namespace WebService
{
    public partial class addmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String mn = Request.QueryString["callback"];
            try
            {
                AsynchronousClient rcc = new AsynchronousClient();
                //ControllerService.ControllerClient rcc = new ControllerService.ControllerClient();

                String minData = Request.Form.GetValues("minData")[0];
                String rep = Request.InputStream.ToString();
                Response.ContentType = "application/text";

                foreach (String str in Request.Form.GetValues("minData")[0].Split(','))
                {
                    AsynchronousClient.buildMinData(minData);
                }
                Response.Write(mn + "([{\"response\":\"OK\"}])");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Response.Write(mn + "([{\"response\":\"ERROR\"}])");
            }
        }
    }
}