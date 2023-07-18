using TMPro;
using UnityEngine;

public class ScrollViewContent : MonoBehaviour
{
    public TextMeshProUGUI description;
    public TextMeshProUGUI value;
    public TextMeshProUGUI unit;
    [HideInInspector]
    public string descriptionText;
    [HideInInspector]
    public string symbolName;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double result;
    private bool isTag = false;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 1.0f;
            if (dataAgent.isAuto) { value.text = randomValue(0, 100) + ""; }
            else {
                result = dataAgent.getValueBySymbolName(symbolName);
                value.text = result.ToString();
                /*if (result > -1 && result < 1 && result != 0) { value.text = string.Format("{0:N3}", result) + ""; }
                else { value.text = string.Format("{0:N1}", result) + ""; }*/
            }            
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    public void _ClickDescription()
    {
        isTag = !isTag;
        if (isTag) { description.text = dataAgent.GetPlantID() + symbolName; }
        else { description.text = descriptionText; }
    }

    public void _ClickRealtimeTrend() { }
}