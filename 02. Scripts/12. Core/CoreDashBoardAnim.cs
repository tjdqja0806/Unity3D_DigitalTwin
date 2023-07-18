using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreDashBoardAnim : MonoBehaviour
{

    public Animator dashboard;
    public GameObject core;
    public GameObject unitCamera;
    public GameObject dashBoardUI;

    private bool isActive = false;
    private UnitLevelControl script;
    private AlarmControl alarmControl;
    // Start is called before the first frame update
    void Awake()
    {
        script = GameObject.Find("EventSystem").GetComponent<UnitLevelControl>();
        alarmControl = GameObject.Find("Menu 2").GetComponent<AlarmControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(core.transform.position, unitCamera.transform.position) < 0.8f)
            isActive = true;
        else
            isActive = false;
        if(!script.isTourActive)
            dashBoardUI.gameObject.SetActive(isActive);
        else
            dashboard.gameObject.SetActive(!script.isTourActive);
        dashboard.SetBool("Down", script.isUIActive);
    }
}
