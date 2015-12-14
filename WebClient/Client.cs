using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using SC_CREDENTIAL;
using System.Drawing;
using System.Collections.Generic;

// State object for receiving data from remote device.
public class StateObject {
    // Client socket.
    public Socket workSocket = null;
    // Size of receive buffer.
    public const int BufferSize = 256;
    // Receive buffer.
    public byte[] buffer = new byte[BufferSize];
    // Received data string.
    public StringBuilder sb = new StringBuilder();
}

public class AsynchronousClient {
    // The port number for the remote device.
    private const int port = 11000;

    // ManualResetEvent instances signal completion.
    private static ManualResetEvent connectDone = 
        new ManualResetEvent(false);
    private static ManualResetEvent sendDone = 
        new ManualResetEvent(false);
    private static ManualResetEvent receiveDone = 
        new ManualResetEvent(false);

    private static bool connectionOK = false;
    private static bool connectionWaiter = true;

    private static String minSetPath = @"C:\TEMP\minData";

    // The response from the remote device.
    private static String response = String.Empty;

    public static void resetResponse()
    {
        connectDone.Reset();
        sendDone.Reset();
        receiveDone.Reset();
        response = String.Empty;
    }

    public static string ReadData(string clientIP)
    {
        resetResponse();
        string _result = "Servicio no disponible en " + clientIP;
        try
        {
            /*
            IPHostEntry ipHostInfo = Dns.Resolve(clientIP);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            client.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), client);
            
            
            connectDone.WaitOne();

            Send(client, "<REG><EOF>");
            sendDone.WaitOne();

            Receive(client);
            receiveDone.WaitOne();

            Console.WriteLine("Response received : {0}", response);

            _result = response;
            
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            */
            Process process = new Process();
            process.StartInfo.FileName = "C:\\SC\\BM6400\\BM6400.exe";
            process.StartInfo.UseShellExecute = false;
            //process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            // Synchronously read the standard output of the spawned process. 
            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();

            // Write the redirected output to this application's window.
            Console.WriteLine(output);

            process.WaitForExit();
            process.Close();

            _result = output;
        }
        catch (Exception e)
        {
            SetConnection(false);
            resetResponse();
            Console.WriteLine(e.ToString());
        }
        return _result;
    }

    private static void SetConnection(bool value)
    {
        connectionOK = value;
        connectionWaiter = false;
    }

    public static void StartClient(string clientIP) {
        // Connect to a remote device.
        try {
            // Establish the remote endpoint for the socket.
            // The name of the 
            // remote device is "SCDESA03".
            IPHostEntry ipHostInfo = Dns.Resolve(clientIP);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.
            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.
            client.BeginConnect( remoteEP, 
                new AsyncCallback(ConnectCallback), client);
            connectDone.WaitOne();

            // Send test data to the remote device.
            Send(client,"RealPass_V Service Running...<EOF><REG>");
            sendDone.WaitOne();
            
            // Receive the response from the remote device.
            Receive(client);
            receiveDone.WaitOne();
            
            Console.WriteLine("Response received : {0}", response);
            
	        // Release the socket.
            client.Shutdown(SocketShutdown.Both);
            client.Close();    
            
            
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    public static string GetPreviewProc(string BMID)
    {
        Process process = new Process();
        process.StartInfo.FileName = "C:\\Test\\BMServer\\BackEndInstance.exe";
        process.StartInfo.UseShellExecute = false;
        //process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();

        // Synchronously read the standard output of the spawned process. 
        StreamReader reader = process.StandardOutput;
        string output = reader.ReadToEnd();

        // Write the redirected output to this application's window.
        Console.WriteLine(output);

        process.WaitForExit();
        process.Close();

        return output;
    }

    #region BadgeMaker

    public static byte[] DataFile;
    public static string DataText;
    private static ini RWini = new ini();
    public static int DataInt;
    public static string CountItems;
    public static int CountItemsVal;

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

    #endregion

    #region Eventos Asincronos

    private static void ConnectCallback(IAsyncResult ar) {
        try {
            // Retrieve the socket from the state object.
            Socket client = (Socket) ar.AsyncState;

            // Complete the connection.
            client.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}",
                client.RemoteEndPoint.ToString());

            // Signal that the connection has been made.
            connectDone.Set();
            SetConnection(true);
            
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
            SetConnection(false);
        }
    }

    private static void Receive(Socket client) {
        try {
            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = client;

            // Begin receiving the data from the remote device.
            client.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    private static void ReceiveCallback( IAsyncResult ar ) {
        try {
            // Retrieve the state object and the client socket 
            // from the asynchronous state object.
            StateObject state = (StateObject) ar.AsyncState;
            Socket client = state.workSocket;

            // Read data from the remote device.
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0) {
                // There might be more data, so store the data received so far.
            state.sb.Append(Encoding.ASCII.GetString(state.buffer,0,bytesRead));

                // Get the rest of the data.
                client.BeginReceive(state.buffer,0,StateObject.BufferSize,0,
                    new AsyncCallback(ReceiveCallback), state);
            } else {
                // All the data has arrived; put it in response.
                if (state.sb.Length > 1) {
                    response = state.sb.ToString();
                }
                // Signal that all bytes have been received.
                receiveDone.Set();
            }
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    private static void Send(Socket client, String data) {
        // Convert the string data to byte data using ASCII encoding.
        byte[] byteData = Encoding.ASCII.GetBytes(data);

        // Begin sending the data to the remote device.
        client.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), client);
    }

    private static void SendCallback(IAsyncResult ar) {
        try {
            // Retrieve the socket from the state object.
            Socket client = (Socket) ar.AsyncState;

            // Complete sending the data to the remote device.
            int bytesSent = client.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);

            // Signal that all bytes have been sent.
            sendDone.Set();
        } catch (Exception e) {
            Console.WriteLine(e.ToString());
        }
    }

    #endregion

    #region Suprema

    public bool AppendMinData(String min)
    {
        bool result = false;
        return result;
    }

    public static String[] StartFingerPrintServer(String[] minSet)
    {
        string[] _result = null;
        Process compiler = new Process();
        compiler.StartInfo.FileName = "calc";
        String args = "";
        int count = 0;
        foreach (String str in minSet)
        {
            if (str != null)
            {
                if (!str.Equals(""))
                {
                    if (count > 0) args += " ";
                    args += str;
                }
                count++;
            }
        }
        compiler.StartInfo.Arguments = args;
        compiler.StartInfo.UseShellExecute = false;
        compiler.StartInfo.RedirectStandardOutput = true;
        compiler.Start();

        string output = compiler.StandardOutput.ReadToEnd();
        _result = output.Split(',');

        compiler.WaitForExit();

        return _result;
    }

    public static String[] CheckReader()
    {
        string[] _result = null;
        
        try
        {
            //Check for Data
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            _result = new String[2];
            _result[0] = ex.ToString();
            _result[0] = "ERROR";
        }
        return _result;
    }

    public static String[] StartFingerPrint(String[] minSet, bool activeLFD)
    {
        string[] _result = null;
        List<byte[]> minutiaCompareList = new List<byte[]>();

        for (int i = 0; i < minSet.Length; i++)
        {
            if (!minSet[i].Equals("") || minSet[i] != null)
            {
                byte[] min = new byte[0];
                try{
                    min = Convert.FromBase64String(minSet[i]);
                }catch{ }
                minutiaCompareList.Add(min);
            }else{
                minutiaCompareList.Add(new byte[0]);
            }
        }

        if (minSet.Length == 0)
        {
            byte[] min = new byte[0];
            minutiaCompareList.Add(min);
        }

        try
        {
            //Do Process
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            _result = new String[1];
            _result[0] = ex.ToString();
        }

        return _result;
    }

    public static bool buildMinData(String minData)
    {
        try
        {
            File.WriteAllText(minSetPath, "");
            if (minData != null)
            {
                String[] buffer = minData.Split(',');
                if (buffer.Length > 0)
                {
                    File.WriteAllLines(minSetPath, buffer);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }catch{ }
        return false;
    }

    public static String[] readMinData()
    {
        try
        {
            return File.ReadAllLines(minSetPath);
        }
        catch { }
        return null;
    }

    #endregion
}