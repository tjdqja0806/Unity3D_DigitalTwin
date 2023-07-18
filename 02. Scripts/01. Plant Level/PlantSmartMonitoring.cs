using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantSmartMonitoring : MonoBehaviour
{
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

    private PlantLevelControl script;

    void Awake()
    {
        script = GameObject.Find("EventSystem").GetComponent<PlantLevelControl>();
    }

    void Update()
    {
        // 현재는 3호기 2차측 MMIS 알람만 발생한다고 가정함.
        if (script.status3rdSec == 2)
        {
            // MMIS
            items[2].image.sprite = items[2].warning;
            // Circle
            items[5].image.sprite = items[5].warning;
            roll.color = colorWarn;
            text.text = "WARNING";
        }
        else {
            items[2].image.sprite = items[2].normal;
            items[5].image.sprite = items[5].normal;
            roll.color = colorNormal;
            text.text = "NORMAL";
        }
    }
}