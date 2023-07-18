using UnityEngine;
using Vuplex.WebView;

public class RPASWebOpen : MonoBehaviour
{
    public CanvasWebViewPrefab prefab;
    public GameObject webCanvas;

    private DataAgent dataAgent;
    private bool isFirst = true;
    private string url = "";

    void Start()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    public void _ClickOpenPage(string content)
    {
        if (dataAgent.isAuto) { url = "http://61.97.52.25:8080/cmm/rpas/Rpas" + content + "View.do"; }
        else { url = "http://10.145.19.229:8080/cmm/rpas/Rpas" + content + "View.do"; }

        webCanvas.SetActive(true);

        if (isFirst)
        {
            prefab.InitialUrl = url;
            isFirst = false;
        }
        else { prefab.WebView.LoadUrl(url); }
    }

    public void _ClickExit()
    {
        webCanvas.SetActive(false);
    }
}