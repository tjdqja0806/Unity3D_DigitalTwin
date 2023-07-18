using ChartAndGraph;
using TMPro;
using UnityEngine;

public class ServerStatusScript : MonoBehaviour
{
    public PieChart[] chart;//0 : Memory, 1 : Disk, 2 : CPU Total
    public TextMeshProUGUI[] valueText;//CPU, Memory, Disk
    public TextMeshProUGUI[] chartText;//0 : CPU speed, 1 : Memory, 2 : Disk
    public TextMeshProUGUI titleText;
    public Material pieMatCPU;
    public Material pieMatMemory;
    public Material pieMatDisk;
    public Color defaultColor;
    public Color warningColor;


    private float timer = 5.0f;
    private string serverName;
    private double[] valueData;
    private DataAgent dataAgent;
    private ServerStatusUIOnOffScript serverScript;
    private int serverStatus;

    //Server Name : Visualization, Platform, MachineLearning, RelayServer, NuclearServer;
    //World Canvas에 Script넣는 오브젝트 이름 Server Name이랑 같게 하기

    void Awake()
    {
        //int a = (int)CommonVars.ServerID.Count;
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        serverScript = GameObject.Find("EventSystem").GetComponent<ServerStatusUIOnOffScript>();
    }
    void Start()
    {
        serverName = gameObject.name;
        _DataInit();
    }
    private void OnEnable()
    {
        _DataInit();
    }
    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 5.0f;
            _DataInit();
        }
        _ChartColorChange();
    }
    public void _DataInit()
    {
        serverStatus = serverScript.serverStatus;
        switch (serverStatus)
        {
            case 0:
                serverName = "Visualization";
                titleText.text = "Visualization";
                break;
            case 1:
                serverName = "Platform P";
                titleText.text = "Big Data Platform P";
                break;
            case 2:
                serverName = "Platform B";
                titleText.text = "Big Data Platform B";
                break;
            case 3:
                serverName = "MachineLearning";
                titleText.text = "Machine Learning";
                break;
            case 4:
                serverName = "RelayServer";
                titleText.text = "Relay";
                break;
            case 5:
                serverName = "NuclearServer";
                titleText.text = "Core";
                break;
            default:
                serverName = "Visualization";
                titleText.text = "Visualization";
                break;
        }
        valueData = dataAgent.ServerStatus(serverName);
        //value 넣는 부분
        for (int i = 0; i < valueData.Length; i++)
        {
            switch (i)
            {
                case 0:
                    valueText[i].text = string.Format("{0:N2}", valueData[i]);
                    break;
                case 1:
                    valueText[i].text = string.Format("{0:N1}", valueData[i]);
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                    valueText[i].text = string.Format("{0:N1}", valueData[i] / 1048567);
                    break;
            }
        }

        //Chart 값 입력 및 ChartText 입력
        chart[0].DataSource.SetValue("Remainder", 100f - float.Parse(string.Format("{0:N1}", chartText[0].text)));
        chart[0].DataSource.SetValue("Value", float.Parse(string.Format("{0:N1}", chartText[0].text)));
        chartText[0].text = string.Format("{0:N1}", 100 - (valueData[3] / valueData[2] * 100));

        chart[1].DataSource.SetValue("Remainder", 100f - float.Parse(string.Format("{0:N1}", chartText[1].text)));
        chart[1].DataSource.SetValue("Value", float.Parse(string.Format("{0:N1}", chartText[1].text)));
        chartText[1].text = string.Format("{0:N1}", 100 - (valueData[5] / valueData[4] * 100));
        chart[2].DataSource.SetValue("Remainder", 100f - float.Parse(string.Format("{0:N1}", valueData[1])));
        chart[2].DataSource.SetValue("Value", float.Parse(string.Format("{0:N1}", valueData[1])));
    }
    private void _ChartColorChange()
    {
        if (float.Parse(chartText[0].text) >= 80)
        {
            pieMatMemory.SetColor("_Color", warningColor);
        }
        else
        {
            pieMatMemory.SetColor("_Color", defaultColor);
        }

        if (float.Parse(chartText[1].text) >= 80)
        {
            pieMatDisk.SetColor("_Color", warningColor);
        }
        else
        {
            pieMatDisk.SetColor("_Color", defaultColor);
        }

        if ((float)valueData[1] >= 80f)
        {
            pieMatCPU.SetColor("_Color", warningColor);
        }
        else
        {
            pieMatCPU.SetColor("_Color", defaultColor);
        }
    }
}