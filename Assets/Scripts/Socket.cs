using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using System;
using System.Diagnostics;

using System.ComponentModel;
public class Socket : MonoBehaviour {
    public Thread mThread;
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 10000;
    IPAddress localAdd;
    TcpListener listener;
    public string currentInput;
    TcpClient client;
    public TextMesh textMesh; 
    public PowerController powerController;
    bool running;
    Text textResult;
    string dataReceived = " ";

    public void LateUpdate(){
	    powerController.currentGesture = dataReceived;
    }

    private void Start()
    {
       
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
        string st_1 = Application.dataPath;
        string st_2 = "/start_pyton.bat.bat";
        string path = st_1 + st_2;
        Start_Python(path);
        
    }

    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }

    void GetInfo()
    {
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        listener.Start();
       
        client = listener.AcceptTcpClient();
        
        running = true;
        while (running)
        {
            Connection();
        }
        listener.Stop();
    }

    void Connection()
    {
        NetworkStream nwStream = client.GetStream();
       
       	//envia input
		byte[] message = System.Text.Encoding.ASCII.GetBytes(currentInput);
		nwStream.Write(message, 0, message.Length);
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = nwStream.Read(buffer, 0, buffer.Length);  
        dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
    }

    public void StopGestureDetection()
    {
        listener.Stop();
        mThread.Abort();
    }
    void Start_Python(string path)
    {
        Process.Start(path);
    }
}
