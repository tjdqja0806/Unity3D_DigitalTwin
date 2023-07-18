using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RPASArrowPrefabContent : MonoBehaviour
{
    public TextMeshProUGUI mainTitle;
    public TextMeshProUGUI subTitle;
    [HideInInspector] public string fTagName;
    [HideInInspector] public string pTagName;
    [HideInInspector] public string tTagName;
    [HideInInspector] public string hTagName;
    [HideInInspector] public string mTagName;
    [HideInInspector] public string fDigit;
    [HideInInspector] public string pDigit;
    [HideInInspector] public string tDigit;
    [HideInInspector] public string hDigit;
    [HideInInspector] public string mDigit;

    [SerializeField] TextMeshProUGUI fValue;
    [SerializeField] TextMeshProUGUI pValue;
    [SerializeField] TextMeshProUGUI tValue;
    [SerializeField] TextMeshProUGUI hValue;
    [SerializeField] TextMeshProUGUI mValue;

    private DataAgent dataAgent;
    private void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        UpdateValue();
    }
    private void OnEnable()
    {
        UpdateValue();
    }
    public void UpdateValue()
    {
        if (dataAgent.isAuto)
        {
            fValue.text = randomValue(0, 100).ToString();
            pValue.text = randomValue(0, 100).ToString();
            tValue.text = randomValue(0, 100).ToString();
            hValue.text = randomValue(0, 100).ToString();
            mValue.text = randomValue(0, 100).ToString();
        }
        else
        {
            if(fTagName == "-") { fValue.text = "-"; }
            else { fValue.text = Digits(dataAgent.getValueBySymbolName(fTagName), fDigit); }

            if (pTagName == "-") { pValue.text = "-"; }
            else{ pValue.text = Digits(dataAgent.getValueBySymbolName(pTagName), pDigit); }

            if (tTagName == "-") { tValue.text = "-"; }
            else { tValue.text = Digits(dataAgent.getValueBySymbolName(tTagName), tDigit); }

            if (hTagName == "-") { hValue.text = "-"; }
            else { hValue.text = Digits(dataAgent.getValueBySymbolName(hTagName), hDigit); }

            if (mTagName == "-") { mValue.text = "-"; }
            else { mValue.text = Digits(dataAgent.getValueBySymbolName(mTagName), mDigit); }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
    private string Digits(double value, string index)
    {
        string temp = "";
        switch (index)
        {
            case "0":
                temp = value.ToString("N0");
                break;
            case "1":
                temp = value.ToString("N1");
                break;
            case "2":
                temp = value.ToString("N2");
                break;
            case "3":
                temp = value.ToString("N3");
                break;
            case "4":
                temp = value.ToString("N4");
                break;
        }
        return temp;
    }
}
