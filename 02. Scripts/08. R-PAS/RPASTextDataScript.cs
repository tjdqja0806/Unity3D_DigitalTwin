using TMPro;
using UnityEngine;

public class RPASTextDataScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    [Space]
    public string symbolName;
    public float min;
    public float max;
    public int digitIndex = 1;

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
            //text.text = float.Parse(string.Format("{0:N1}", value)) + "";
            text.text = Digits(value, digitIndex);
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
    private string Digits(double value, int index)
    {
        string temp = "";
        switch (index)
        {
            case 0:
                temp = value.ToString("N0");
                break;
            case 1:
                temp = value.ToString("N1");
                break;
            case 2:
                temp = value.ToString("N2");
                break;
            case 3:
                temp = value.ToString("N3");
                break;
            case 4:
                temp = value.ToString("N4");
                break;
        }
        return temp;
    }
}
