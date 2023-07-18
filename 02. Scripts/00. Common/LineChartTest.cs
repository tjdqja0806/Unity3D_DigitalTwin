using ChartAndGraph;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LineChartTest : MonoBehaviour
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
    public bool auto = true;
    public ItemStruct[] items;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;
    private string categoryName;
    private int count = 0;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        chart.CustomDateTimeFormat = "HH:mm:ss";
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            count++;
            for (int i = 0; i < items.Length; i++)
            {
                categoryName = "Data " + (i + 1);
                if (auto) { value = randomValue(items[i].min, items[i].max); }
                else { value = dataAgent.getValueBySymbolName(items[i].symbolName); }
                //chart.DataSource.ClearCategoryFirst(categoryName);
                chart.DataSource.AddPointToCategory(categoryName, DateTime.Now, value, 1f);

            }
            if (count == 20)
            {
                Debug.Log("실행");
                count--;
                chart.DataSource.ClearCategoryFirst(categoryName);
            }
            //text.text = float.Parse(string.Format("{0:N1}", value)) + "";
        }
        
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
    private void OnEnable()
    {
        chart.DataSource.ClearCategory(categoryName);
    }
}
