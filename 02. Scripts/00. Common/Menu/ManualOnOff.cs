using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualOnOff : MonoBehaviour
{
    public GameObject manual;
    private bool isManual = false;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        manual.SetActive(isManual);
    }
    public void SettingClick()
    {
        isManual = !isManual;
    }
}
