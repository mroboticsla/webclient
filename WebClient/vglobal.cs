/*
 * Created by SharpDevelop.
 * User: desarrollo04
 * Date: 30/05/2014
 * Time: 10:19 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SC_CREDENTIAL
{
	/// <summary>
	/// Description of vglobal.
	/// </summary>
	public class vglobal
	{
		public static string AppPath;
		public static bool StartOk = false;
		public static string rol = "0";
		public static string ip = "0.0.0.0";
		public static string id = "";
		public static string name = "";
		public static string admin = "";
		public static string usuario = "";
		public static int FinalTry = 3;

	
		
		public static string[] sRecord;
		public static string config_name = "config.ini";
		public static string sPrinterName;
		public static string sBadgeName;
		public static string sUser;
		public static string sPassWord;
		public static string sCurrent;

		public static string user;
		public static string pass;
		public static string odbc;
		public static string proj;


		public static string projectBM;
		public static string pathBM;
		public static string nameBM;
		public static string idBM;
		public static string odbcBM;
		public static string userBM;
		public static string passBM;
		public static string fileBM;

		public static string addData="";
		public static string UniqueFieldBM;
		public static string PictureTableNameBM;
		
		public static string ipProject="0.0.0.0";
		public static string puertoProject="";
		public static string jreProject=@"C:\Program Files\Java\jre8\bin\";

		

		public static string TableNameBM;
		public static string nameConfig;
		public static Image logoConfig;
		public vglobal()
		{
		}
	}
}
