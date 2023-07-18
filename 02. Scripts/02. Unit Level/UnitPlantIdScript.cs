using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitPlantIdScript : MonoBehaviour
{
    private DataAgent dataAgent;

    public int num;
    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        if (SceneManager.GetActiveScene().name.Contains("3"))
            num = 3;
        else if (SceneManager.GetActiveScene().name.Contains("4"))
            num = 4;

        if(!dataAgent.isAuto)
            dataAgent.SetPlantID(num, false);
    }
}
