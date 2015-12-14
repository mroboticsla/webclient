using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebService
{
    public partial class SupremaClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        AsynchronousClient rcc = new AsynchronousClient();
        //ControllerService.ControllerClient rcc = new ControllerService.ControllerClient();
        public Object[] minSet = new Object[10];
        public String[] minSetStrings = new String[10];

        protected void btnRun_Click(object sender, EventArgs e)
        {
            Control min_field = null;
            for (int i = 1; i <= 10; i++)
            {
                if (i < 10)
                {
                    min_field = (Control)FindControl("txt0" + i);
                }
                else
                {
                    min_field = (Control)FindControl("txt" + i);
                }

                if (!((TextBox)min_field).Text.Equals("") && ((TextBox)min_field).Text != null)
                {
                    try
                    {
                        minSet[i - 1] = Convert.FromBase64String(((TextBox)min_field).Text);
                        minSetStrings[i - 1] = ((TextBox)min_field).Text;
                    }
                    catch
                    {
                        minSet[i - 1] = new byte[0];
                        minSetStrings[i - 1] = "";
                    }
                }
                else
                {
                    minSet[i-1] = new byte[0];
                    minSetStrings[i - 1] = "";
                }
            }
            
            Control img_control = (Control)FindControl(((Button)sender).ID.Split('_')[1]);
            Control min_control = (Control)FindControl(((Button)sender).ID.Split('_')[1].Replace("fp","txt"));
            Control minq_control = (Control)FindControl(((Button)sender).ID.Split('_')[1].Replace("fp", "minq"));

            try
            {
                String[] fpData = StartFingerPrint(minSetStrings);
                //String[] fpData = rcc.StartFingerPrintServer(minSetStrings);
                if (fpData != null)
                {
                    if (fpData.Length == 1)
                    {
                        string fpMin = fpData[0];
                        ((HtmlImage)img_control).Src = "";
                        ((TextBox)min_control).Text = fpMin;
                    }
                    else
                    {
                        string fpMin = fpData[0];
                        string fpImage = fpData[1];
                        string fpMinQ = fpData[2];
                        ((HtmlImage)img_control).Src = @"data:image/gif;base64," + fpImage;
                        ((TextBox)min_control).Text = fpMin;
                        ((TextBox)minq_control).Text = fpMinQ;
                    }
                }
                else
                {
                    //MessageBox.Show("Huella Repetida");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al ejecutar: " + ex.Message);
            }
        }

        public static String[] StartFingerPrint(String[] minSet)
        {
            string[] _result = null;
            List<byte[]> minutiaCompareList = new List<byte[]>();

            for (int i = 0; i < minSet.Length; i++)
            {
                if (!minSet[i].Equals("") || minSet[i] != null)
                {
                    byte[] min = new byte[0];
                    try
                    {
                        min = Convert.FromBase64String(minSet[i]);
                    }
                    catch { }
                    minutiaCompareList.Add(min);
                }
                else
                {
                    minutiaCompareList.Add(new byte[0]);
                }
            }

            if (minSet.Length == 0)
            {
                byte[] min = new byte[0];
                minutiaCompareList.Add(min);
            }

            //Do process
            
            return _result;
        }

        private static string ConvertImageToBase64(Bitmap img)
        {
            string _code = "";

            if (img != null)
            {
                Bitmap im = new Bitmap(img, img.Width / 4, img.Height / 4);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                im.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();
                _code = Convert.ToBase64String(byteImage); //Get Base64
            }

            return _code;
        }
    }
}