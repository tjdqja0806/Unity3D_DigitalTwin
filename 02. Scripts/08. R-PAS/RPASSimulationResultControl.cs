using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RPASSimulationResultControl : MonoBehaviour
{
    [Header("Camera")]
    //Camera
    public GameObject mainCamera;
    public GameObject resultCamera;
    [Header("UI")]
    //UI
    public GameObject simulationUI;
    public GameObject resultUI;
    public GameObject resultAll2dUI;
    [Header("Script")]
    public SimulationMainControl simulationMainControl;
    public RPASSimulationDataControl rPASSimulationDataControl;
    public RPASSimulationMenuControl rPASSimulationMenuControl;
    [Space]
    public GameObject menuHoverArea;

    [Serializable]
    public struct ObjectStruct
    {
        public GameObject position;
        public GameObject resultUI2D;
    }
    public ObjectStruct[] objects;
    [HideInInspector]
    public bool isResult = false;
    private bool isMove = false;
    private int status;
    private float offset;


    void Start()
    {
        resultAll2dUI.SetActive(false);
    }
    void Update()
    {
        offset = Vector3.Distance(mainCamera.transform.position, objects[status].position.transform.position);
        if (isMove)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, objects[status].position.transform.position, 0.05f);
            mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, objects[status].position.transform.rotation, 0.05f);
            if (offset < 0.001f)
            {
                isMove = false;
            }
        }
    }

    public void _ClickPoint(int num)
    {
        status = num;
        resultCamera.SetActive(false);
        mainCamera.SetActive(true);
        resultUI.SetActive(false);
        isMove = true;
        resultAll2dUI.SetActive(true);
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == status)
                objects[i].resultUI2D.SetActive(true);
            else
                objects[i].resultUI2D.SetActive(false);
        }

        menuHoverArea.SetActive(true);
    }

    public void SendResult()
    {
        isResult = true;
        //Camera Change
        mainCamera.SetActive(false);
        resultCamera.SetActive(true);

        //UI Change
        simulationUI.SetActive(false);
        resultUI.SetActive(true);

        //Menu SetActive(false)
        menuHoverArea.SetActive(false);
    }
    public void ReturnResult()
    {
        mainCamera.SetActive(false);
        resultCamera.SetActive(true);

        //UI Change
        simulationUI.SetActive(false);
        resultUI.SetActive(true);
        resultAll2dUI.SetActive(false);

        menuHoverArea.SetActive(false);
    }
    public void ExitResult()
    {
        isResult = false;
        //Camera Change
        mainCamera.SetActive(true);
        resultCamera.SetActive(false);

        //UI Change
        simulationUI.SetActive(true);
        resultUI.SetActive(false);

        //2D UI OFF
        resultAll2dUI.SetActive(false);
        rPASSimulationMenuControl._ClickPoint("0-0");
        simulationMainControl.isResult = false;

        menuHoverArea.SetActive(true);
    }
}
