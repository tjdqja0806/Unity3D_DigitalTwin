using TMPro;
using UnityEngine;

public class JPGAnimImageRotation : MonoBehaviour
{
    public Transform image;
    public TextMeshProUGUI text;
    [Space]
    public string symbolName;
    public float rotMin;
    public float rotMax;
    public float rangeMin;
    public float rangeMax;
    public float valueMin;
    public float valueMax;
    public string unit;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    //private Quaternion defaultRot;
    private float value;
    private float calValue;
    private float result;

    void Awake()
    {
        //defaultRot = image.transform.localRotation;
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (dataAgent.isAuto) { value = randomValue(valueMin, valueMax); }
            else { value = (float)dataAgent.getValueBySymbolName(symbolName); }            
            calValue = calculate(rangeMin, rangeMax, value);
            result = (rotMax - rotMin) * calValue * 0.01f;
            image.transform.localRotation = Quaternion.Euler(0, 0, rotMin+result);
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