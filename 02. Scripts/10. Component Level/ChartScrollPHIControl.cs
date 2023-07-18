using System.Collections.Generic;
using UnityEngine;

public class ChartScrollPHIControl : MonoBehaviour
{
    public TextAsset file;
    public RectTransform content;
    public ChartScrollContent contentPrefab;
    public GameObject scrollChartGroup;
    [Space]
    public ComponentChartPHI lineChart1;
    public ComponentChartPHI lineChart2;
    public ComponentChartPHI lineChart3;
    public ComponentChartPHI lineChart4;

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

        for (int i = 0; i < data.Count; i++)
        {
            CreateItem(data[i]["Description"].ToString(), data[i]["SymbolName"].ToString(), i);
            if (i % 4 == 0)
            {
                CreateItemList(data[i]["Description"].ToString(), i / 4);
            }
        }

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

        lineChart1.ChangeData(2, ReturnDescription(0), ReturnSymbolName(0, 0), ReturnSymbolName(0, 1), ReturnSymbolName(0, 2), ReturnSymbolName(0, 3));
        lineChart2.ChangeData(2, ReturnDescription(1), ReturnSymbolName(1, 0), ReturnSymbolName(1, 1), ReturnSymbolName(1, 2), ReturnSymbolName(1, 3));
        lineChart3.ChangeData(2, ReturnDescription(2), ReturnSymbolName(2, 0), ReturnSymbolName(2, 1), ReturnSymbolName(2, 2), ReturnSymbolName(2, 3));
        lineChart4.ChangeData(2, ReturnDescription(3), ReturnSymbolName(3, 0), ReturnSymbolName(3, 1), ReturnSymbolName(3, 2), ReturnSymbolName(3, 3));

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

    public string ReturnDescription(int num) { return datas[symbolIndex[num] * 4].description; }

    public string ReturnSymbolName(int num, int dataIndex) { return datas[(symbolIndex[num] * 4) + dataIndex].symbolName; }
}