using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JPGAnimationChart : MonoBehaviour
{
    public Sprite[] animationSprite;
    public Image image;
    public TextMeshProUGUI text;
    [Space]
    public string symbolName;
    public float rangeMin;
    public float rangeMax;
    public float valueMin;
    public float valueMax;
    public string unit;
    public bool isPlant = false;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    public float value;
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
            else {
                if (isPlant) { value = (float)dataAgent.getValueByTagID(symbolName); }
                else { value = (float)dataAgent.getValueBySymbolName(symbolName); }
            }
            //else { value = float.Parse(dataAgent.getValueAndUnitByTagID(symbolName));}
            calValue = calculate(rangeMin, rangeMax, value);
            spriteNum = CalSprite(calValue);
            if (spriteNum >= animationSprite.Length) { spriteNum = animationSprite.Length - 1; }
            image.sprite = animationSprite[spriteNum];
            text.text = string.Format("{0:N0}", value) + "" + unit;
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