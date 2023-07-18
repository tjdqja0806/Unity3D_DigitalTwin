using TMPro;
using UnityEngine;

public class ScrollViewPHI : MonoBehaviour
{
    public TextMeshProUGUI description;
    public TextMeshProUGUI alarmValue;
    public TextMeshProUGUI alarmValueUnit;
    public TextMeshProUGUI expectedValue;
    public TextMeshProUGUI expectedValueUnit;
    public TextMeshProUGUI alarmIndex;
    public TextMeshProUGUI alarmIndexUnit;
    public TextMeshProUGUI alarmWarningLevel;
    [Space]
    public Color normal;
    public Color warning;
    [HideInInspector]
    public string descriptionText;
    [HideInInspector]
    public string symbolNameAlarmValue;
    [HideInInspector]
    public string symbolNameExpectedValue;
    [HideInInspector]
    public string symbolNameAlarmIndex;
    [HideInInspector]
    public string symbolNameAlarmWarningLevel;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private string resultAlarmValue;
    private string resultExpectedValue;
    private string resultAlarmIndex;
    private string resultAlarmWarningLevel;
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
            if (dataAgent.isAuto)
            {
                resultAlarmValue = randomValue(0, 100).ToString();
                resultExpectedValue = randomValue(0, 100).ToString();
                resultAlarmIndex = randomValue(0, 100).ToString();
                resultAlarmWarningLevel = randomValue(0, 3).ToString();
            }
            else
            {
                resultAlarmValue = dataAgent.getValueStringBySymbolName(symbolNameAlarmValue);
                resultExpectedValue = dataAgent.getValueStringBySymbolName(symbolNameExpectedValue);
                resultAlarmIndex = dataAgent.getValueStringBySymbolName(symbolNameAlarmIndex);
                resultAlarmWarningLevel = dataAgent.getValueStringBySymbolName(symbolNameAlarmWarningLevel);
            }
            alarmValue.text = resultAlarmValue;
            expectedValue.text = resultExpectedValue;
            alarmIndex.text = resultAlarmIndex;
            alarmWarningLevel.text = "Level " + string.Format("{0:N0}", float.Parse(resultAlarmWarningLevel));
            if (alarmWarningLevel.text.Equals("Level 0")) { alarmWarningLevel.color = normal; }
            else { alarmWarningLevel.color = warning; }
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
        if (isTag) { description.text = dataAgent.GetPlantID() + SymbolNameSplit(symbolNameAlarmValue); }
        else { description.text = descriptionText; }
    }

    private string SymbolNameSplit(string symbolName)
    {
        string temp = "";
        switch (symbolName.Split(char.Parse("_")).Length)
        {
            case 2:
                temp = symbolName.Split(char.Parse("_"))[0];
                break;
            case 3:
                temp = symbolName.Split(char.Parse("_"))[0]
                    + "_" + symbolName.Split(char.Parse("_"))[1];
                break;
            case 4:
                temp = symbolName.Split(char.Parse("_"))[0]
                    + "_" + symbolName.Split(char.Parse("_"))[1]
                    + "_" + symbolName.Split(char.Parse("_"))[2];
                break;
            case 5:
                temp = symbolName.Split(char.Parse("_"))[0]
                    + "_" + symbolName.Split(char.Parse("_"))[1]
                    + "_" + symbolName.Split(char.Parse("_"))[2]
                    + "_" + symbolName.Split(char.Parse("_"))[3];
                break;
        }
        return temp;
    }

    public void _ClickRealtimeTrend(int status)
    {
        switch (status)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}