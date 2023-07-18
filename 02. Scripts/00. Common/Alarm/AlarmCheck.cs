using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlarmCheck : MonoBehaviour
{
    public TextAsset fileAPD;
    public TextAsset filePHI;
    public TextAsset fileRPAS;
    public TextAsset fileCore;

    [HideInInspector]
    public List<DataGroup> alarmList = new List<DataGroup>();
    [HideInInspector]
    public int alarmCount = 0;
    public bool isAlarm = false;

    private List<DataGroup> listAPD = new List<DataGroup>();
    private List<DataGroup> listPHI = new List<DataGroup>();
    private List<DataGroup> listRPAS = new List<DataGroup>();
    private List<DataGroup> listCore = new List<DataGroup>();
    private DataAgent dataAgent;
    private List<string> beforeAPD = new List<string>();
    private List<string> beforePHI = new List<string>();
    private List<string> beforeRPAS = new List<string>();
    private List<string> beforeCore = new List<string>();

    private float timer = 0f;
    private float alarmTimer = 0f;
    private bool isFirst = true;
    private bool checkAlarmActive = false;

    public struct DataGroup
    {
        public string dataType;
        public string component;
        public string symbolName;
        public string description;
        public string alarmResult;
        public string apdType;
    }

    private void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        InputDataToList(listAPD, fileAPD.name);
        InputDataToList(listPHI, filePHI.name);
        InputDataToList(listRPAS, fileRPAS.name);
        InputDataToList(listCore, fileCore.name);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            timer = 0f;
            if (!dataAgent.isAuto)
            {
                if (isFirst)
                {
                    //AlarmDataFirstSave();
                }
                else
                {
                    //AlarmDataCompare();
                }
            }

            alarmCount = alarmList.Count;

            if (alarmCount != 0)
            {
                isAlarm = true;
                /*if(SceneManager.GetAllScenes().Length > 1)
                    SceneManager.UnloadSceneAsync(SceneManager.GetAllScenes()[1]);*/
                checkAlarmActive = true;
            }
            if (isAlarm && checkAlarmActive)
            {
                checkAlarmActive = false;
                SceneManager.LoadScene("100. Alarm", LoadSceneMode.Additive);
            }
        }
        /*else
        {
            alarmTimer += Time.deltaTime;
            if (alarmTimer >= 10f && isAlarm)
            {
                alarmTimer = 0;
                isAlarm = false;
                SceneManager.UnloadSceneAsync("100. Alarm");
            }
        }*/
    }

    private void AlarmDataFirstSave()
    {
        for (int i = 0; i < listAPD.Count; i++)
        {
            beforeAPD.Add(dataAgent.getValueStringBySymbolName(listAPD[i].symbolName));
        }
        for (int i = 0; i < listPHI.Count; i++)
        {
            beforePHI.Add(dataAgent.getValueStringBySymbolName(listPHI[i].symbolName));
        }
        for (int i = 0; i < listRPAS.Count; i++)
        {
            beforeRPAS.Add(dataAgent.getValueStringBySymbolName(listRPAS[i].symbolName));
        }
        for (int i = 0; i < listCore.Count; i++)
        {
            beforeCore.Add(dataAgent.getValueStringBySymbolName(listCore[i].symbolName));
        }
        isFirst = false;
    }

    private void AlarmDataCompare()
    {
        for (int i = 0; i < listAPD.Count; i++)
        {
            if (dataAgent.getValueStringBySymbolName(listAPD[i].symbolName) != beforeAPD[i])    // 이전 값과 동일한지 체크
            {
                beforeAPD[i] = dataAgent.getValueStringBySymbolName(listAPD[i].symbolName);
                if (beforeAPD[i] != "0.0000"   // 현재 정상 데이터는 "0"
                    || beforeAPD[i] != "40.0000"    // 확인 필요
                    || beforeAPD[i] != "60.0000"    // 확인 필요
                    || beforeAPD[i] != "80.0000"    // 확인 필요
                    )
                {
                    Debug.Log("APD Error Value : " + beforeAPD[i]);
                    DataGroup item = new DataGroup();
                    item.dataType = listAPD[i].dataType;
                    item.component = listAPD[i].component;
                    item.symbolName = listAPD[i].symbolName;
                    item.description = listAPD[i].description;
                    item.alarmResult = dataAgent.getValueStringBySymbolName(listAPD[i].symbolName);
                    item.apdType = listAPD[i].apdType;
                    alarmList.Add(item);
                }
            }
        }
        for (int i = 0; i < listPHI.Count; i++)
        {
            if (dataAgent.getValueStringBySymbolName(listPHI[i].symbolName) != beforePHI[i])    // 이전 값과 동일한지 체크
            {
                beforePHI[i] = dataAgent.getValueStringBySymbolName(listPHI[i].symbolName);
                if (beforePHI[i] != "0.0000"   // 현재 정상 데이터는 "0"
                    || beforePHI[i] != "-"   // 신호 확인 필요
                    )
                {
                    Debug.Log("PHI Error Value : " + beforePHI[i]);
                    DataGroup item = new DataGroup();
                    item.dataType = listPHI[i].dataType;
                    item.component = listPHI[i].component;
                    item.symbolName = listPHI[i].symbolName;
                    item.description = listPHI[i].description;
                    item.alarmResult = "Level" + dataAgent.getValueStringBySymbolName(listPHI[i].symbolName);
                    item.apdType = listPHI[i].apdType;
                    alarmList.Add(item);
                }
            }
        }
        for (int i = 0; i < listRPAS.Count; i++)
        {
            if (dataAgent.getValueStringBySymbolName(listRPAS[i].symbolName) != beforeRPAS[i])    // 이전 값과 동일한지 체크
            {
                beforeRPAS[i] = dataAgent.getValueStringBySymbolName(listRPAS[i].symbolName);
                if (beforeRPAS[i] != "0.0000"   // 현재 -1 (Low), 0 (Normal), 1 (High)로 들어옴
                    || beforeRPAS[i] != "1.0000"
                    || beforeRPAS[i] != "-1.0000"
                    || beforeRPAS[i] != "2.0000"   // 확인 필요
                    || beforeRPAS[i] != "-"   // 신호 확인 필요
                    )
                {
                    Debug.Log("R-PAS Error Value : " + beforeRPAS[i]);
                    DataGroup item = new DataGroup();
                    item.dataType = listRPAS[i].dataType;
                    item.component = listRPAS[i].component;
                    item.symbolName = listRPAS[i].symbolName;
                    item.description = listRPAS[i].description;
                    item.alarmResult = dataAgent.getValueStringBySymbolName(listRPAS[i].symbolName);
                    item.apdType = listRPAS[i].apdType;
                    alarmList.Add(item);
                }
            }
        }
        for (int i = 0; i < listCore.Count; i++)
        {
            if (dataAgent.getValueStringBySymbolName(listCore[i].symbolName) != beforeCore[i])    // 이전 값과 동일한지 체크
            {                
                beforeCore[i] = dataAgent.getValueStringBySymbolName(listCore[i].symbolName);
                if (beforeCore[i] != "0.0000")   // 현재 정상 데이터는 "0"
                {
                    Debug.Log("Core Error Value : " + beforeCore[i]);
                    DataGroup item = new DataGroup();
                    item.dataType = listCore[i].dataType;
                    item.component = listCore[i].component;
                    item.symbolName = listCore[i].symbolName;
                    item.description = listCore[i].description;
                    item.alarmResult = dataAgent.getValueStringBySymbolName(listCore[i].symbolName);
                    item.apdType = listCore[i].apdType;
                    alarmList.Add(item);
                }
            }
        }
    }

    private void InputDataToList(List<DataGroup> list, string fileName)
    {
        List<Dictionary<string, object>> data = CSVReader.Read(fileName);
        for (int i = 0; i < data.Count; i++)
        {
            if (fileName.Contains("APD"))
            {
                AddListItem(list, "AIMD", data[i]["Component"].ToString(), data[i]["SymbolName"].ToString(), data[i]["Description"].ToString(), "", data[i]["구분"].ToString());
            }
            if (fileName.Contains("PHI"))
            {
                AddListItem(list, "K-EWS", data[i]["Component"].ToString(), data[i]["SymbolName"].ToString(), data[i]["Description"].ToString(), "", "");
            }
            if (fileName.Contains("RPAS"))
            {
                AddListItem(list, "R-PAS", data[i]["Component"].ToString(), data[i]["SymbolName"].ToString(), data[i]["Description"].ToString(), "", "");
            }
            if (fileName.Contains("Core"))
            {
                AddListItem(list, "Core", "Core", data[i]["SymbolName"].ToString(), data[i]["Description"].ToString(), "", "");
            }
        }
    }

    private void AddListItem(List<DataGroup> list, string dataType, string component, string symbolName, string description, string alarmResult, string apdType)
    {
        DataGroup item = new DataGroup();
        item.dataType = dataType;
        item.component = component;
        item.symbolName = symbolName;
        item.description = description;
        item.alarmResult = alarmResult;
        item.apdType = apdType;
        list.Add(item);
    }


    public void ExitAlarmScene()
    {
        isAlarm = false;
        alarmList.Clear();

        SceneManager.UnloadSceneAsync("100. Alarm");
    }
}