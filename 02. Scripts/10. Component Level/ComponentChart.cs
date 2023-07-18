using ChartAndGraph;
using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ComponentChart : MonoBehaviour
{
    public GraphChart chart;
    public TextMeshProUGUI description;
    [Space]
    public float min = 0;
    public float max = 100;
    [HideInInspector]
    public string[] symbolName;
    [HideInInspector]
    public int lineCount = 1;

    private DataAgent dataAgent;
    private TextMeshProUGUI unit;
    private int pointCount = 0;
    private float timer = 0.0f;
    private double value = 0;
    private bool isTag = false;
    private string descriptionText;
    private string categoryName;

    void Awake()
    {
        symbolName = new string[3];
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        unit = GetComponentInChildren<TextMeshProUGUI>();
        chart.CustomDateTimeFormat = "HH:mm:ss";
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
        for (int j = 0; j < lineCount; j++)
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
    }

    public void ChangeData(int lineCount, string description, string symbolName1, string symbolName2)
    {
        this.lineCount = lineCount;
        this.description.text = description;
        descriptionText = description;
        symbolName[0] = symbolName1;
        symbolName[1] = symbolName2;
        isTag = false;
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
    }

    public void _ClickDescription()
    {
        isTag = !isTag;
        if (isTag) { description.text = dataAgent.GetPlantID() + symbolName[0]; }
        else { description.text = descriptionText; }
    }
}