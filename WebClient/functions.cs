/*
 * Created by SharpDevelop.
 * User: desarrollo04
 * Date: 30/05/2014
 * Time: 10:56 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Management;
using Microsoft.Win32;
namespace SC_CREDENTIAL
{
	/// <summary>
	/// Description of functions.
	/// </summary>
	public class functions
	{
		private ini RWini = new ini();
		public static bool open_form(FormWindowState winstate, Form open_frm, Form back_frm, string win_text)
		{
			bool inTop = false;
			inTop = false;
//			BackForm showForm=new BackForm();
//			
//			showForm.Show();
//			showForm.ShowInTaskbar=false;
			Application.DoEvents();

			open_frm.StartPosition = FormStartPosition.CenterScreen;
			open_frm.BackColor = Color.Gray;
			
			
			if (!string.IsNullOrEmpty(win_text)) {
				open_frm.Text = win_text;
			}
			if (winstate == FormWindowState.Maximized) {
				open_frm.WindowState = winstate;
			} else {
				open_frm.MaximumSize = open_frm.Size;
				open_frm.MinimumSize = open_frm.Size;
			}
			open_frm.Icon = back_frm.Icon;
			open_frm.MaximizeBox = false;
			open_frm.MinimizeBox = false;
			//open_frm.ForeColor= Color.White;
			//open_frm.ControlBox = false;
			open_frm.TopMost = inTop;
			//open_frm.FormBorderStyle=FormBorderStyle.None;
			open_frm.ShowDialog();
			open_frm.Dispose();

//			showForm.Close();
			back_frm.TopMost = inTop;
			back_frm.Show();
			
			Application.DoEvents();

			return true;
		}
		
		
		public static string  maskAZaz09(string box1){
			
			Boolean nospace=false;
			if (box1.Length > 0) {
				if (box1 == " ") {
					return "";
				}
				string texto = "";
				string pattern = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJAKLMNÑOPQRSTUVWXYZ1234567890 ";
				int i = 0;
				int m = 0;
				for ( i = 0; i <= box1.Length - 1; i++) {
					for (m = 0; m <= pattern.Length - 1; m++) {
						
						if (box1[i].ToString() == " " && !nospace) {
							break;
						}
						else{
							nospace=true;
						}
						
						if (box1[i] == pattern[m]) {
							texto = texto + box1[i].ToString().ToUpper();
							break; // TODO: might not be correct. Was : Exit For
						}
					}
				}
				
				return texto;
			}
			return "";
		}
		public static string  mask_AZaz09(string box1){
			Boolean nospace=false;
			if (box1.Length > 0) {
				if (box1 == " ") {
					return "";
				}
				string texto = "";
				string pattern = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJAKLMNÑOPQRSTUVWXYZ1234567890_.,:;áéíóú*-+/!$%&/()= ";
				int i = 0;
				int m = 0;
				for ( i = 0; i <= box1.Length - 1; i++) {
					for (m = 0; m <= pattern.Length - 1; m++) {
						
						if (box1[i].ToString() == " " && !nospace) {
							break;
						}
						else{
							nospace=true;
						}
						
						if (box1[i] == pattern[m]) {
							texto = texto + box1[i].ToString();
							break; // TODO: might not be correct. Was : Exit For
						}
					}
				}
				
				return texto;
			}
			return "";
		}
		public static string  mask09(TextBox box1){
			if (box1.Text.Length > 0) {
				string texto = "";
				string pattern = "1234567890";
				int i = 0;
				int m = 0;
				for ( i = 0; i <= box1.Text.Length - 1; i++) {
					for (m = 0; m <= pattern.Length - 1; m++) {
						if (box1.Text[i] == pattern[m]) {
							texto = texto + box1.Text[i];
							break; // TODO: might not be correct. Was : Exit For
						}
					}
				}
				
				return texto;
			}
			return "";
		}
		public static Image GetImageFromByteArray(byte[] picData)
		{
			if (picData == null) {
				return null;
			}

			// is this is an embedded object?
			int bmData = 0;

			if ((picData[0] == 21 && picData[1] == 28)) {
				bmData = 78;

			} else {
				bmData = 0;
			}


			// load the picture
			Image img = null;
			try {
				MemoryStream ms = new MemoryStream(picData, bmData, picData.Length - bmData);
				img = Image.FromStream(ms);
			} catch {
			}

			// return what we got
			return img;

		}
		public static int BMPtoJPG(string path_source, string path_solve)
		{
			Image img_buff = null;
			if ((File.Exists(path_source))) {
				byte[] img_bmp = null;
				img_bmp = File.ReadAllBytes(path_source);
				MemoryStream ImgBufToStream = null;
				ImgBufToStream = new MemoryStream(img_bmp);

				img_buff = Bitmap.FromStream(ImgBufToStream);
				byte[] bitmapData = null;
				MemoryStream ms = null;
				ms = new MemoryStream();
				img_buff.Save(ms, ImageFormat.Jpeg);
				bitmapData = ms.ToArray();
				File.WriteAllBytes(path_solve, bitmapData);
				img_buff.Dispose();
				return 0;

			}

			return 0;

		}
		
		static byte[] GetBytes(string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}
		
		public functions()
		{
		}
	}
}
