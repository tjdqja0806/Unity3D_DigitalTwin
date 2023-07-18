using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWorldUIFlip : MonoBehaviour
{
    public Transform[] camera;
    public bool x = false;
    public bool z = false;

    private float defaultY = 0;
    private UnitLevelControl unitLevelControl;
    void Awake()
    {
        defaultY = transform.localEulerAngles.y;
        unitLevelControl = GameObject.Find("EventSystem").GetComponent<UnitLevelControl>();
    }

    void Update()
    {
        if (x)
        {
            if (!unitLevelControl.isTourActive)
            {
                if (camera[0].transform.position.x > transform.position.x)
                {
                    transform.localEulerAngles = new Vector3(0, defaultY, 0);
                }
                else { transform.localEulerAngles = new Vector3(0, defaultY + 180, 0); }
            }
            else
            {
                if (camera[1].transform.position.x > transform.position.x)
                {
                    transform.localEulerAngles = new Vector3(0, defaultY, 0);
                }
                else { transform.localEulerAngles = new Vector3(0, defaultY + 180, 0); }
            }
        }
        if (z)
        {
            if (!unitLevelControl.isTourActive)
            {
                if (camera[0].transform.position.z > transform.position.z)
                {
                    transform.localEulerAngles = new Vector3(0, defaultY + 180, 0);
                }
                else { transform.localEulerAngles = new Vector3(0, defaultY, 0); }
            }
            else
            {
                if (camera[1].transform.position.z > transform.position.z)
                {
                    transform.localEulerAngles = new Vector3(0, defaultY + 180, 0);
                }
                else { transform.localEulerAngles = new Vector3(0, defaultY, 0); }
            }
        }
    }

}
