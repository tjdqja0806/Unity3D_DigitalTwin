using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SliderScript : MonoBehaviour
{
    [Space]
    public string symbolName;
    public float min = 0;
    public float max = 100;
    public string unit;
    public TextMeshProUGUI text;

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
            /*if (value > -1 && value < 1 && value != 0) { text.text = string.Format("{0:N3}", value) + "" + unit; }
            else { text.text = string.Format("{0:N1}", value) + "" + unit; }*/
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}