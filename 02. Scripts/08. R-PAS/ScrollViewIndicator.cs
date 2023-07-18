using TMPro;
using UnityEngine;

public class ScrollViewIndicator : MonoBehaviour
{
    public TextMeshProUGUI description;
    //public TextMeshProUGUI value;
    public TextMeshProUGUI status;
    [HideInInspector]
    public string descriptionText;
    [HideInInspector]
    public string symbolName1; // △kW
    [HideInInspector]
    public string symbolName2; // 알람상태

    private DataAgent dataAgent;
    private float timer = 0.0f;
    //private string result1;
    private string result2;
    private bool isTag = false;

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
            if (dataAgent.isAuto)
            {
                //result1 = randomValue(-10, 10).ToString();
                result2 = "0";
            }
            else
            {
                //result1 = dataAgent.getValueStringBySymbolName(symbolName1);
                result2 = dataAgent.getValueStringBySymbolName(symbolName2);
            }

            //value.text = result1;
            switch (result2) {
                case "-1.0000":
                    status.text = "Low";
                    break;

                case "0.0000":
                    status.text = "Normal";
                    break;

                case "1.0000":
                    status.text = "High";
                    break;

                default:
                    status.text = "Normal";
                    break;
            }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}