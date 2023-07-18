using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComponentPlantID : MonoBehaviour
{
    private DataAgent dataAgent;

    public TextMeshProUGUI alarmTitle;
    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        if (!dataAgent.isAuto)
            dataAgent.GetPlantID();
    }

    void Update()
    {
        if (dataAgent.GetPlantID() == "2811-")
            alarmTitle.text = "SKN#3";
        else
            alarmTitle.text = "SKN#4";

    }
}
