using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComponentDataScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    [Space]
    public string symbolName;
    public float min;
    public float max;
    public string type;

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
            if (dataAgent.isAuto) { value = randomValue(min, max); }
            else { value = dataAgent.getValueBySymbolName(symbolName); }

            text.text = value.ToString();
            /*if (value > -1 && value < 1 && value != 0) { text.text = string.Format("{0:N3}", value) + " " + type; }
            else { text.text = string.Format("{0:N1}", value) + " " + type; }*/
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}
