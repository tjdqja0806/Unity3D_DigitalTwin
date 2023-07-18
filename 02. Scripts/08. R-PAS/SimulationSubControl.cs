using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimulationSubControl : MonoBehaviour
{
    [Serializable]
    public struct SubStruct
    {
        public TMP_Dropdown dropdown;
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

    public TextAsset file;
    public Color changeColor;
    public SubStruct[] subStructs;
    [HideInInspector]
    public bool isTBN = false;

    private DataAgent dataAgent;
    private bool isResult = false;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();

        if (subStructs[0].dropdown == null) { isTBN = true; }
        else { isTBN = false; }

        InputDataToList(file.name);
        if (!isTBN)
        {
            for (int i = 0; i < subStructs.Length; i++)
            {
                _ClickSubValueChanged(i);
            }
        }
        else
        {
            for (int i = 1; i < subStructs.Length; i++)
            {
                _ClickSubValueChanged(i);
            }
        }
    }

    void Update()
    {
        if (isResult)
        {
            for (int i = 0; i < subStructs.Length; i++)
            {
                //subStructs[i].changeValue = double.Parse(dataAgent.getValueStringBySymbolName(subStructs[i].symbolName2));
                //subStructs[i].inputText.color = changeColor;
                subStructs[i].inputField.interactable = false;
                //subStructs[i].inputField.text = Digits(subStructs[i].changeValue, subStructs[i].digit);
            }
        }
    }

    // Dropdown Value가 변경될 경우 실행
    public void _ClickSubValueChanged(int index)
    {
        if (!isResult)
        {
            if (subStructs[index].dropdown.value == 1)
            {
                subStructs[index].inputText.color = Color.white;
                subStructs[index].status = false;
                subStructs[index].inputField.interactable = true;
            }
            else
            {
                subStructs[index].inputText.color = Color.gray;
                subStructs[index].status = true;
                subStructs[index].inputField.interactable = false;
            }
            subStructs[index].inputField.text = Digits(subStructs[index].defaultValue, subStructs[index].digit);
        }
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

    // 데이터를 변경하는 부분 - 타 스크립트에서 실행 (5초마다 데이터 갱신)
    public void ExecuteChangeData()
    {
        isResult = true;
    }

    // 원상복귀하는 부분 - 타 스크립트에서 실행
    public void ExecuteReset()
    {
        isResult = false;
        if (!isTBN)
        {
            for (int i = 0; i < subStructs.Length; i++)
            {
                _ClickSubValueChanged(i);
            }
        }
        else
        {
            subStructs[0].inputText.color = Color.white;
            subStructs[0].status = false;
            subStructs[0].inputField.interactable = true;

            for (int i = 1; i < subStructs.Length; i++)
            {
                _ClickSubValueChanged(i);
            }
        }
    }

    private void InputDataToList(string fileName)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(fileName);
        for (int i = 0; i < data.Count; i++)
        {
            AddListItem(i, data[i]["SymbolName1"].ToString(), data[i]["SymbolName2"].ToString(), data[i]["DefaultValue"].ToString());
        }
    }

    private void AddListItem(int index, string symbolName1, string symbolName2, string defaultValue)
    {
        subStructs[index].symbolName1 = symbolName1;
        subStructs[index].symbolName2 = symbolName2;
        subStructs[index].defaultValue = double.Parse(defaultValue);
    }
}