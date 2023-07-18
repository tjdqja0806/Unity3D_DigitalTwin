using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AlarmSwitchCase : MonoBehaviour
{
    [HideInInspector]
    public string componentName;

    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI componentNameText;
    public TextMeshProUGUI alarmTypeText;
    public TextMeshProUGUI alarmContent;
    [Space]
    public GameObject alarmCamera;
    public Transform[] cameraPosition;

    public AlarmComponentCheck alarmComponentCheck;

    private string sceneName;
    private void Awake()
    {

    }
    void Update()
    {
        switch (componentName)
        {
            case "AF_AFWPMD 2A":
                sceneName = "";
                currentTimeText.text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                componentNameText.text = componentName;
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
            case "CD_COND A":
                break;
            case "CD_COND B":
                break;
            case "CD_COND C":
                break;
            case "CD_COND Common":
                break;
            case "CD_DA":
                break;
            case "CD_DAST 02":
                break;
            case "CD_LP HTR 1A":
                break;
            case "CD_LP HTR 1B":
                break;
            case "CD_LP HTR 1C":
                break;
            case "CD_LP HTR 2A":
                break;
            case "CD_LP HTR 2B":
                break;
            case "CD_LP HTR 2C":
                break;
            case "CD_LP HTR 3A":
                break;
            case "CD_LP HTR 3B":
                break;
            case "CD_LP HTR 3C":
                break;
            case "CD_COP 01":
                break;
            case "CD_COP 02":
                break;
            case "CD_COP 03":
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
            case "FW_FWBP A":
                break;
            case "FW_FWBP B":
                break;
            case "FW_FWBP C":
                break;
            case "FW_TDFWP A":
                break;
            case "FW_TDFWP B":
                break;
            case "FW_TDFWP C":
                break;
            case "FW_DFWCV 13":
                break;
            case "FW_DFWCV 23":
                break;
            case "FW_EFWCV 12":
                break;
            case "FW_EFWCV 22":
                break;
            case "FW_HP HTR 5A":
                break;
            case "FW_HP HTR 5B":
                break;
            case "FW_HP HTR 6A":
                break;
            case "FW_HP HTR 6B":
                break;
            case "FW_HP HTR 7A":
                break;
            case "FW_HP HTR 7B":
                break;
            case "GA_GEN":
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
            case "MS_MSSV 01 10":
                break;
            case "MS_MSSV 11 20":
                break;
            case "MS_SG 01":
                break;
            case "MS_SG 02":
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
            case "TA_HP TBN":
                break;
            case "TA_LP TBN A":
                break;
            case "TA_LP TBN B":
                break;
            case "TA_LP TBN C":
                break;
            case "TA_LP TBN Common":
                break;
            case "TA_SPE":
                break;
            case "TA_SPEB 01":
                break;
            case "TA_SPEB 02":
                break;
            case "TA_CIV 11":
                break;
            case "TA_CIV 12":
                break;
            case "TA_CIV 13":
                break;
            case "TA_CIV 14":
                break;
            case "TA_CIV 15":
                break;
            case "TA_CIV 16":
                break;
            case "TA_CV 05":
                break;
            case "TA_CV 06":
                break;
            case "TA_CV 07":
                break;
            case "TA_CV 08":
                break;
            case "TA_MSR A":
                break;
            case "TA_MSR B":
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
                break;
        }
    }

    public void _ClickSystemButton()
    {
        LodingBarScript.LoadScene("03. System");
    }
    public void _ClickComponentButton()
    {
        if (!sceneName.Equals(""))
            LodingBarScript.LoadScene(sceneName);
    }
}
