using UnityEngine;
using VisualizationCore;

public class VRConnect : MonoBehaviour
{
    TcpServer svr;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        svr = new TcpServer();
        svr.Start();
    }

    public void VRServerConnect(int vrRoomStatus, string equipnentName)
    {
        svr.Send(vrRoomStatus, equipnentName);
    }
}