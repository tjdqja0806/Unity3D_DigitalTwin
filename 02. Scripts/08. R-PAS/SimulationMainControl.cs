using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimulationMainControl : MonoBehaviour
{
    [Serializable]
    public struct UCMStruct
    {
        public TextMeshProUGUI text;
        public TMP_InputField inputField;
        public TextMeshProUGUI inputText;
        public int digit;
        [HideInInspector]
        public bool status;
        [HideInInspector]
        public string symbolName1;
        [HideInInspector]
        public string symbolName2;
        [HideInInspector]
        public double defaultValue;
        [HideInInspector]
        public double changeValue;
    }

    [Serializable]
    public struct TCBCStruct
    {
        public TMP_InputField inputField;
        public TextMeshProUGUI inputText;
        public int digit;
        [HideInInspector]
        public bool status;
        [HideInInspector]
        public string symbolName1;
        [HideInInspector]
        public string symbolName2;
        [HideInInspector]
        public double defaultValue;
        [HideInInspector]
        public double changeValue;
    }

    [Serializable]
    public struct CCMStruct
    {
        public TextMeshProUGUI text;
        public TMP_InputField inputField;
        public TextMeshProUGUI inputText;
        public int digit;
        [HideInInspector]
        public bool status;
        [HideInInspector]
        public string symbolName1;
        [HideInInspector]
        public string symbolName2;
        [HideInInspector]
        public double defaultValue;
        [HideInInspector]
        public double changeValue;
    }

    public TextAsset fileUCM;
    public TMP_Dropdown uCMDropdown;
    [HideInInspector]
    public string uCMDropdownSymbolName;
    public UCMStruct[] uCMStructs;
    [Space]
    public TextAsset fileTCBC;
    public TCBCStruct[] tCBCStructs;
    [Space]
    public TextAsset fileCCM;
    public TMP_Dropdown cCMDropdown;
    [HideInInspector]
    public string cCMropdownSymbolName;
    public CCMStruct[] cCMStructs;
    [Space]
    public Color changeColor;
    [HideInInspector]
    public bool isResult = false;

    private DataAgent dataAgent;


    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();

        InputDataToList(fileUCM.name);
        InputDataToList(fileTCBC.name);
        InputDataToList(fileCCM.name);
    }
    void Start()
    {
        _ClickUCMValueChanged();
        TCBCValue();
        _ClickCCMValueChanged();
    }

    void Update()
    {
        if (isResult)
        {
            for (int i = 0; i < uCMStructs.Length; i++)
            {                
                uCMStructs[i].changeValue = double.Parse(dataAgent.getValueStringBySymbolName(uCMStructs[i].symbolName2));
                uCMStructs[i].inputText.color = changeColor;
                uCMStructs[i].inputField.interactable = false;
                uCMStructs[i].inputField.text = Digits(uCMStructs[i].changeValue, uCMStructs[i].digit);
            }
            for (int i = 0; i < tCBCStructs.Length; i++)
            {
                tCBCStructs[i].changeValue = double.Parse(dataAgent.getValueStringBySymbolName(tCBCStructs[i].symbolName2));
                tCBCStructs[i].inputText.color = changeColor;
                tCBCStructs[i].inputField.interactable = false;
                tCBCStructs[i].inputField.text = Digits(tCBCStructs[i].changeValue, tCBCStructs[i].digit);
            }
            for (int i = 0; i < cCMStructs.Length; i++)
            {
                cCMStructs[i].changeValue = double.Parse(dataAgent.getValueStringBySymbolName(cCMStructs[i].symbolName2));
                cCMStructs[i].inputText.color = changeColor;
                cCMStructs[i].inputField.interactable = false;
                cCMStructs[i].inputField.text = Digits(cCMStructs[i].changeValue, cCMStructs[i].digit);
            }
        }
    }

    // ------------------------------------------------------------------------

    // Unit Control Method

    // Dropdown Value가 변경될 경우 실행
    public void _ClickUCMValueChanged()
    {
        if (!isResult)
        {
            for (int i = 0; i < uCMStructs.Length; i++)
            {
                if (i == uCMDropdown.value)
                {
                    uCMStructs[i].text.text = "Manual";
                    uCMStructs[i].inputText.color = Color.white;
                    uCMStructs[i].status = false;
                    uCMStructs[i].inputField.interactable = true;
                }
                else
                {
                    uCMStructs[i].text.text = "Auto";
                    uCMStructs[i].inputText.color = Color.gray;
                    uCMStructs[i].status = true;
                    uCMStructs[i].inputField.interactable = false;
                }
                uCMStructs[i].inputField.text = Digits(uCMStructs[i].defaultValue, uCMStructs[i].digit);
            }
        }
    }

    // ------------------------------------------------------------------------

    // Turbine Cycle Boundary Conditions

    // Dropdown Value가 변경될 경우 실행
    public void TCBCValue()
    {
        if (!isResult)
        {
            for (int i = 0; i < tCBCStructs.Length; i++)
            {
                tCBCStructs[i].inputField.text = Digits(tCBCStructs[i].defaultValue, tCBCStructs[i].digit);
                tCBCStructs[i].status = false;
            }
        }
    }

    // ------------------------------------------------------------------------

    // Condenser Calculation Method

    // Dropdown Value가 변경될 경우 실행
    public void _ClickCCMValueChanged()
    {
        if (!isResult)
        {
            for (int i = 0; i < cCMStructs.Length; i++)
            {
                if (i == cCMDropdown.value)
                {
                    cCMStructs[i].text.text = "Manual";
                    cCMStructs[i].inputText.color = Color.white;
                    cCMStructs[i].status = false;
                    cCMStructs[i].inputField.interactable = true;
                }
                else
                {
                    cCMStructs[i].text.text = "Auto";
                    cCMStructs[i].inputText.color = Color.gray;
                    cCMStructs[i].status = true;
                    cCMStructs[i].inputField.interactable = false;
                }
                cCMStructs[i].inputField.text = Digits(cCMStructs[i].defaultValue, cCMStructs[i].digit);
            }
        }
    }

    // ------------------------------------------------------------------------

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

    // 데이터를 변경하는 부분 - 타 스크립트에서 실행 (5초마다 데이터 갱신)
    public void ExecuteChangeData()
    {
        isResult = true;
    }

    // 원상복귀하는 부분 - 타 스크립트에서 실행
    public void ExecuteReset()
    {
        isResult = false;
        _ClickUCMValueChanged();
        for (int i = 0; i < tCBCStructs.Length; i++)
        {
            tCBCStructs[i].inputText.color = Color.white;
            tCBCStructs[i].inputField.interactable = true;
            tCBCStructs[i].inputField.text = Digits(tCBCStructs[i].defaultValue, tCBCStructs[i].digit);
        }
        _ClickCCMValueChanged();
    }

    private void InputDataToList(string fileName)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(fileName);
        if (fileName.Contains("UCM"))
        {
            uCMDropdownSymbolName = data[0]["SymbolName1"].ToString();
            for (int i = 1; i < data.Count; i++)
            {
                AddListItemUCM(i, data[i]["SymbolName1"].ToString(), data[i]["SymbolName2"].ToString(), data[i]["DefaultValue"].ToString());
            }
        }
        if (fileName.Contains("TCBC"))
        {
            for (int i = 0; i < data.Count; i++)
            {
                AddListItemTCBC(i, data[i]["SymbolName1"].ToString(), data[i]["SymbolName2"].ToString(), data[i]["DefaultValue"].ToString());
            }
        }
        if (fileName.Contains("CCM"))
        {
            cCMropdownSymbolName = data[0]["SymbolName1"].ToString();
            AddListItemTCBC(10, data[1]["SymbolName1"].ToString(), data[1]["SymbolName2"].ToString(), data[1]["DefaultValue"].ToString());
            for (int i = 2; i < data.Count; i++)
            {
                AddListItemCCM(i, data[i]["SymbolName1"].ToString(), data[i]["SymbolName2"].ToString(), data[i]["DefaultValue"].ToString());
            }
        }
    }

    private void AddListItemUCM(int index, string symbolName1, string symbolName2, string defaultValue)
    {
        uCMStructs[index - 1].symbolName1 = symbolName1;
        uCMStructs[index - 1].symbolName2 = symbolName2;
        uCMStructs[index - 1].defaultValue = double.Parse(defaultValue);
    }

    private void AddListItemTCBC(int index, string symbolName1, string symbolName2, string defaultValue)
    {
        tCBCStructs[index].symbolName1 = symbolName1;
        tCBCStructs[index].symbolName2 = symbolName2;
        tCBCStructs[index].defaultValue = double.Parse(defaultValue);
    }

    private void AddListItemCCM(int index, string symbolName1, string symbolName2, string defaultValue)
    {
        cCMStructs[index - 2].symbolName1 = symbolName1;
        cCMStructs[index - 2].symbolName2 = symbolName2;
        cCMStructs[index - 2].defaultValue = double.Parse(defaultValue);
    }
}