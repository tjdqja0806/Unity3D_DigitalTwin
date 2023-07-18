using ChartAndGraph;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LineChartScript : MonoBehaviour
{
    [Serializable]
    public struct ItemStruct
    {
        public string symbolName;
        public float min;
        public float max;
        //public TextMeshProUGUI text;
    }

    public GraphChart chart;
    [Space]
    public ItemStruct[] items;

    private DataAgent dataAgent;
    private int pointCount = 0;
    private float timer = 0.0f;
    private double value;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        chart.CustomDateTimeFormat = "HH:mm:ss";
    }

    void Start()
    {
        initData();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            for (int i = 0; i < items.Length; i++)
            {
                string categoryName = "Data " + (i + 1);
                if (pointCount >= 6)
                {
                    chart.DataSource.ClearCategoryFirst(categoryName);
                    pointCount--;
                }
                if (dataAgent.isAuto) { value = randomValue(items[i].min, items[i].max); }
                else { value = dataAgent.getValueBySymbolName(items[i].symbolName); }
                chart.DataSource.AddPointToCategoryRealtime(categoryName, DateTime.Now, value, 1f);
            }
            pointCount++;
            //text.text = float.Parse(string.Format("{0:N1}", value)) + "";
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    private void initData()
    {
        for (int i = 0; i < items.Length; i++)
        {
            string categoryName = "Data " + (i + 1);
            for (int j = 0; j < 5; j++)
            {
                if (dataAgent.isAuto) { value = randomValue(items[i].min, items[i].max); }
                else { value = dataAgent.getValueBySymbolName(items[i].symbolName); }
                chart.DataSource.AddPointToCategoryRealtime(categoryName, DateTime.Now.AddSeconds(-5 * (5 - j)), value, 1f);
            }
        }
        pointCount = 5;
    }
}