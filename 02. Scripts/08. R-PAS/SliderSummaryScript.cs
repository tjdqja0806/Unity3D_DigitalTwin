using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SliderSummaryScript : MonoBehaviour
{
    public Slider slider;
    [Space]
    public string symbolName;
    public float min = 0;
    public float max = 100;
    public string unit;
    public TextMeshProUGUI textValue;
    [Space]
    public Sprite normal;
    public Sprite alarm;
    public Sprite warning;
    public Image fill;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;

    void Start()
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
            slider.value = (float)value;
            textValue.text = float.Parse(string.Format("{0:0.0}", value)) + "" + unit;

            if (value >= 60) { fill.sprite = normal; }
            else if (value >= 30) { fill.sprite = alarm; }
            else { fill.sprite = warning; }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}