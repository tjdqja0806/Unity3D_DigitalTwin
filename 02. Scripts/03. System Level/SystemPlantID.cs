using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SystemPlantID : MonoBehaviour
{
    private DataAgent dataAgent;

    public TextMeshProUGUI title; 
    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        if (!dataAgent.isAuto)
            dataAgent.GetPlantID();
    }

    void Update()
    {
        if (dataAgent.GetPlantID() == "2811-")
            title.text = "SKN#3 Secondary";
        else
            title.text = "SKN#4 Secondary";

    }
}
