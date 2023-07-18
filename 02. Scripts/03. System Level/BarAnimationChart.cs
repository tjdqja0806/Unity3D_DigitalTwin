using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarAnimationChart : MonoBehaviour
{
    public Sprite[] animationSprite;
    public Image image;
    public TextMeshProUGUI valueText;
    public TextMeshProUGUI unitText;
    [Space]
    public string symbolName;
    public float rangeMin = 0;
    public float rangeMax = 100;
    public float valueMin = 0;
    public float valueMax = 100;
    public string unit;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;
    private float calValue;
    private int spriteNum;

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
            if (dataAgent.isAuto) { value = randomValue(valueMin, valueMax); }
            else { value = dataAgent.getValueBySymbolName(symbolName); }            
            calValue = calculate(rangeMin, rangeMax, value);
            spriteNum = CalSprite(calValue);
            if (spriteNum >= animationSprite.Length) { spriteNum = animationSprite.Length - 1; }
            image.sprite = animationSprite[spriteNum];
            valueText.text = string.Format("{0:N1}", value) + "";
            unitText.text = unit + "";
        }
    }

    private int CalSprite(float value)
    {
        return (int)(Mathf.Round(animationSprite.Length * value * 0.01f));
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    private float calculate(float min, float max, double value) { return (float)((value - min) / (max - min)) * 100f; }
}