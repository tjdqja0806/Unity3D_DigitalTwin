using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScaleControl : MonoBehaviour
{
    public string symbolName;
    public float min = 0;
    public float max = 100;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;
    private double percentValue;
    [Space]
    private Transform level;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        level = GetComponent<Transform>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (dataAgent.isAuto) { value = randomValue(min, max); }
            else { value = dataAgent.getValueBySymbolName(symbolName); }
            percentValue = calculate(min, max, value);
            if (percentValue >= 100)
                level.localScale = new Vector3(1, 1, 1);
            else if (percentValue >= 90)
                level.localScale = new Vector3(1, 0.9f, 1);
            else if (percentValue >= 80)
                level.localScale = new Vector3(1, 0.8f, 1);
            else if (percentValue >= 70)
                level.localScale = new Vector3(1, 0.7f, 1);
            else if (percentValue >= 60)
                level.localScale = new Vector3(1, 0.6f, 1);
            else if (percentValue >= 50)
                level.localScale = new Vector3(1, 0.5f, 1);
            else if (percentValue >= 40)
                level.localScale = new Vector3(1, 0.4f, 1);
            else if (percentValue >= 30)
                level.localScale = new Vector3(1, 0.3f, 1);
            else if (percentValue >= 20)
                level.localScale = new Vector3(1, 0.2f, 1);
            else if (percentValue >= 10)
                level.localScale = new Vector3(1, 0.1f, 1);
            else if (percentValue >= 1)
                level.localScale = new Vector3(1, 0.01f, 1);
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    private float calculate(float min, float max, double value) { return (float)((value - min) / (max - min)) * 100f; }

}
