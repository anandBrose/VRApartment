using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
public class RemoteReciever : MonoBehaviour
{

    public string ip = "127.0.0.1";
    public int port = 25000;

    void Update()
    {
        if (!Network.isServer)
        {
            Network.InitializeServer(10, port, false);
            NetworkServer.RegisterHandler(4344, OnRecieve);
        }
        //if (Network.isServer)
            //Debug.Log("Server: " + Network.connections.Length);
    }

    public void OnRecieve(NetworkMessage netMsg)
    {
        Debug.Log("REcieved"+ netMsg);
    }

}