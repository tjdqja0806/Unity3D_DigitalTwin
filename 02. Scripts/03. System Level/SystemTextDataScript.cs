using TMPro;
using UnityEngine;

public class SystemTextDataScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    [Space]
    public string symbolName;
    public float min;
    public float max;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;
    private string result = "";

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
            if (value > -1 && value < 1 && value != 0)
            {
                result = string.Format("{0:N3}", value);
            }
            else
            {
                result = string.Format("{0:N1}", value);
            }
            text.text = result + "";
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}