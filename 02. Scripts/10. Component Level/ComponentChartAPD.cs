using ChartAndGraph;
using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ComponentChartAPD : MonoBehaviour
{
    public GraphChart chart;
    public TextMeshProUGUI description;
    [Space]
    public TextMeshProUGUI legend1;
    public TextMeshProUGUI legend2;
    public TextMeshProUGUI legend3;
    [Space]
    public float min = 0;
    public float max = 100;
    [HideInInspector]
    public string[] symbolName;
    [HideInInspector]
    public int lineCount = 3;

    private DataAgent dataAgent;
    public TextMeshProUGUI unit;
    private int pointCount = 0;
    private float timer = 0.0f;
    private double value = 0;
    private bool isTag = false;
    private string descriptionText;
    private string categoryName;

    void Awake()
    {
        symbolName = new string[4];
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        chart.CustomDateTimeFormat = "HH:mm:ss";

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "Unit")
                unit = transform.GetChild(i).GetComponent<TextMeshProUGUI>();
        }

        initData();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (pointCount >= 6)
            {
                for (int i = 0; i < lineCount; i++)
                {
                    categoryName = "Data " + (i + 1);
                    chart.DataSource.ClearCategoryFirst(categoryName);
                }
                pointCount--;
            }
            for (int i = 0; i < lineCount; i++)
            {
                categoryName = "Data " + (i + 1);
                if (dataAgent.isAuto) { value = randomValue(min, max); unit.text = ""; }
                else {
                    value = dataAgent.getValueBySymbolName(symbolName[i]);
                    unit.text = dataAgent.getValueAndUnitBySymbolName(symbolName[i]);
                }
                chart.DataSource.AddPointToCategoryRealtime(categoryName, DateTime.Now, value, 1f);
            }
            pointCount++;
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    private void initData()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < lineCount; j++)
            {
                categoryName = "Data " + (j + 1);
                if (dataAgent.isAuto) { value = randomValue(min, max); }
                else { value = dataAgent.getValueBySymbolName(symbolName[j]); }
                chart.DataSource.AddPointToCategoryRealtime(categoryName, DateTime.Now.AddSeconds(-5 * (5 - i)), value, 1f);
            }
        }
        pointCount = 5;
    }

    public void clearData()
    {
        for (int j = 0; j < 3; j++)
        {
            categoryName = "Data " + (j + 1);
            chart.DataSource.ClearCategory(categoryName);
        }
        initData();
    }

    public void ChangeData(int lineCount, string description, string symbolName)
    {
        this.lineCount = lineCount;
        this.description.text = description;
        descriptionText = description;
        this.symbolName[0] = symbolName;
        isTag = false;
        if (description.Contains("심각도"))
        {
            legend1.text = description.Split(char.Parse("("))[1] + "(" + description.Split(char.Parse("("))[2].Substring(0, description.Split(char.Parse("("))[2].Length - 1);
        }
        else { legend1.text = description.Split(char.Parse("("))[1].Substring(0, description.Split(char.Parse("("))[1].Length - 1); }
        legend2.text = "None";
        legend3.text = "None";
    }

    public void ChangeData(int lineCount, string description, string symbolName1, string symbolName2)
    {
        this.lineCount = lineCount;
        this.description.text = description;
        descriptionText = description;
        symbolName[0] = symbolName1;
        symbolName[1] = symbolName2;
        isTag = false;
        legend1.text = SymbolNameSplit(symbolName1, true);
        legend2.text = SymbolNameSplit(symbolName2, true);
        legend3.text = "None";
    }

    public void ChangeData(int lineCount, string description, string symbolName1, string symbolName2, string symbolName3)
    {
        this.lineCount = lineCount;
        this.description.text = description;
        descriptionText = description;
        symbolName[0] = symbolName1;
        symbolName[1] = symbolName2;
        symbolName[2] = symbolName3;
        isTag = false;
        legend1.text = SymbolNameSplit(symbolName1, true);
        legend2.text = SymbolNameSplit(symbolName2, true);
        legend3.text = SymbolNameSplit(symbolName3, true);
    }

    public void ChangeData(int lineCount, string description, string symbolName1, string symbolName2, string symbolName3, string symbolName4)
    {
        this.lineCount = lineCount;
        this.description.text = description;
        descriptionText = description;
        symbolName[0] = symbolName1;
        symbolName[1] = symbolName2;
        symbolName[2] = symbolName3;
        symbolName[3] = symbolName4;
        isTag = false;
    }

    public void _ClickDescription()
    {
        isTag = !isTag;
        if (isTag) { description.text = dataAgent.GetPlantID() + SymbolNameSplit(symbolName[0], false); }
        else { description.text = descriptionText; }
    }

    private string SymbolNameSplit(string symbolName, bool isLegend)
    {
        string result;
        string[] splitTemp;
        if (symbolName.Contains("PMP-P")
            || symbolName.Contains("MTR-M")
            || symbolName.Contains("TBN-T")
            || symbolName.Contains("GEN-T"))
        {
            splitTemp = symbolName.Split(char.Parse("-"));
            if (isLegend) { result = splitTemp[3]; }
            else { result = splitTemp[0] + "-" + splitTemp[1] + "-" + splitTemp[2] + "-" + splitTemp[3].Substring(0, 2); }
        }
        else
        {
            result = symbolName;
        }
        return result;
    }
}