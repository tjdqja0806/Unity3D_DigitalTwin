using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUIFlip : MonoBehaviour
{
    public Transform camera;
    public bool x = false;
    public bool z = false;

    private float defaultY = 0;

    void Awake()
    {
        defaultY = transform.localEulerAngles.y;
    }

    void Update()
    {
        if (x)
        {
            if (camera.transform.position.x > transform.position.x)
            {
                transform.localEulerAngles = new Vector3(0, defaultY, 0);
            }
            else { transform.localEulerAngles = new Vector3(0, defaultY + 180, 0); }
        }
        if (z)
        {
            if (camera.transform.position.z > transform.position.z)
            {
                transform.localEulerAngles = new Vector3(0, defaultY + 180, 0);
            }
            else { transform.localEulerAngles = new Vector3(0, defaultY, 0); }
        }
    }
}
