using ChartAndGraph;
using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LineChartTagList : MonoBehaviour
{
    public GraphChart chart;
    [Space]
    public TextMeshProUGUI tagID;
    [HideInInspector]
    public string tagName;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;

    private int status = 0;
    private int pointMax = 720;
    private int pointCount = 0;
    private float min = 0;
    private float max = 100;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        chart.CustomDateTimeFormat = "HH:mm:ss";
        initData();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (pointCount >= (pointMax + 1))
            {
                chart.DataSource.ClearCategoryFirst("Data 1");
                pointCount--;
            }
            if (dataAgent.isAuto) { value = randomValue(min, max); }
            else { value = dataAgent.getValueByTagID(tagName); }

            chart.DataSource.AddPointToCategoryRealtime("Data 1", DateTime.Now, value, 1f);
            pointCount++;
        }
    }

    private void initData()
    {
        DateTime time = DateTime.Now;
        switch (status)
        {
            case 0:
                pointMax = 720;
                for (int i = 0; i < pointMax; i++)
                {
                    if (dataAgent.isAuto) { value = randomValue(min, max); }
                    else { value = dataAgent.getValueByTagID(tagName); }
                    chart.DataSource.AddPointToCategoryRealtime("Data 1", time.AddSeconds(-5 * (pointMax - i)), value, 1f);
                }
                pointCount = pointMax;
                break;

            case 1:
                pointMax = 720;
                for (int i = 0; i < pointMax; i++)
                {
                    if (dataAgent.isAuto) { value = randomValue(min, max); }
                    else { value = dataAgent.getValueByTagID(tagName); }
                    chart.DataSource.AddPointToCategoryRealtime("Data 1", time.AddMinutes(-2 * (pointMax - i)), value, 1f);
                }
                pointCount = pointMax;
                break;

            case 2:
                pointMax = 672;
                for (int i = 0; i < pointMax; i++)
                {
                    if (dataAgent.isAuto) { value = randomValue(min, max); }
                    else { value = dataAgent.getValueByTagID(tagName); }
                    chart.DataSource.AddPointToCategoryRealtime("Data 1", time.AddMinutes(-15 * (pointMax - i)), value, 1f);
                }
                pointCount = pointMax;
                break;

            case 3:
                pointMax = 720;
                for (int i = 0; i < pointMax; i++)
                {
                    if (dataAgent.isAuto) { value = randomValue(min, max); }
                    else { value = dataAgent.getValueByTagID(tagName); }
                    chart.DataSource.AddPointToCategoryRealtime("Data 1", time.AddHours(-1 * (pointMax - i)), value, 1f);
                }
                pointCount = pointMax;
                break;
        }
    }

    public void clearData()
    {
        chart.DataSource.ClearCategory("Data 1");
        initData();
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    public void _ClickExit() { Destroy(gameObject); }

    public void _ClickStatus(int num)
    {
        status = num;
        clearData();
    }
}