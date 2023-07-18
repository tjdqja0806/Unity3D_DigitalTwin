using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BoxPerformance : MonoBehaviour
{
    public string symbolName;
    public float min = -1.0f;
    public float max = 1.0f;
    public string unit;
    public TextMeshProUGUI textValue;
    [Space]
    public Sprite normal;
    public Sprite plus;
    public Sprite minus;
    public Image image;

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
            textValue.text = float.Parse(string.Format("{0:0.0}", value)) + "" + unit;

            if (value > 0) { image.sprite = plus; }
            else if (value < 0) { image.sprite = minus; }
            else  { image.sprite = normal; }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}