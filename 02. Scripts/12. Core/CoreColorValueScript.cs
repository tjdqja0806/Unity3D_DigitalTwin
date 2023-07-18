using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoreColorValueScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image colorImage;
    [Space]
    public string symbolName;
    public float min = 0;
    public float max = 100;
    
    private Color dataColor;
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
            text.text = float.Parse(string.Format("{0:N1}", value)) + "";

            if (dataAgent.isAuto) { dataColor = Color.red; }
            //else { dataColor = dataAgent.getValueAndUnitBySymbolName(symbolName); }
            colorImage.color = dataColor;
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}
