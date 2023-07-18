using TMPro;
using UnityEngine;

public class JPGAnimImageTransform : MonoBehaviour
{
    public Transform image;
    public TextMeshProUGUI text;
    [Space]
    public string symbolName;
    public float transformMin;
    public float transformMax;
    public float rangeMin;
    public float rangeMax;
    public float valueMin;
    public float valueMax;
    public string unit;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private Vector3 defaultPos;
    private float value;
    private float calValue;
    private float result;

    void Awake()
    {
        defaultPos = image.transform.localPosition;
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    void Update()
    {
        if (defaultPos.y + result > transformMax)
            image.transform.localPosition = new Vector3(defaultPos.x, transformMax, defaultPos.z);

        if(defaultPos.y + result < transformMin)
            image.transform.localPosition = new Vector3(defaultPos.x, transformMin, defaultPos.z);
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (dataAgent.isAuto) { value = randomValue(valueMin, valueMax); }
            else { value = (float)dataAgent.getValueBySymbolName(symbolName); }            
            calValue = calculate(rangeMin, rangeMax, value);
            result = (transformMax - transformMin) * calValue * 0.01f;            
            image.transform.localPosition = new Vector3(defaultPos.x, defaultPos.y + result, defaultPos.z);
            text.text = string.Format("{0:N0}", value) + "" + unit;
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    private float calculate(float min, float max, double value) { return (float)((value - min) / (max - min)) * 100f; }
}