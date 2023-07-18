using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitLevelControl : MonoBehaviour
{
    [Serializable]
    public struct ItemGruop
    {
        public CanvasGroup canvasGroup;
        public GameObject camera;
        public GameObject group;
    }
    public ItemGruop[] modes;
    [HideInInspector]
    public bool isUIActive = true;
    [HideInInspector]
    //public bool isXrayActive = false;
    //[HideInInspector]
    public bool isTourActive = false;

    public Button infoButton;
    public Image infoImage;
    // 0 : 운전
    // 1 : 정지
    // 2 : 알람
    [HideInInspector]
    public int statusPri = 0;
    [HideInInspector]
    public int statusSec = 0;

    private AlarmControl script;

    void Awake()
    {
        script = GameObject.Find("Menu 2").GetComponent<AlarmControl>();
        /*if (PlayerPrefs.GetInt("UnitMode") == 0) { isTourActive = false; }
        else { isTourActive = true; }*/
    }

    void Update()
    {
        modes[0].camera.SetActive(!isTourActive);
        modes[0].group.SetActive(!isTourActive);
        modes[1].camera.SetActive(isTourActive);
        modes[1].group.SetActive(isTourActive);

        if (!isTourActive)
        {
            modes[0].canvasGroup.alpha = 1;
            modes[1].canvasGroup.alpha = 0;
            infoImage.gameObject.SetActive(true);
            infoButton.gameObject.SetActive(false);
        }
        else
        {
            modes[0].canvasGroup.alpha = 0;
            modes[1].canvasGroup.alpha = 1;
            infoImage.gameObject.SetActive(false);
            infoButton.gameObject.SetActive(true);
        }

        if (script.isAlarm) { statusSec = 2; }
        else { statusSec = 0; }
    }

    // 클릭 시 UI 슬라이더 표현
    public void ChangeUIActive() { isUIActive = !isUIActive; }

    // 클릭 시 카메라 모드 변경
    public void ChangeCameraMode()
    {
        isTourActive = !isTourActive;
    }

    // 클릭 시 X-Ray 상태 <-> 정상 상태
    //public void ChangeXrayActive() { isXrayActive = !isXrayActive; }
}