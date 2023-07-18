using UnityEngine;

public class RPASRealtimePopup : MonoBehaviour
{
    public GameObject obj;

    public void _ClickOn() { obj.SetActive(true); }

    public void _ClickOff() { obj.SetActive(false); }
}