using ChartAndGraph;
using TMPro;
using UnityEngine;

public class PieChartScript : MonoBehaviour
{
    public PieChart chart;
    [Space]
    public string symbolName;
    public float min;
    public float max;
    public TextMeshProUGUI valueText;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    [HideInInspector]
    public double value;

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

            if (dataAgent.isAuto) { value = randomValue(min, max); }
            else { value = dataAgent.getValueBySymbolName(symbolName); }
            value = float.Parse(string.Format("{0:N1}", value));

            chart.DataSource.SetValue("Remainder", 110f - value);
            //chart.DataSource.SetValue("Remainder", 1800.0f - value);
            chart.DataSource.SetValue("Value", value);
            //valueText.text = float.Parse(string.Format("{0:N1}", value)) + "";
            valueText.text = string.Format("{0:N0}", value) + "" ;
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}