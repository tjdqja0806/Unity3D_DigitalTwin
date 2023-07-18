using ChartAndGraph;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableBarChartControl : MonoBehaviour
{
    [Serializable]
    public struct GraphStruct
    {
        public TextMeshProUGUI sk3Data;
        public TextMeshProUGUI sk4Data;
        public Image button;
        public TextMeshProUGUI text;
    }

    [Serializable]
    public struct DateStruct
    {
        public Image button;
        public CanvasGroup cg;
        public BarChart bar;
    }

    [Header("Graph Attribute")]
    public GraphStruct[] graphStructs;
    [Space]
    public GameObject dropdown;
    public Sprite graphNormal;
    public Sprite graphSelected;
    public TextMeshProUGUI barChartTitle;

    [Header("Date Attribute")]
    public DateStruct[] dateStructs;
    [Space]
    public Sprite dateNormal;
    public Sprite dateSelected;
    [Space]
    public bool unit3 = true;
    public bool unit4 = true;
    [Space]
    public GameObject window;

    private float timer = 0.0f;
    private int graphIndex = 0;
    private int dateIndex = 0;
    private bool isDropdown = false;
    [Space]
    private float min = 0;
    private float max = 999;
    private DataAgent dataAgent;

    // Day : 0 ~ 3
    // Week : 4 ~ 10
    // Month : 11 ~ 14
    // Year : 15 ~ 26                                                                                                                                                                                                                                                                                        
    private DataList[] values = new DataList[27];
    private DataList[] defaultValues = new DataList[27];

    private struct DataList { public List<int> list; }

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
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
        barChartTitle.text = TitleModify();
        for (int i = 0; i < dateStructs.Length; i++)
        {
            if (i == dateIndex) { dateStructs[i].cg.alpha = 1; }
            else { dateStructs[i].cg.alpha = 0; }
        }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (dataAgent.isAuto) { values = defaultValues; }
            else
            {
                if (unit3 && unit4)
                {
                    //Day : 0
                    // Week : 1 ~ 7
                    // Month : 8 ~ 11
                    // Year : 12 ~ 23
                    values[0].list = dataAgent.getAlarmHistoryAll(0, 0);
                    for (int i = 1; i < 8; i++) { values[i].list = dataAgent.getAlarmHistoryAll(1, i - 1); }
                    for (int i = 8; i < 12; i++) { values[i].list = dataAgent.getAlarmHistoryAll(2, i - 8); }
                    for (int i = 12; i < 24; i++) { values[i].list = dataAgent.getAlarmHistoryAll(3, i - 12); }
                }
                else if (unit3)
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
            for (int i = 0; i < 27; i++)
            ChangeData();
        }
    }

    private string TitleModify()
    {
        string date = "";
        string graph = "";

        switch (dateIndex)
        {
            case 0:
                date = "Day";
                break;
            case 1:
                date = "Week";
                break;
            case 2:
                date = "Month";
                break;
            case 3:
                date = "Year";
                break;
        }

        switch (graphIndex)
        {
            case 0:
                graph = "K-EWS";
                break;
            case 1:
                graph = "AIMD";
                break;
            case 2:
                graph = "R-PAS";
                break;
            case 3:
                graph = "Core";
                break;
            case 4:
                graph = "Total";
                break;
        }

        return date + " " + graph + " History";
    }

    public void _ClickDataType(int num)
    {
        graphIndex = num;
        ChangeData();
    }

    public void _ClickDate(int num)
    {
        dateIndex = num;
        ChangeData();
    }

    public void _ClickDropdown()
    {
        isDropdown = !isDropdown;
        dropdown.SetActive(isDropdown);
    }

    public void _ClickWindow(bool active) { dataAgent.ClickAlarmHistoryValue(); }

    private void ChangeData()
    {
        
        switch (dateIndex)
        {
            // Day : 0 
            case 0:
                if (unit3 && unit4)
                {
                    dateStructs[0].bar.DataSource.SetValue(1 + "", "All", values[0].list[graphIndex] + values[0].list[graphIndex + 5]);
                }
                else
                {
                    if (unit3) { dateStructs[0].bar.DataSource.SetValue(1 + "", "All", values[0].list[graphIndex]); }
                    else if (unit4) { dateStructs[0].bar.DataSource.SetValue(1 + "", "All", values[0].list[graphIndex + 5]); }
                }
                break;

            // Week : 1 ~ 7
            case 1:
                for (int i = 1; i < 8; i++)
                {
                    if (unit3 && unit4)
                    {
                        dateStructs[1].bar.DataSource.SetValue(i + "", "All", values[i].list[graphIndex] + values[i].list[graphIndex + 5]);
                    }
                    else
                    {
                        if (unit3) { dateStructs[1].bar.DataSource.SetValue(i + "", "All", values[i].list[graphIndex]); }
                        else if (unit4) { dateStructs[1].bar.DataSource.SetValue(i + "", "All", values[i].list[graphIndex + 5]); }
                    }
                }
                break;

            // Month : 8 ~ 11
            case 2:
                for (int i = 1; i < 5; i++)
                {
                    if (unit3 && unit4)
                    {
                        dateStructs[2].bar.DataSource.SetValue(i + "", "All", values[i + 7].list[graphIndex] + values[i + 10].list[graphIndex + 5]);
                    }
                    else
                    {
                        if (unit3) { dateStructs[2].bar.DataSource.SetValue(i + "", "All", values[i + 7].list[graphIndex]); }
                        else if (unit4) { dateStructs[2].bar.DataSource.SetValue(i + "", "All", values[i + 7].list[graphIndex + 5]); }
                    }
                }
                break;

            // Year : 12 ~ 23
            case 3:
                for (int i = 1; i < 13; i++)
                {
                    if (unit3 && unit4)
                    {
                        dateStructs[3].bar.DataSource.SetValue(i + "", "All", values[i + 11].list[graphIndex] + values[i + 11].list[graphIndex + 5]);
                    }
                    else
                    {
                        if (unit3) { dateStructs[3].bar.DataSource.SetValue(i + "", "All", values[i + 11].list[graphIndex]); }
                        else if (unit4) { dateStructs[3].bar.DataSource.SetValue(i + "", "All", values[i + 11].list[graphIndex + 5]); }
                    }
                }
                break;
        }

        for (int i = 0; i < dateStructs.Length; i++)
        {
            if (i == dateIndex) { dateStructs[i].button.sprite = dateSelected; }
            else { dateStructs[i].button.sprite = dateNormal; }
        }

        for (int i = 0; i < graphStructs.Length; i++)
        {
            if (i == graphIndex)
            {
                graphStructs[i].button.sprite = graphSelected;
                graphStructs[i].text.color = Color.black;
            }
            else
            {
                graphStructs[i].button.sprite = graphNormal;
                graphStructs[i].text.color = Color.white;
            }
        }

        for (int i = 0; i < graphStructs.Length; i++)
        {
            if (unit3 && unit4)
            {
                switch (dateIndex)
                {
                    // Day : 0
                    case 0:
                        int temp = values[0].list[i];
                        graphStructs[i].sk3Data.text = temp + "";
                        temp = values[0].list[i + 5];
                        graphStructs[i].sk4Data.text = temp + "";
                        break;

                    // Week : 1 ~ 7
                    case 1:
                        temp = values[1].list[i] + values[2].list[i] + values[3].list[i] + values[4].list[i] + values[5].list[i] + values[6].list[i] + values[7].list[i];
                        graphStructs[i].sk3Data.text = temp + "";
                        temp = values[1].list[i + 5] + values[2].list[i + 5] + values[3].list[i + 5] + values[4].list[i + 5] + values[5].list[i + 5] + values[6].list[i + 5] + values[7].list[i + 5];
                        graphStructs[i].sk4Data.text = temp + "";
                        break;

                    // Month : 8 ~ 11
                    case 2:
                        temp = values[8].list[i] + values[9].list[i] + values[10].list[i] + values[11].list[i];
                        graphStructs[i].sk3Data.text = temp + "";
                        temp = values[8].list[i + 5] + values[9].list[i + 5] + values[10].list[i + 5] + values[11].list[i + 5];
                        graphStructs[i].sk4Data.text = temp + "";
                        break;

                    // Year : 12 ~ 23
                    case 3:
                        temp = values[12].list[i] + values[13].list[i] + values[14].list[i] + values[15].list[i] + values[16].list[i] + values[17].list[i] + values[18].list[i] + values[19].list[i] + values[20].list[i] + values[21].list[i] + values[22].list[i] + values[23].list[i];
                        graphStructs[i].sk3Data.text = temp + "";
                        temp = values[12].list[i + 5] + values[13].list[i + 5] + values[14].list[i + 5] + values[15].list[i + 5] + values[16].list[i + 5] + values[17].list[i + 5] + values[18].list[i + 5] + values[19].list[i + 5] + values[20].list[i + 5] + values[21].list[i + 5] + values[22].list[i + 5] + values[23].list[i + 5];
                        graphStructs[i].sk4Data.text = temp + "";
                        break;
                }
            }
            else
            {
                if (unit3) {
                    switch (dateIndex)
                    {
                        // Day : 0
                        case 0:
                            int temp = values[0].list[i];
                            graphStructs[i].sk3Data.text = temp + "";
                            break;

                        // Week : 1 ~ 7
                        case 1:
                            temp = values[1].list[i] + values[2].list[i] + values[3].list[i] + values[4].list[i] + values[5].list[i] + values[6].list[i] + values[7].list[i];
                            graphStructs[i].sk3Data.text = temp + "";
                            break;

                        // Month : 8 ~ 11
                        case 2:
                            temp = values[8].list[i] + values[9].list[i] + values[10].list[i] + values[11].list[i];
                            graphStructs[i].sk3Data.text = temp + "";
                            break;

                        // Year : 12 ~ 23
                        case 3:
                            temp = values[12].list[i] + values[13].list[i] + values[14].list[i] + values[15].list[i] + values[16].list[i] + values[17].list[i] + values[18].list[i] + values[19].list[i] + values[20].list[i] + values[21].list[i] + values[22].list[i] + values[23].list[i];
                            graphStructs[i].sk3Data.text = temp + "";
                            break;
                    }
                }
                else { graphStructs[i].sk3Data.text = "-"; }

                if (unit4) {
                    switch (dateIndex)
                    {
                        // Day : 0
                        case 0:
                            int temp = values[0].list[i + 5];
                            graphStructs[i].sk4Data.text = temp + "";
                            break;

                        // Week : 1 ~ 7
                        case 1:
                            temp = values[1].list[i + 5] + values[2].list[i + 5] + values[3].list[i + 5] + values[4].list[i + 5] + values[5].list[i + 5] + values[6].list[i + 5] + values[7].list[i + 5];
                            graphStructs[i].sk4Data.text = temp + "";
                            break;

                        // Month : 8 ~ 11
                        case 2:
                            temp = values[8].list[i + 5] + values[9].list[i + 5] + values[10].list[i + 5] + values[11].list[i + 5];
                            graphStructs[i].sk4Data.text = temp + "";
                            break;

                        // Year : 12 ~ 23
                        case 3:
                            temp = values[12].list[i + 5] + values[13].list[i + 5] + values[14].list[i + 5] + values[15].list[i + 5] + values[16].list[i + 5] + values[17].list[i + 5] + values[18].list[i + 5] + values[19].list[i + 5] + values[20].list[i + 5] + values[21].list[i + 5] + values[22].list[i + 5] + values[23].list[i + 5];
                            graphStructs[i].sk4Data.text = temp + "";
                            break;
                    }
                }
                else { graphStructs[i].sk4Data.text = "-"; }
            }
        }
    }
}