using System.Collections.Generic;
using UnityEngine;

public class RPASSimulationDataControl : MonoBehaviour
{
    public TextAsset fileOther;
    public SimulationMainControl simulationMainControl;
    public SimulationSAOCControl simulationSAOCControl;
    public SimulationSubControl[] simulationSubControls;

    private DataAgent dataAgent;
    private List<DataGroup> list = new List<DataGroup>();

    public struct DataGroup
    {
        public string symbolName1;
        public string defaultValue;
    }

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        InputDataToList(list, fileOther.name);
    }

    public void _ClickSendButton()
    {
        // Other
        for (int i = 0; i < list.Count; i++)
        {
            dataAgent.RPASSimulationInput(list[i].symbolName1, list[i].defaultValue, true);
        }

        // ----------------------------------------------------------------------------------------------------------------------------

        // UCM Dropdown
        dataAgent.RPASSimulationInput(simulationMainControl.uCMDropdownSymbolName, simulationMainControl.uCMDropdown.value.ToString(), false);

        // UCM 항목
        for (int i = 0; i < simulationMainControl.uCMStructs.Length; i++)
        {
            dataAgent.RPASSimulationInput(simulationMainControl.uCMStructs[i].symbolName1, simulationMainControl.uCMStructs[i].inputField.text, simulationMainControl.uCMStructs[i].status);
        }

        // ----------------------------------------------------------------------------------------------------------------------------

        // TCBC 항목
        for (int i = 0; i < simulationMainControl.tCBCStructs.Length; i++)
        {
            dataAgent.RPASSimulationInput(simulationMainControl.tCBCStructs[i].symbolName1, simulationMainControl.tCBCStructs[i].inputField.text, simulationMainControl.tCBCStructs[i].status);
        }

        // ----------------------------------------------------------------------------------------------------------------------------

        // CCM Dropdown
        dataAgent.RPASSimulationInput(simulationMainControl.cCMropdownSymbolName, simulationMainControl.cCMDropdown.value.ToString(), false);

        // CCM 항목
        for (int i = 0; i < simulationMainControl.cCMStructs.Length; i++)
        {
            dataAgent.RPASSimulationInput(simulationMainControl.cCMStructs[i].symbolName1, simulationMainControl.cCMStructs[i].inputField.text, simulationMainControl.cCMStructs[i].status);
        }

        // ----------------------------------------------------------------------------------------------------------------------------

        // SAOC 항목
        for (int i = 0; i < simulationSAOCControl.sAOCStructs.Length; i++)
        {
            dataAgent.RPASSimulationInput(simulationSAOCControl.sAOCStructs[i].symbolName1, simulationSAOCControl.sAOCStructs[i].status.ToString(), false);
        }

        // ----------------------------------------------------------------------------------------------------------------------------

        // Sub 항목
        for (int i = 0; i < simulationSubControls.Length; i++)
        {
            if (!simulationSubControls[i].isTBN)
            {
                for (int j = 0; j < simulationSubControls[i].subStructs.Length; j++)
                {
                    dataAgent.RPASSimulationInput(simulationSubControls[i].subStructs[j].symbolName1, simulationSubControls[i].subStructs[j].inputField.text, simulationSubControls[i].subStructs[j].status);
                }
            }
            else {
                for (int j = 1; j < simulationSubControls[i].subStructs.Length; j++)
                {
                    dataAgent.RPASSimulationInput(simulationSubControls[i].subStructs[j].symbolName1, simulationSubControls[i].subStructs[j].inputField.text, simulationSubControls[i].subStructs[j].status);
                }
            }
        }

        // ----------------------------------------------------------------------------------------------------------------------------

        dataAgent.RPASSimulationSend();

        simulationMainControl.ExecuteChangeData();
        for (int i = 0; i < simulationSubControls.Length; i++)
        {
            simulationSubControls[i].ExecuteChangeData();
        }
    }

    public void _ClickResetButton()
    {
        simulationMainControl.ExecuteReset();
        simulationSAOCControl._ClickSAOCValueReset();
        for (int i = 0; i < simulationSubControls.Length; i++)
        {
            simulationSubControls[i].ExecuteReset();
        }
    }

    private void InputDataToList(List<DataGroup> list, string fileName)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(fileName);
        for (int i = 0; i < data.Count; i++)
        {
            AddListItem(list, data[i]["SymbolName1"].ToString(), data[i]["DefaultValue"].ToString());
        }
    }

    private void AddListItem(List<DataGroup> list, string symbolName1, string defaultValue)
    {
        DataGroup item = new DataGroup();
        item.symbolName1 = symbolName1;
        item.defaultValue = defaultValue;
        list.Add(item);
    }
}