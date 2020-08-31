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
public class SocketMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Thread mThread;
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 10000;
    IPAddress localAdd;
    TcpListener listener;
    public string currentInput;
    TcpClient client;
    public TextMesh textMesh;
    public SceneTransitionController sceneTransitionController;
    bool running;
    Text textResult;
    string dataReceived = " ";

    public void LateUpdate()
    {
        sceneTransitionController.currentGesture = dataReceived;
    }

    private void Start()
    {
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
        //Start_Python("C:/start_pyton.bat");
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
    void Start_Python(string path)
    {
        print(path);
        Process.Start(path);
    }

}
