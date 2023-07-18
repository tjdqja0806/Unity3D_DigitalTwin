using ChartAndGraph;
using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DetailInfoChart : MonoBehaviour
{
    public PieChart pieChart;
    public TextMeshProUGUI status;
    public GraphChart graphChart;
    public float min = 600;
    public float max = 650;
    public string equipmentName = "";

    private DetailInfoControl script;
    private CanvasGroup canvasGroup;
    private float timer = 0.0f;
    private double value;
    private bool isActive = false;

    void Awake()
    {
        script = GameObject.Find("EventSystem").GetComponent<DetailInfoControl>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        graphChart.CustomDateTimeFormat = "HH:mm:ss";
    }

    void Update()
    {
        if (script.nameString.Equals(equipmentName) && script.isActive) { canvasGroup.alpha = 1; }
        else { canvasGroup.alpha = 0; }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            value = 0.0f;
            pieChart.DataSource.SetValue("Category 1", 100.0f - value);
            pieChart.DataSource.SetValue("Category 2", value);
            status.text = "Normal";
            graphChart.DataSource.AddPointToCategoryRealtime("Data 1", DateTime.Now, randomValue(min, max), 1f);
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}