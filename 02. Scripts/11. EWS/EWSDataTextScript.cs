using TMPro;
using UnityEngine;

public class EWSDataTextScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    [Space]
    public string symbolName;
    public float min;
    public float max;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private string value;
    private bool isNull = false;

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
            isNull = false;

            if (dataAgent.isAuto) { value = randomValue(min, max).ToString(); }
            else
            {
                //Debug.Log("[Data] " + symbolName + " : '" + dataAgent.getValueStringBySymbolName(symbolName) + "'");
                if (dataAgent.getValueStringBySymbolName(symbolName).Equals("-")
                    || dataAgent.getValueStringBySymbolName(symbolName).Equals("")
                    || symbolName.Equals(""))
                {
                    isNull = true;
                }
                else
                {
                    value = dataAgent.getValueStringBySymbolName(symbolName);
                }
            }

            if (isNull)
            {
                text.text = "-";
                //Debug.Log(gameObject.name + " / " + symbolName + " : " + "-");
            }
            else
            {
                text.text = value;
            }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}