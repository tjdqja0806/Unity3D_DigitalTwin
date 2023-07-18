using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimulationSAOCControl : MonoBehaviour
{
    [Serializable]
    public struct SAOCStruct
    {
        public TMP_Dropdown dropdown;
        [HideInInspector]
        public int status;
        [HideInInspector]
        public string symbolName1;
    }

    public TextAsset file;
    public SAOCStruct[] sAOCStructs;

    void Awake()
    {
        InputDataToList(file.name);
        _ClickSAOCValueReset();
    }

    // index = MSR 1~6 / HTR 7~21
    public void _ClickSAOCValueChanged(int index)
    {
        sAOCStructs[index - 1].status = sAOCStructs[index - 1].dropdown.value + 1;

        if (sAOCStructs[index - 1].status == 3)
        {
            switch (index)
            {
                // HP HTR A Line
                case 7:
                case 9:
                case 11:
                    ChangeValue(1 - 1, 2);
                    ChangeValue(3 - 1, 2);
                    ChangeValue(5 - 1, 2);
                    ChangeValue(7 - 1, 3);
                    ChangeValue(9 - 1, 3);
                    ChangeValue(11 - 1, 3);
                    break;

                // HP HTR B Line
                case 8:
                case 10:
                case 12:
                    ChangeValue(2 - 1, 2);
                    ChangeValue(4 - 1, 2);
                    ChangeValue(6 - 1, 2);
                    ChangeValue(8 - 1, 3);
                    ChangeValue(10 - 1, 3);
                    ChangeValue(12 - 1, 3);
                    break;

                // LP HTR A Line
                case 13:
                case 16:
                case 19:
                    ChangeValue(13 - 1, 3);
                    ChangeValue(16 - 1, 3);
                    ChangeValue(19 - 1, 3);
                    break;

                // LP HTR B Line
                case 14:
                case 17:
                case 20:
                    ChangeValue(14 - 1, 3);
                    ChangeValue(17 - 1, 3);
                    ChangeValue(20 - 1, 3);
                    break;

                // LP HTR C Line
                case 15:
                case 18:
                case 21:
                    ChangeValue(15 - 1, 3);
                    ChangeValue(18 - 1, 3);
                    ChangeValue(21 - 1, 3);
                    break;
            }
        }
    }

    public void _ClickSAOCValueReset()
    {
        for (int i = 0; i < sAOCStructs.Length; i++)
        {
            ChangeValue(i, 1);
        }
    }

    private void ChangeValue(int index, int value)
    {
        sAOCStructs[index].dropdown.value = value - 1;
        sAOCStructs[index].status = value;
        sAOCStructs[index].dropdown.RefreshShownValue();
    }

    private void InputDataToList(string fileName)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(fileName);
        for (int i = 0; i < data.Count; i++)
        {
            AddListItem(i, data[i]["SymbolName1"].ToString());
        }
    }

    private void AddListItem(int index, string symbolName1)
    {
        sAOCStructs[index].symbolName1 = symbolName1;
    }
}