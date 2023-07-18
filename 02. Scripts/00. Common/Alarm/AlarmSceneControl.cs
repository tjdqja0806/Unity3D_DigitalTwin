using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlarmSceneControl : MonoBehaviour
{
    public TextMeshProUGUI alarmCountText;
    [Space]
    public TextMeshProUGUI alarmResultText;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI alarmTypeText;
    public TextMeshProUGUI alarmDescriptionText;
    [Space]
    public GameObject camera;
    public GameObject btnComponent;

    [HideInInspector]
    public List<DataGroup> alarmList = new List<DataGroup>();
    private AlarmCheck alarmCheck;
    private string sceneName;
    private int index = 0;

    public struct DataGroup
    {
        public string dataType;
        public string component;
        public string symbolName;
        public string description;
        public string alarmResult;
        public string apdType;
    }

    void Start()
    {
        alarmCheck = GameObject.Find("EventSystem").GetComponent<AlarmCheck>();
        for (int i = 0; i < alarmCheck.alarmList.Count; i++)
        {
            DataGroup item = new DataGroup();
            item.dataType = alarmCheck.alarmList[i].dataType;
            item.component = alarmCheck.alarmList[i].component;
            item.symbolName = alarmCheck.alarmList[i].symbolName;
            item.description = alarmCheck.alarmList[i].description;
            item.alarmResult = alarmCheck.alarmList[i].alarmResult;
            item.apdType = alarmCheck.alarmList[i].apdType;
            alarmList.Add(item);
        }

        ChangeAlarmContents(0);
    }

    void Update()
    {

    }

    // 시스템 클릭 버튼 이벤트
    public void _ClickSystemButton()
    {
        PlayerPrefs.SetString("PostScene", SceneManager.GetActiveScene().name);
        LodingBarScript.LoadScene("03. System");
    }

    // 컴포넌트 클릭 버튼 이벤트
    public void _ClickComponentButton()
    {
        PlayerPrefs.SetString("PostScene", SceneManager.GetActiveScene().name);
        if (!sceneName.Equals(""))
            LodingBarScript.LoadScene(sceneName);
    }

    // 왼쪽 화살표 클릭 버튼 이벤트
    public void _ClickLeftArrowButton()
    {
        if (index > 0)
        {
            index--;
            ChangeAlarmContents(index);
        }
    }

    // 오른쪽 화살표 클릭 버튼 이벤트
    public void _ClickRightArrowButton()
    {
        if (index < alarmList.Count - 1)
        {
            index++;
            ChangeAlarmContents(index);
        }
    }

    // Tag로 3D 모델 검색해서 해당 XRayMat의 bool값 변경 -> bool값이 변경되면 XRayMat 내부에서 깜빡이는 기능 실행
    private void ChangeMat(string component) { }

    private void ChangeAlarmContents(int index)
    {
        // Alarm Count : n/4 -> alarmCountText
        // Event Alarm : Warning -> alarmResultText
        // Event Time : 2021.03.19 00:36:07 -> currentTimeText
        // Source : PHI -> alarmTypeText
        // Description : 설비명 : Description -> alarmDescriptionText

        alarmCountText.text = (index + 1) + "/" + alarmList.Count;
        alarmResultText.text = alarmList[index].alarmResult;
        currentTimeText.text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        alarmTypeText.text = alarmList[index].dataType;
        string[] compName = alarmList[index].component.Split(char.Parse("_"));
        if (alarmList[index].dataType == "APD")
        {
            alarmDescriptionText.text = compName[1] + " : " + alarmList[index].description + "(" + alarmList[index].apdType + ")";
        }
        else
        {
            alarmDescriptionText.text = compName[1] + " : " + alarmList[index].description;
        }
        ChangeMat(alarmList[index].component);
        // 카메라 위치 변경
        camera.transform.position = GameObject.Find(alarmList[index].component).transform.position;
        camera.transform.rotation = GameObject.Find(alarmList[index].component).transform.rotation;

        switch (alarmList[index].component)
        {
            case "TA_HP TBN":
                sceneName = " 05-1. COM_HPTBN";
                break;
            case "TA_LP TBN A":
                sceneName = "05-2. COM_LPTBN";
                break;
            case "TA_LP TBN B":
                sceneName = "05-2. COM_LPTBN";
                break;
            case "TA_LP TBN C":
                sceneName = "05-2. COM_LPTBN";
                break;
            case "TA_LP TBN Common":
                sceneName = "05-2. COM_LPTBN";
                break;
            case "GA_GEN":
                sceneName = "05-3. COM_GEN";
                break;
            case "TA_MSR A":
                sceneName = "05-4. COM_MSR";
                break;
            case "TA_MSR B":
                sceneName = "05-4. COM_MSR";
                break;
            case "CD_COND A":
                sceneName = "05-5. COM_COND";
                break;
            case "CD_COND B":
                sceneName = "05-5. COM_COND";
                break;
            case "CD_COND C":
                sceneName = "05-5. COM_COND";
                break;
            case "CD_COND Common":
                sceneName = "05-5. COM_COND";
                break;
            case "CD_LP HTR 1A":
                sceneName = "05-6-6. COM_LP FW HTR 1";
                break;
            case "CD_LP HTR 1B":
                sceneName = "05-6-6. COM_LP FW HTR 1";
                break;
            case "CD_LP HTR 1C":
                sceneName = "05-6-6. COM_LP FW HTR 1";
                break;
            case "CD_LP HTR 2A":
                sceneName = "05-6-5. COM_LP FW HTR 2";
                break;
            case "CD_LP HTR 2B":
                sceneName = "05-6-5. COM_LP FW HTR 2";
                break;
            case "CD_LP HTR 2C":
                sceneName = "05-6-5. COM_LP FW HTR 2";
                break;
            case "CD_LP HTR 3A":
                sceneName = "05-6-4. COM_LP FW HTR 3";
                break;
            case "CD_LP HTR 3B":
                sceneName = "05-6-4. COM_LP FW HTR 3";
                break;
            case "CD_LP HTR 3C":
                sceneName = "05-6-4. COM_LP FW HTR 3";
                break;
            case "FW_HP HTR 5A":
                sceneName = "05-6-3. COM_HP FW HTR 5";
                break;
            case "FW_HP HTR 5B":
                sceneName = "05-6-3. COM_HP FW HTR 5";
                break;
            case "FW_HP HTR 6A":
                sceneName = "05-6-2. COM_HP FW HTR 6";
                break;
            case "FW_HP HTR 6B":
                sceneName = "05-6-2. COM_HP FW HTR 6";
                break;
            case "FW_HP HTR 7A":
                sceneName = "05-6-1. COM_HP FW HTR 7";
                break;
            case "FW_HP HTR 7B":
                sceneName = "05-6-1. COM_HP FW HTR 7";
                break;
            case "CD_DA":
                sceneName = "05-7. COM_DA";
                break;
            case "CD_COP 01":
                sceneName = "05-8. COM_COP";
                break;
            case "CD_COP 02":
                sceneName = "05-8. COM_COP";
                break;
            case "CD_COP 03":
                sceneName = "05-8. COM_COP";
                break;
            case "FW_FWBP A":
                sceneName = "05-11. COM_FWBP";
                break;
            case "FW_FWBP B":
                sceneName = "05-11. COM_FWBP";
                break;
            case "FW_FWBP C":
                sceneName = "05-11. COM_FWBP";
                break;
            case "FW_TDFWP A":
                sceneName = "05-12. COM_FWP";
                break;
            case "FW_TDFWP B":
                sceneName = "05-12. COM_FWP";
                break;
            case "FW_TDFWP C":
                sceneName = "05-12. COM_FWP";
                break;
            case "TA_CV 05":
                sceneName = "05-14. COM_CV";
                break;
            case "TA_CV 06":
                sceneName = "05-14. COM_CV";
                break;
            case "TA_CV 07":
                sceneName = "05-14. COM_CV";
                break;
            case "TA_CV 08":
                sceneName = "05-14. COM_CV";
                break;
            case "TA_CIV 11":
                sceneName = "05-15. COM_CIV";
                break;
            case "TA_CIV 12":
                sceneName = "05-15. COM_CIV";
                break;
            case "TA_CIV 13":
                sceneName = "05-15. COM_CIV";
                break;
            case "TA_CIV 14":
                sceneName = "05-15. COM_CIV";
                break;
            case "TA_CIV 15":
                sceneName = "05-15. COM_CIV";
                break;
            case "MS_MSSV 01 10":
                sceneName = "05-17. COM_MSSV";
                break;
            case "MS_MSSV 11 20":
                sceneName = "05-17. COM_MSSV";
                break;
            case "FW_DFWCV 13":
                sceneName = "05-21. COM_FWCV";
                break;
            case "FW_DFWCV 23":
                sceneName = "05-21. COM_FWCV";
                break;
            case "FW_EFWCV 12":
                sceneName = "05-21. COM_FWCV";
                break;
            case "FW_EFWCV 22":
                sceneName = "05-21. COM_FWCV";
                break;
            case "MS_SG 01":
                sceneName = "05-23. COM_SG";
                break;
            case "MS_SG 02":
                sceneName = "05-23. COM_SG";
                break;
            case "CD_DAST 02":
                sceneName = "05-25. COM_DST";
                break;
            default:
                sceneName = "";
                break;
                /*
                case "AF_AFWPMD 2A":
                    break;
                case "AF_AFWPMD 2B":
                    break;
                case "AF_AFWPTD 1A":
                    break;
                case "AF_AFWPTD 1B":
                    break;
                case "CA_CVP 01":
                    break;
                case "CA_CVP 02":
                    break;
                case "CA_CVP 03":
                    break;
                case "CA_CVP 04":
                    break;
                case "CA_RECP 05":
                    break;
                case "CA_RECP 06":
                    break;
                case "CA_RECP 07":
                    break;
                case "CA_RECP 08":
                    break;
                case "CC_CCWMP 3A":
                    break;
                case "CC_CCWMP 3B":
                    break;
                case "CC_CCWP 1A":
                    break;
                case "CC_CCWP 1B":
                    break;
                case "CC_CCWP 2A":
                    break;
                case "CC_CCWP 2B":
                    break;
                case "CW_CWP 01":
                    break;
                case "CW_CWP 02":
                    break;
                case "CW_CWP 03":
                    break;
                case "CW_CWP 04":
                    break;
                case "CW_CWP 05":
                    break;
                case "CW_CWP 06":
                    break;
                case "CW_CWPLWBP 20":
                    break;
                case "CW_CWPLWBP 21":
                    break;
                case "CW_CWPLWBP 22":
                    break;
                case "CW_CWPLWBP 23":
                    break;
                case "CW_CWPLWBP 24":
                    break;
                case "CW_CWPLWBP 25":
                    break;
                case "DO_DFOTP 1A":
                    break;
                case "DO_DFOTP 1B":
                    break;
                case "DO_DFOTP 2A":
                    break;
                case "DO_DFOTP 2B":
                    break;
                case "FC_SFPCP 1A":
                    break;
                case "FC_SFPCP 1B":
                    break;
                case "FT_HPSV 40":
                    break;
                case "FT_HPSV 41":
                    break;
                case "FT_HPSV 42":
                    break;
                case "GC_SCP 01":
                    break;
                case "GC_SCP 02":
                    break;
                case "HD_MSDK 01":
                    break;
                case "HD_MSDK 04":
                    break;
                case "HD_SRDT1ST 02":
                    break;
                case "HD_SRDT1ST 05":
                    break;
                case "HD_SRDT2ND 03":
                    break;
                case "HD_SRDT2ND 06":
                    break;
                case "IA_AIRC 01":
                    break;
                case "IA_AIRC 02":
                    break;
                case "IA_AIRC 03":
                    break;
                case "IA_AIRC 04":
                    break;
                case "IA_CLCP":
                    break;
                case "SW_CWSWP 01":
                    break;
                case "SW_CWSWP 02":
                    break;
                case "SW_ESWSWP 3A":
                    break;
                case "SW_ESWSWP 3B":
                    break;
                case "SW_ESWSWP 4A":
                    break;
                case "SW_ESWSWP 4B":
                    break;
                case "SX_ESWP 1A":
                    break;
                case "SX_ESWP 1B":
                    break;
                case "SX_ESWP 2A":
                    break;
                case "SX_ESWP 2B":
                    break;
                case "TA_SPE":
                    break;
                case "TA_SPEB 01":
                    break;
                case "TA_SPEB 02":
                    break;
                case "TC_ESOP":
                    break;
                case "TC_MSOP":
                    break;
                case "TC_RSOP":
                    break;
                case "TC_SOVP":
                    break;
                case "TH_HFP 01":
                    break;
                case "TH_HFP 02":
                    break;
                case "TH_TAAFP":
                    break;
                case "TO_EBOP":
                    break;
                case "TO_LOVE 01":
                    break;
                case "TO_LOVE 02":
                    break;
                case "TO_MSP":
                    break;
                case "TO_TGOP":
                    break;
                case "TO_BLOP 06":
                    break;
                case "TO_BLOP 07":
                    break;
                case "TO_BLOP 08":
                    break;
                case "TO_BLOP 09":
                    break;
                case "TO_BLOP 10":
                    break;
                case "TO_BLOP 11":
                    break;
                case "TO_BLOP 12":
                    break;
                case "TO_BLOP 13":
                    break;
                case "TO_BLOP 14":
                    break;
                case "TO_BLOP 15":
                    break;
                case "TO_MOP":
                    break;
                case "WI_CCWP 01":
                    break;
                case "WI_CCWP 02":
                    break;
                case "WO_ECWMP 3A":
                    break;
                case "WO_ECWMP 3B":
                    break;
                case "WO_ECWP 1A":
                    break;
                case "WO_ECWP 1B":
                    break;
                case "WO_ECWP 2A":
                    break;
                case "WO_ECWP 2B":
                    break;
                case "WT_TGBCCWP 01":
                    break;
                case "WT_TGBCCWP 02":
                    break;
                case "WT_TGBCCWHE":
                    break;
                case "WT_TGBCCWSTK":
                    break;*/
        }
        // Component 화면 있는지 확인 -> 없으면 버튼 사라지게 해야 함
        if (sceneName.Equals(""))
            btnComponent.SetActive(false);
        else
            btnComponent.SetActive(true);
    }

    public void ExitAlarmScene()
    {
        alarmCheck.ExitAlarmScene();
    }
}