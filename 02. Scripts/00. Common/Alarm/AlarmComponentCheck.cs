using System;
using System.Collections.Generic;
using UnityEngine;

public class AlarmComponentCheck : MonoBehaviour
{
    [Serializable]
    public struct AlarmData
    {
        public TextAsset file;                  //CSV파일 변수
        public string[] symbolName;         //CSV의 SymbolName 변수
        public string[] componentName;    //CSV의 Component 변수
    }
    public AlarmData[] alarmData;

    //APD, PHI, RPAS, Core의 Value 변수
    public string[] valueAPD;
    public float[] valuePHI;
    public float[] valueRPAS;
    public string[] valueCore;

    List<Dictionary<string, object>> dataAPD;
    List<Dictionary<string, object>> dataPHI;
    List<Dictionary<string, object>> dataRPAS;
    List<Dictionary<string, object>> dataCore;

    public AlarmSwitchCase alarmSwitchCase;

    private DataAgent dataAgent;
    private float timer = 0f;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSyetem").GetComponent<DataAgent>();

        //CSV파일 변수 대입
        dataAPD = CSVReader.Read(alarmData[0].file.name);
        dataPHI = CSVReader.Read(alarmData[1].file.name);
        dataRPAS = CSVReader.Read(alarmData[2].file.name);
        dataCore = CSVReader.Read(alarmData[3].file.name);

        //CSV파일로 부터 SymbolName, Component 읽어오기
        for (int i = 0; i < dataAPD.Count; i++)
        {
            alarmData[0].symbolName[i] = dataAPD[i]["SymbolName"].ToString();
            alarmData[0].componentName[i] = dataAPD[i]["Component"].ToString();
        }

        for (int i = 0; i < dataPHI.Count; i++)
        {
            alarmData[1].symbolName[i] = dataPHI[i]["SymbolName"].ToString();
            alarmData[1].componentName[i] = dataPHI[i]["Component"].ToString();
        }

        for (int i = 0; i < dataRPAS.Count; i++)
        {
            alarmData[2].symbolName[i] = dataRPAS[i]["SymbolName"].ToString();
            alarmData[2].componentName[i] = dataRPAS[i]["Component"].ToString();
        }

        for (int i = 0; i < dataCore.Count; i++)
        {
            alarmData[3].symbolName[i] = dataCore[i]["SymbolName"].ToString();
            alarmData[3].componentName[i] = dataCore[i]["Component"].ToString();
        }

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            timer = 0f;

            for (int i = 0; i < dataAPD.Count; i++)
            {
                valueAPD[i] = dataAgent.getValueBySymbolName(alarmData[0].symbolName[i]).ToString();
                if (valueAPD[i] != "Normal")
                {
                    alarmSwitchCase.componentName = alarmData[0].componentName[i];
                    alarmSwitchCase.alarmTypeText.text = alarmData[0].file.name;
                    alarmSwitchCase.alarmContent.text = valueAPD[i];
                }
            }
            for (int i = 0; i < dataPHI.Count; i++)
            {
                valuePHI[i] = (float)dataAgent.getValueBySymbolName(alarmData[1].symbolName[i]);
                if (valuePHI[i] != 0)
                {
                    alarmSwitchCase.componentName = alarmData[1].componentName[i];
                    alarmSwitchCase.alarmTypeText.text = alarmData[1].file.name;
                    alarmSwitchCase.alarmContent.text = valuePHI[i].ToString();
                }
            }
            for (int i = 0; i < dataRPAS.Count; i++)
            {
                valueRPAS[i] = (float)dataAgent.getValueBySymbolName(alarmData[2].symbolName[i]);
                if (valueRPAS[i] != 0)
                {
                    alarmSwitchCase.componentName = alarmData[2].componentName[i];
                    alarmSwitchCase.alarmTypeText.text = alarmData[2].file.name;
                    alarmSwitchCase.alarmContent.text = valueRPAS[i].ToString();
                }
            }
            for (int i = 0; i < dataCore.Count; i++)
            {
                valueCore[i] = dataAgent.getValueBySymbolName(alarmData[3].symbolName[i]).ToString();
                if (valueCore[i] != "Normal")
                {
                    alarmSwitchCase.componentName = alarmData[3].componentName[i];
                    alarmSwitchCase.alarmTypeText.text = alarmData[3].file.name;
                    alarmSwitchCase.alarmContent.text = valueCore[i];
                }
            }
        }
    }
}