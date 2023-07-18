using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentAlarmHistory : MonoBehaviour
{
    public TextMeshProUGUI[] alarmHistoryData;
    public Image[] dayButton;

    [Space]
    public Sprite dateNormal;
    public Sprite dateSelected;

    private bool unit3 = false;
    private bool unit4 = false;
    private float timer = 0.0f;
    private int dateIndex = 0;
    private DataAgent dataAgent;

    //Day : 0
    // Week : 1 ~ 7
    // Month : 8 ~ 11
    // Year : 12 ~ 23                                                                                                                                                                                                                                                                                   
    private DataList[] values = new DataList[27];
    private DataList[] defaultValues = new DataList[27];

    private struct DataList { public List<int> list; }

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        if (dataAgent.GetPlantID() == "2811-")
        {
            unit3 = true;
            unit4 = false;
        }
        else
        {
            unit3 = false;
            unit4 = true;
        }
        for (int i = 0; i < 27; i++)
        {
            defaultValues[i].list = new List<int>();
            for (int j = 0; j < 10; j++)
            {
                defaultValues[i].list.Add(0);
            }
        }
    }

    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (dataAgent.isAuto) { values = defaultValues; }
            else
            {
                //Day : 0
                // Week : 1 ~ 7
                // Month : 8 ~ 11
                // Year : 12 ~ 23
                if (unit3)
                {
                    values[0].list = dataAgent.getAlarmHistoryUnit(3, 0, 0);
                    for (int i = 1; i < 8; i++) { values[i].list = dataAgent.getAlarmHistoryUnit(3, 1, i - 1); }
                    for (int i = 8; i < 12; i++) { values[i].list = dataAgent.getAlarmHistoryUnit(3, 2, i - 8); }
                    for (int i = 12; i < 24; i++) { values[i].list = dataAgent.getAlarmHistoryUnit(3, 3, i - 12); }
                }
                else if (unit4)
                {
                    values[0].list = dataAgent.getAlarmHistoryUnit(4, 0, 0);
                    for (int i = 1; i < 8; i++) { values[i].list = dataAgent.getAlarmHistoryUnit(4, 1, i - 1); }
                    for (int i = 8; i < 12; i++) { values[i].list = dataAgent.getAlarmHistoryUnit(4, 2, i - 8); }
                    for (int i = 12; i < 24; i++) { values[i].list = dataAgent.getAlarmHistoryUnit(4, 3, i - 12); }
                }
            }
            ChangeData();
        }
    }
    public void _ClickDate(int num)
    {
        dateIndex = num;
        ChangeData();
    }

    private void ChangeData()
    {
        for (int i = 0; i < dayButton.Length; i++)
        {
            if (i == dateIndex) { dayButton[i].sprite = dateSelected; }
            else { dayButton[i].sprite = dateNormal; }
        }

        for (int i = 0; i < alarmHistoryData.Length; i++)
        {

            if (unit3)
            {
                switch (dateIndex)
                {

                    //Day : 0
                    case 0:
                        int temp = values[0].list[i];
                        alarmHistoryData[i].text = temp + "";
                        break;
                    // Week : 1 ~ 7
                    case 1:
                        temp = values[1].list[i] + values[2].list[i] + values[3].list[i] + values[4].list[i] + values[5].list[i] + values[6].list[i] + values[7].list[i];
                        alarmHistoryData[i].text = temp + "";
                        break;

                    // Month : 8 ~ 11
                    case 2:
                        temp = values[8].list[i] + values[9].list[i] + values[10].list[i] + values[11].list[i];
                        alarmHistoryData[i].text = temp + "";
                        break;
                    // Year : 12 ~ 23
                    case 3:
                        temp = values[12].list[i] + values[13].list[i] + values[14].list[i] + values[15].list[i] + values[16].list[i] + values[17].list[i] + values[18].list[i] + values[19].list[i] + values[20].list[i] + values[21].list[i] + values[22].list[i] + values[23].list[i];
                        alarmHistoryData[i].text = temp + "";
                        break;
                }
            }
            else if (unit4)
            {
                switch (dateIndex)
                {
                    // Day : 0
                    case 0:
                        int temp = values[0].list[i + 5];
                        alarmHistoryData[i].text = temp + "";
                        break;

                    // Week : 1 ~ 7
                    case 1:
                        temp = values[1].list[i + 5] + values[2].list[i + 5] + values[3].list[i + 5] + values[4].list[i + 5] + values[5].list[i + 5] + values[6].list[i + 5] + values[7].list[i + 5];
                        alarmHistoryData[i].text = temp + "";
                        break;

                    // Month : 8 ~ 11
                    case 2:
                        temp = values[8].list[i + 5] + values[9].list[i + 5] + values[10].list[i + 5] + values[11].list[i + 5];
                        alarmHistoryData[i].text = temp + "";
                        break;

                    // Year : 12 ~ 23
                    case 3:
                        temp = values[12].list[i + 5] + values[13].list[i + 5] + values[14].list[i + 5] + values[15].list[i + 5] + values[16].list[i + 5] + values[17].list[i + 5] + values[18].list[i + 5] + values[19].list[i + 5] + values[20].list[i + 5] + values[21].list[i + 5] + values[22].list[i + 5] + values[23].list[i + 5];
                        alarmHistoryData[i].text = temp + "";
                        break;
                }
            }
            else { alarmHistoryData[i].text = "-"; }

        }
    }
}
