using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SmartMonitoring : MonoBehaviour
{
    public AlarmSceneControl script;
    private AlarmCheck alarmCheck;
    [Serializable]
    public struct ItemStruct
    {
        public Image image;
        public Sprite normal;
        public Sprite warning;
    }
    public ItemStruct[] items;
    [Space]
    public Image roll;
    public TextMeshProUGUI text;
    [Space]
    public Color colorNormal;
    public Color colorWarn;
    public Color colorWarnText;



    void Awake()
    {
        alarmCheck = GameObject.Find("EventSystem").GetComponent<AlarmCheck>();
    }

    void Update()
    {
        
        for(int i = 0; i < alarmCheck.alarmList.Count; i++)
        {
            if(alarmCheck.alarmList[i].dataType == "PHI")
            {
                items[1].image.sprite = items[1].warning;
                items[4].image.sprite = items[4].warning;
                roll.color = colorWarn;
                text.text = "WARNING";
                text.color = colorWarnText;
            }
            if (script.alarmList[i].dataType == "APD")
            {
                items[2].image.sprite = items[2].warning;
                items[4].image.sprite = items[4].warning;
                roll.color = colorWarn;
                text.text = "WARNING";
                text.color = colorWarnText;
            }
            if (script.alarmList[i].dataType == "RPAS")
            {
                items[0].image.sprite = items[0].warning;
                items[4].image.sprite = items[4].warning;
                roll.color = colorWarn;
                text.text = "WARNING";
                text.color = colorWarnText;
            }
            if (script.alarmList[i].dataType == "Core")
            {
                items[3].image.sprite = items[3].warning;
                items[4].image.sprite = items[4].warning;
                roll.color = colorWarn;
                text.text = "WARNING";
                text.color = colorWarnText;
            }
        }/*
        switch (script.alarmTypeText.text)
        {
            case "PHI":
                items[1].image.sprite = items[1].warning;
                items[4].image.sprite = items[4].warning;
                roll.color = colorWarn;
                text.text = "WARNING";
                text.color = colorWarnText;
                break;
            case "APD":
                items[2].image.sprite = items[2].warning;
                items[4].image.sprite = items[4].warning;
                roll.color = colorWarn;
                text.text = "WARNING";
                text.color = colorWarnText;
                break;
            case "RPAS":
                items[0].image.sprite = items[0].warning;
                items[4].image.sprite = items[4].warning;
                roll.color = colorWarn;
                text.text = "WARNING";
                text.color = colorWarnText;
                break;
            case "Core":
                items[3].image.sprite = items[3].warning;
                items[4].image.sprite = items[4].warning;
                roll.color = colorWarn;
                text.text = "WARNING";
                text.color = colorWarnText;
                break;
            default:
                for(int i = 0; i < items.Length; i++)
                    items[i].image.sprite = items[i].normal;
                roll.color = colorNormal;
                text.text = "NORMAL";
                text.color = Color.white;
                break;
        }*/
    }
}