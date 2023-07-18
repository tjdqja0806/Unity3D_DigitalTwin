using System;
using TMPro;
using UnityEngine;

public class ScrollViewPerformanceControl : MonoBehaviour
{
    [Serializable]
    public struct AlarmGroup
    {
        public CanvasGroup scrolls;
        public TextMeshProUGUI nameText;
        [HideInInspector]
        public bool isAlarm;
    }
    public AlarmGroup[] alarmGroups;

    private int index = 0;
    private float timer = 0.0f;
    private bool changeColor = false;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0.5f;
            changeColor = !changeColor;
        }

        for (int i = 0; i < alarmGroups.Length; i++)
        {
            if (i == index) { 
                alarmGroups[i].scrolls.alpha = 1;
                alarmGroups[i].scrolls.blocksRaycasts = true;
            }
            else { 
                alarmGroups[i].scrolls.alpha = 0;
                alarmGroups[i].scrolls.blocksRaycasts = false;

            }

            alarmGroups[i].isAlarm = alarmGroups[i].scrolls.GetComponent<ScrollViewPerformance>().isAlarm;
            if (alarmGroups[i].isAlarm)
            {
                if (changeColor) { alarmGroups[i].nameText.color = Color.red; }
                else { alarmGroups[i].nameText.color = Color.white; }
            }
            else { alarmGroups[i].nameText.color = Color.white; }
        }
    }

    public void _ClickScrollView(int num) { index = num; }
}