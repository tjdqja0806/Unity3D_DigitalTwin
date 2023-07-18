using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChartScrollControl : MonoBehaviour
{
    public TextAsset file;
    public RectTransform content;
    public ChartScrollContent contentPrefab;
    public GameObject scrollChartGroup;
    [Space]
    public ComponentChart lineChart1;
    public ComponentChart lineChart2;
    public ComponentChart lineChart3;
    public ComponentChart lineChart4;

    private List<ChartScrollContent> lists = new List<ChartScrollContent>();
    private int[] symbolIndex = new int[4];
    private int symbolIndexCount = 0;
    private DataAgent dataAgent;

    void Start()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();

        List<Dictionary<string, object>> data = CSVReader.Read(file.name);

        if (file.name.Contains("_PI"))
        {
            for (int i = 0; i < data.Count; i++)
            {
                CreateItemList(data[i]["Description"].ToString(), data[i]["SymbolName"].ToString(), data[i]["EnUnit"].ToString(), i);
            }
        }
        if (file.name.Contains("_APD"))
        {
            for (int i = 0; i < data.Count; i++)
            {
                CreateItemList(data[i]["Description"].ToString() + " (" + data[i]["구분"] + ")", data[i]["SymbolName"].ToString(), data[i]["EnUnit"].ToString(), i);
            }
        }
        if (file.name.Contains("_PHI"))
        {
            for (int i = 0; i < data.Count; i++)
            {
                CreateItemList(data[i]["Description"].ToString(), data[i]["SymbolName"].ToString(), data[i]["EnUnit"].ToString(), i);
            }
        }
        if (file.name.Contains("_RPAS"))
        {
            for (int i = 0; i < data.Count; i++)
            {
                CreateItemList(data[i]["Description"].ToString(), data[i]["SymbolName"].ToString(), data[i]["EnUnit"].ToString(), i);
            }
        }
        _ClickApply();
    }

    // ------------------------------------------------------------------------------------

    string filePath = "Assets/TextLog/";
    StreamWriter streamWriter;

    public void outTextPI()
    {
        if (File.Exists(filePath + SceneManager.GetActiveScene().name) == false)
        {
            streamWriter = new StreamWriter(filePath + SceneManager.GetActiveScene().name + ".txt");

            for (int i = 0; i < lists.Count; i++)
            {
                streamWriter.WriteLine(
                    "Symbol Name : "
                    + lists[i].symbolName
                    + "          Description : "
                    + lists[i].des
                    + "          Value : "
                    + dataAgent.getValueBySymbolName(lists[i].symbolName)
                    );
            }

            streamWriter.Flush();
            streamWriter.Close();
            Debug.Log(SceneManager.GetActiveScene().name + " 저장 완료");
        }
    }

    // ------------------------------------------------------------------------------------

    private ChartScrollContent CreateItemList(string description, string symbolName, string unit, int index)
    {
        ChartScrollContent item = Instantiate(contentPrefab);
        item.transform.SetParent(content, false);
        item.description.text = description;
        item.des = description;
        item.unit = unit;
        item.symbolName = symbolName;
        item.index = index;
        if (index < 4)
        {
            item._ClickEvent();
            symbolIndex[index] = index;
        }
        lists.Add(item);
        return item.GetComponent<ChartScrollContent>();
    }

    public void _ClickApply()
    {
        for (int i = 0; i < lists.Count; i++)
        {
            if (symbolIndexCount < 4 && lists[i].isActive)
            {
                symbolIndex[symbolIndexCount] = lists[i].index;
                symbolIndexCount++;
            }
        }
        symbolIndexCount = 0;

        lineChart1.ChangeData(1, ReturnDescription(0), ReturnSymbolName(0), ReturnUnit(0));
        lineChart2.ChangeData(1, ReturnDescription(1), ReturnSymbolName(1), ReturnUnit(1));
        lineChart3.ChangeData(1, ReturnDescription(2), ReturnSymbolName(2), ReturnUnit(2));
        lineChart4.ChangeData(1, ReturnDescription(3), ReturnSymbolName(3), ReturnUnit(3));

        lineChart1.clearData();
        lineChart2.clearData();
        lineChart3.clearData();
        lineChart4.clearData();

        _ClickGroupClose();
    }

    public void _ClickClose()
    {
        for (int i = 0; i < lists.Count; i++)
        {
            if (symbolIndexCount < 4 && lists[i].index == symbolIndex[symbolIndexCount])
            {
                lists[i].ChangeCheckbox(true);
                symbolIndexCount++;
            }
            else { lists[i].ChangeCheckbox(false); }
        }
        symbolIndexCount = 0;
    }

    public void _ClickGroupOpen() { scrollChartGroup.SetActive(true); }

    public void _ClickGroupClose() { scrollChartGroup.SetActive(false); }

    public string ReturnDescription(int num) { return lists[symbolIndex[num]].des; }

    public string ReturnSymbolName(int num) { return lists[symbolIndex[num]].symbolName; }
    public string ReturnUnit(int num) { return lists[symbolIndex[num]].unit; }

}