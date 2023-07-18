using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScript : MonoBehaviour
{
    public GameObject settingObj;
    [HideInInspector]
    public bool isSetting = false;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        settingObj.SetActive(isSetting);
    }
    public void SettingClick()
    {
        isSetting = !isSetting;
    }

    public void SettingOff()
    {
        isSetting = false;
    }
}
