using ChartAndGraph;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BarChartScript : MonoBehaviour
{
    public BarChart chart;
    [Space]
    public string symbolName;
    public float min;
    public float max;
    //public TextMeshProUGUI text;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            string categoryName = "Data 1";
            if (dataAgent.isAuto) { value = randomValue(min, max); }
            else { value = dataAgent.getValueBySymbolName(symbolName); }
            chart.DataSource.SetValue(categoryName, "All", value);
            //text.text = float.Parse(string.Format("{0:N1}", value)) + "";
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}