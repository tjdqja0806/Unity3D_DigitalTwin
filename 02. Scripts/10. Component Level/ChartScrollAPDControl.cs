using System.Collections.Generic;
using UnityEngine;

public class ChartScrollAPDControl : MonoBehaviour
{
    public TextAsset file;
    public RectTransform content;
    public ChartScrollContent contentPrefab;
    public GameObject scrollChartGroup;
    [Space]
    public ComponentChartAPD lineChart1;
    public ComponentChartAPD lineChart2;
    public ComponentChartAPD lineChart3;
    public ComponentChartAPD lineChart4;

    private List<ChartScrollContent> lists = new List<ChartScrollContent>();
    private List<DataGroup> datas = new List<DataGroup>();
    private int[] symbolIndex = new int[4];
    private int symbolIndexCount = 0;

    private struct DataGroup
    {
        public string description;
        public string symbolName;
        public int index;
    }

    void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(file.name);

        string temp = "";
        int count = -1;
        for (int i = 0; i < data.Count; i++)
        {
            if (!((data[i]["SymbolName"].ToString()).Contains("_ML") || (data[i]["SymbolName"].ToString()).Contains("_RS")))
            {
                if (VibDesSort(data[i]["Description"].ToString(), data[i]["구분"].ToString(), data[i]["SymbolName"].ToString()).Equals(temp))
                {
                    CreateItem(VibDesSort(data[i]["Description"].ToString(), data[i]["구분"].ToString(), data[i]["SymbolName"].ToString()), data[i]["SymbolName"].ToString(), count);
                }
                else
                {
                    count++;
                    CreateItem(VibDesSort(data[i]["Description"].ToString(), data[i]["구분"].ToString(), data[i]["SymbolName"].ToString()), data[i]["SymbolName"].ToString(), count);
                    CreateItemList(VibDesSort(data[i]["Description"].ToString(), data[i]["구분"].ToString(), data[i]["SymbolName"].ToString()), count);
                    temp = VibDesSort(data[i]["Description"].ToString(), data[i]["구분"].ToString(), data[i]["SymbolName"].ToString());
                }
            }
        }

        //for (int i = 0; i < datas.Count; i++)
        //{
        //    Debug.Log(datas[i].symbolName + ", " + datas[i].description + ", " + datas[i].index);
        //}

        _ClickApply();
    }

    private void CreateItem(string description, string symbolName, int index)
    {
        DataGroup item = new DataGroup();
        item.description = description;
        item.symbolName = symbolName;
        item.index = index;
        datas.Add(item);
    }

    private ChartScrollContent CreateItemList(string description, int index)
    {
        ChartScrollContent item = Instantiate(contentPrefab);
        item.transform.SetParent(content, false);
        item.description.text = description.Split(char.Parse("_"))[0];
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

        ChangeChartData(lineChart1, 0);
        ChangeChartData(lineChart2, 1);
        ChangeChartData(lineChart3, 2);
        ChangeChartData(lineChart4, 3);

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

    private void ChangeChartData(ComponentChartAPD chart, int num)
    {
        string des = "";
        List<string> symbolNames = new List<string>();
        int count = 0;
        for (int i = 0; i < datas.Count; i++)
        {
            if (datas[i].index == symbolIndex[num])
            {
                count++;
                des = datas[i].description;
                symbolNames.Add(datas[i].symbolName);
            }
        }

        switch (count)
        {
            case 1:
                chart.ChangeData(1, des, symbolNames[0]);
                break;
            case 2:
                chart.ChangeData(2, des, symbolNames[0], symbolNames[1]);
                break;
            case 3:
                chart.ChangeData(3, des, symbolNames[0], symbolNames[1], symbolNames[2]);
                break;
        }

        chart.clearData();
    }

    private string VibDesSort(string description, string sortation, string symbolName)
    {
        string result;
        if (symbolName.Contains("PMP-P")
            || symbolName.Contains("MTR-M")
            || symbolName.Contains("TBN-T")
            || symbolName.Contains("GEN-T"))
        {
            string[] temp = symbolName.Split(char.Parse("-"));
            result = description + " (" + sortation + ", " + temp[3].Substring(0, 2) + ")";
        }
        else
        {
            result = description + " (" + sortation + ")";
        }
        return result;
    }
}