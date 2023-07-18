using System;
using System.Collections.Generic;
using UnityEngine;
using VisualizationCore;

public class DataAgent : MonoBehaviour
{
    [HideInInspector]
    public bool isAuto;

    private float timer = 0.0f;

    void Awake()
    {
        isAuto = false;
        if (!isAuto) { DataService.Init(); }
        if (!PlayerPrefs.HasKey("PlantID"))
        {
            PlayerPrefs.SetString("PlantID", "SKR3");
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (!isAuto)
            {
                DataService.UpdateValues();
                //Debug.Log("2335-TBNSPD : " + DataService.GetSignalValueByTag("2235-TBNSPD").Value);
                //Debug.Log("2235-MPJ0001 : " + DataService.GetSignalValueByTag("2235-MPJ0001").Value);
            }
        }
    }

    // --------------------------------------------------------------------------------------------------------------------------

    // 단일, 데이터만, Tag ID로
    public double getValueByTagID(string tagID)
    {
        var value = DataService.GetSignalValueByTag(tagID).Value;
        if (value > -1 && value < 1 && value != 0)
        {
            return Double.Parse(string.Format("{0:N3}", value));
        }
        else
        {
            return Double.Parse(string.Format("{0:N1}", value));
        }
        //return DataService.GetSignalValueByTag(tagID).Value;
    }

    // 단일, 데이터 및 단위, Tag ID로
    public string getValueAndUnitByTagID(string tagID)
    {
        return string.Format("{0:N3}", DataService.GetSignalValueByTag(tagID).Value) + DataService.GetSignalValueByTag(tagID).Tag.EuUnit;
    }

    // 단일, 데이터만, Symbol Name으로
    public double getValueBySymbolName(string symbolName)
    {
        var value = DataService.GetSignalValueBySymbol(symbolName).Value;
        //if (DataService.GetSignalValueBySymbol(symbolName) == null) { Debug.Log("SymbolName : " + symbolName); return 0; }
        //return DataService.GetSignalValueBySymbol(symbolName).Value;
        if (value > -1 && value < 1 && value != 0)
        {
            return Double.Parse(string.Format("{0:N3}", value));
        }
        else
        {
            return Double.Parse(string.Format("{0:N1}", value));
        }
    }

    // 단일, 데이터만 string으로, Symbol Name으로
    public string getValueStringBySymbolName(string symbolName)
    {
        string temp = "";
        double value = DataService.GetSignalValueBySymbol(symbolName).Value;
        try
        {
            if (nullCheck(symbolName))
            {
                temp = "-";
            }
            else
            {
                if (value > -1 && value < 1 && value != 0)
                {
                    temp = string.Format("{0:N3}", value);
                }
                else
                {
                    temp = string.Format("{0:N1}", value);
                }
            }
        }
        catch (Exception e)
        {
            temp = DataService.GetSignalValueBySymbol(symbolName).FormatValue;
        }
        return temp;
    }

    // 단일, 데이터 및 단위, Symbol Name으로
    public string getValueAndUnitBySymbolName(string symbolName)
    {
        string result = "";
        double value = DataService.GetSignalValueBySymbol(symbolName).Value;
        if (value > -1 && value < 1 && value != 0)
        {
            result = string.Format("{0:N3}", DataService.GetSignalValueBySymbol(symbolName).Value);
        }
        else
        {
            result = string.Format("{0:N1}", DataService.GetSignalValueBySymbol(symbolName).Value);
        }

        return result + DataService.GetSignalValueBySymbol(symbolName).Tag.EuUnit;
    }

    private bool nullCheck(string symbolName)
    {
        if (
            symbolName.Contains("TO-TM-LDR")
            || symbolName.Contains("TM-RT_RBS")
            || symbolName.Contains("TM-CVR_OUT")
            || symbolName.Contains("TA-II0070")
            || symbolName.Contains("TM-DTGGH")
            || symbolName.Contains("TM-DTGGC")
            || symbolName.Contains("TM-TT_LOCO")
            || symbolName.Contains("TM-TT_LOCOA")
            || symbolName.Contains("PR-RI0217")
            || symbolName.Contains("PR-RI0218")
            || symbolName.Contains("PR-RI0219")
            || symbolName.Contains("PR-RI0220")
            || symbolName.Contains("MS-1-TAVG-1-TXS")
            || symbolName.Contains("MS-HIK1010-OUT")
            || symbolName.Contains("FW-LT1113A")
            || symbolName.Contains("FW-LT1123A")
            || symbolName.Contains("MS-PC1010-26-DMD")
            || symbolName.Contains("MS-PC1010-27-SPO")
            || symbolName.Contains("AS-FIT0003")
            || symbolName.Contains("AS-ZT0001-POS")
            || symbolName.Contains("CD-LY0318N06-OUT")
            || symbolName.Contains("TO-CT-FQI-0503")
            || symbolName.Contains("CX-CDF464TA")
            || symbolName.Contains("CD-PD0200")
            || symbolName.Contains("CD-PDC200-DMD")
            || symbolName.Contains("CD-PDC200-SPO")
            || symbolName.Contains("FW-LT1114A")
            || symbolName.Contains("FW-LT1124A")
            || symbolName.Contains("FW-II0055")
            || symbolName.Contains("FW-HIK1113-OUT")
            || symbolName.Contains("FW-HIK1123-OUT")
            || symbolName.Contains("FW-HIK1122-OUT")
            || symbolName.Contains("FW-FR1113X-2-SBG")
            || symbolName.Contains("FW-FR1113Y-2-SBG")
            || symbolName.Contains("FW-FR1123X-2-SBG")
            || symbolName.Contains("FW-FR1123Y-2-SBG")
            || symbolName.Contains("FW-ZT1122XA-POS")
            || symbolName.Contains("FW-ZT1122YA-POS")
            || symbolName.Contains("FW-ZT0107-POS")
            || symbolName.Contains("FW-1-FT1122-CSV-2-SBG")
            || symbolName.Contains("FW-1-LT1111-CSV-OUT")
            || symbolName.Contains("FW-2-LT1121X-MODE")
            || symbolName.Contains("FW-2-LT1121-CSV-OUT")
            || symbolName.Contains("MS-1-FT1011-4-SBG")
            || symbolName.Contains("MS-2-WTS-SG2-5-SBG")
            || symbolName.Contains("FW-1-PT0085-CSV-OUT")
            || symbolName.Contains("FW-FC023-MAO")
            || symbolName.Contains("FW-FC023-SPO")
            || symbolName.Contains("FW-FC024-MAO")
            || symbolName.Contains("FW-FC024-SPO")
            || symbolName.Contains("FW-FC025-MAO")
            || symbolName.Contains("FW-FC025-SPO")
            || symbolName.Contains("FW-FC057-MAO")
            || symbolName.Contains("FW-FC057-SPO")
            || symbolName.Contains("TO1-FW-PDIS-011")
            || symbolName.Contains("TO1-FW-PDIS-012")
            || symbolName.Contains("TO1-FW-PDIS-013")
            || symbolName.Contains("AF-FT0013N02-ACO")
            || symbolName.Contains("AF-FT0014N02-ACO")
            || symbolName.Contains("AF-FT0015N02-ACO")
            || symbolName.Contains("AF-FT0016N02-ACO")
            || symbolName.Contains("AX-FY0020N02-ACO")
            || symbolName.Contains("AX-FY0020N03-OUT")
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Day, Week, Month, Year 순
    public List<int> getAlarmHistoryAll(int dateType, int part)
    {
        List<int> temp = new List<int>();
        string unitString;
        DateTime begin = DateTime.Now;
        DateTime end = DateTime.Now;
        string index = dateType + "-" + part;
        switch (index)
        {
            case "0-0":
                begin = DateTime.Now;
                end = DateTime.Now;
                break;

            case "1-0":
                begin = DateTime.Now.AddDays(-6);
                end = DateTime.Now.AddDays(-6);
                break;
            case "1-1":
                begin = DateTime.Now.AddDays(-5);
                end = DateTime.Now.AddDays(-5);
                break;
            case "1-2":
                begin = DateTime.Now.AddDays(-4);
                end = DateTime.Now.AddDays(-4);
                break;
            case "1-3":
                begin = DateTime.Now.AddDays(-3);
                end = DateTime.Now.AddDays(-3);
                break;
            case "1-4":
                begin = DateTime.Now.AddDays(-2);
                end = DateTime.Now.AddDays(-2);
                break;
            case "1-5":
                begin = DateTime.Now.AddDays(-1);
                end = DateTime.Now.AddDays(-1);
                break;
            case "1-6":
                begin = DateTime.Now;
                end = DateTime.Now;
                break;

            case "2-0":
                begin = DateTime.Now.AddDays(-28);
                end = DateTime.Now.AddDays(-21);
                break;
            case "2-1":
                begin = DateTime.Now.AddDays(-21);
                end = DateTime.Now.AddDays(-14);
                break;
            case "2-2":
                begin = DateTime.Now.AddDays(-14);
                end = DateTime.Now.AddDays(-7);
                break;
            case "2-3":
                begin = DateTime.Now.AddDays(-7);
                end = DateTime.Now;
                break;

            case "3-0":
                begin = DateTime.Now.AddMonths(-12);
                end = DateTime.Now.AddMonths(-11);
                break;
            case "3-1":
                begin = DateTime.Now.AddMonths(-11);
                end = DateTime.Now.AddMonths(-10);
                break;
            case "3-2":
                begin = DateTime.Now.AddMonths(-10);
                end = DateTime.Now.AddMonths(-9);
                break;
            case "3-3":
                begin = DateTime.Now.AddMonths(-9);
                end = DateTime.Now.AddMonths(-8);
                break;
            case "3-4":
                begin = DateTime.Now.AddMonths(-8);
                end = DateTime.Now.AddMonths(-7);
                break;
            case "3-5":
                begin = DateTime.Now.AddMonths(-7);
                end = DateTime.Now.AddMonths(-6);
                break;
            case "3-6":
                begin = DateTime.Now.AddMonths(-6);
                end = DateTime.Now.AddMonths(-5);
                break;
            case "3-7":
                begin = DateTime.Now.AddMonths(-5);
                end = DateTime.Now.AddMonths(-4);
                break;
            case "3-8":
                begin = DateTime.Now.AddMonths(-4);
                end = DateTime.Now.AddMonths(-3);
                break;
            case "3-9":
                begin = DateTime.Now.AddMonths(-3);
                end = DateTime.Now.AddMonths(-2);
                break;
            case "3-10":
                begin = DateTime.Now.AddMonths(-2);
                end = DateTime.Now.AddMonths(-1);
                break;
            case "3-11":
                begin = DateTime.Now.AddMonths(-1);
                end = DateTime.Now;
                break;
        }

        int sumPHI3 = 0;
        int sumAPD3 = 0;
        int sumRPAS3 = 0;
        int sumCore3 = 0;
        int sumTotal3 = 0;

        int sumPHI4 = 0;
        int sumAPD4 = 0;
        int sumRPAS4 = 0;
        int sumCore4 = 0;
        int sumTotal4 = 0;

        List<AlarmDailySummary> logs = DataService.SearchAlarmSummary("SKR3", begin, end);
        foreach (AlarmDailySummary day in logs)
        {
            // 3호기 PHI, APD, R-PAS, Core, Total 순
            sumPHI3 = sumPHI3 + day.PHI.Alarm + day.PHI.Warning;
            sumAPD3 = sumAPD3 + day.APM.Alarm + day.APM.Warning;
            sumRPAS3 = sumRPAS3 + day.R_PAS.Alarm + day.R_PAS.Warning;
            sumCore3 = sumCore3 + day.Nuclear.Alarm + day.Nuclear.Warning;
            sumTotal3 = sumTotal3 + day.AlarmSum + day.WarningSum;
        }

        logs = DataService.SearchAlarmSummary("SKR4", begin, end);
        foreach (AlarmDailySummary day in logs)
        {
            // 4호기 PHI, APD, R-PAS, Core, Total 순
            SetPlantID(4, false);
            sumPHI4 = sumPHI4 + day.PHI.Alarm + day.PHI.Warning;
            sumAPD4 = sumAPD4 + day.APM.Alarm + day.APM.Warning;
            sumRPAS4 = sumRPAS4 + day.R_PAS.Alarm + day.R_PAS.Warning;
            sumCore4 = sumCore4 + day.Nuclear.Alarm + day.Nuclear.Warning;
            sumTotal4 = sumTotal4 + day.AlarmSum + day.WarningSum;
        }
        temp.Add(sumPHI3);
        temp.Add(sumAPD3);
        temp.Add(sumRPAS3);
        temp.Add(sumCore3);
        temp.Add(sumTotal3);
        temp.Add(sumPHI4);
        temp.Add(sumAPD4);
        temp.Add(sumRPAS4);
        temp.Add(sumCore4);
        temp.Add(sumTotal4);

        return temp;
    }

    // Day, Week, Month, Year 순
    public List<int> getAlarmHistoryUnit(int unit, int dateType, int part)
    {
        List<int> temp = new List<int>();
        string unitString;
        DateTime begin = DateTime.Now;
        DateTime end = DateTime.Now;
        string index = dateType + "-" + part;
        switch (index)
        {
            case "0-0":
                begin = DateTime.Now;
                end = DateTime.Now;
                break;

            case "1-0":
                begin = DateTime.Now.AddDays(-6);
                end = DateTime.Now.AddDays(-6);
                break;
            case "1-1":
                begin = DateTime.Now.AddDays(-5);
                end = DateTime.Now.AddDays(-5);
                break;
            case "1-2":
                begin = DateTime.Now.AddDays(-4);
                end = DateTime.Now.AddDays(-4);
                break;
            case "1-3":
                begin = DateTime.Now.AddDays(-3);
                end = DateTime.Now.AddDays(-3);
                break;
            case "1-4":
                begin = DateTime.Now.AddDays(-2);
                end = DateTime.Now.AddDays(-2);
                break;
            case "1-5":
                begin = DateTime.Now.AddDays(-1);
                end = DateTime.Now.AddDays(-1);
                break;
            case "1-6":
                begin = DateTime.Now;
                end = DateTime.Now;
                break;

            case "2-0":
                begin = DateTime.Now.AddDays(-28);
                end = DateTime.Now.AddDays(-21);
                break;
            case "2-1":
                begin = DateTime.Now.AddDays(-21);
                end = DateTime.Now.AddDays(-14);
                break;
            case "2-2":
                begin = DateTime.Now.AddDays(-14);
                end = DateTime.Now.AddDays(-7);
                break;
            case "2-3":
                begin = DateTime.Now.AddDays(-7);
                end = DateTime.Now;
                break;

            case "3-0":
                begin = DateTime.Now.AddMonths(-12);
                end = DateTime.Now.AddMonths(-11);
                break;
            case "3-1":
                begin = DateTime.Now.AddMonths(-11);
                end = DateTime.Now.AddMonths(-10);
                break;
            case "3-2":
                begin = DateTime.Now.AddMonths(-10);
                end = DateTime.Now.AddMonths(-9);
                break;
            case "3-3":
                begin = DateTime.Now.AddMonths(-9);
                end = DateTime.Now.AddMonths(-8);
                break;
            case "3-4":
                begin = DateTime.Now.AddMonths(-8);
                end = DateTime.Now.AddMonths(-7);
                break;
            case "3-5":
                begin = DateTime.Now.AddMonths(-7);
                end = DateTime.Now.AddMonths(-6);
                break;
            case "3-6":
                begin = DateTime.Now.AddMonths(-6);
                end = DateTime.Now.AddMonths(-5);
                break;
            case "3-7":
                begin = DateTime.Now.AddMonths(-5);
                end = DateTime.Now.AddMonths(-4);
                break;
            case "3-8":
                begin = DateTime.Now.AddMonths(-4);
                end = DateTime.Now.AddMonths(-3);
                break;
            case "3-9":
                begin = DateTime.Now.AddMonths(-3);
                end = DateTime.Now.AddMonths(-2);
                break;
            case "3-10":
                begin = DateTime.Now.AddMonths(-2);
                end = DateTime.Now.AddMonths(-1);
                break;
            case "3-11":
                begin = DateTime.Now.AddMonths(-1);
                end = DateTime.Now;
                break;
        }

        int sumPHI = 0;
        int sumAPD = 0;
        int sumRPAS = 0;
        int sumCore = 0;
        int sumTotal = 0;

        SetPlantID(unit, false);
        List<AlarmDailySummary> logs = DataService.SearchAlarmSummary(PlayerPrefs.GetString("PlantID"), begin, end);
        foreach (AlarmDailySummary day in logs)
        {
            // PHI, APD, R-PAS, Core, Total 순
            sumPHI = sumPHI + day.PHI.Alarm + day.PHI.Warning;
            sumAPD = sumAPD + day.APM.Alarm + day.APM.Warning;
            sumRPAS = sumRPAS + day.R_PAS.Alarm + day.R_PAS.Warning;
            sumCore = sumCore + day.Nuclear.Alarm + day.Nuclear.Warning;
            sumTotal = sumTotal + day.AlarmSum + day.WarningSum;
        }

        switch (PlayerPrefs.GetString("PlantID"))
        {
            case "SKR3":
                temp.Add(sumPHI);
                temp.Add(sumAPD);
                temp.Add(sumRPAS);
                temp.Add(sumCore);
                temp.Add(sumTotal);
                temp.Add(0);
                temp.Add(0);
                temp.Add(0);
                temp.Add(0);
                temp.Add(0);
                break;

            case "SKR4":
                temp.Add(0);
                temp.Add(0);
                temp.Add(0);
                temp.Add(0);
                temp.Add(0);
                temp.Add(sumPHI);
                temp.Add(sumAPD);
                temp.Add(sumRPAS);
                temp.Add(sumCore);
                temp.Add(sumTotal);
                break;
        }
        return temp;
    }

    public void RPASSimulationInput(string symbolName, string value, bool isAuto)
    {
        DataService.InputSimParam(symbolName, double.Parse(value), isAuto);
    }

    public void RPASSimulationSend()
    {
        DataService.SubmitSimParam();
    }

    public void ClickWareHouse()
    {
        DataService.RunWindow((int)CommonVars.ProgramID.Warehouse);
    }
    public double[] ServerStatus(string serverName)
    {
        double[] data = new double[6];
        if (isAuto)
        {
            data[0] = 2.9;
            data[1] = 10;
            data[2] = 33554432;
            data[3] = 17301504;
            data[4] = 104857600;
            data[5] = 83886080;
        }
        else
        {
            int server = 0;

            switch (serverName)
            {
                case "Visualization":
                    server = (int)CommonVars.ServerID.Visualization;
                    break;
                case "PlatformP":
                    server = (int)CommonVars.ServerID.PlatformP;
                    break;
                case "PlatformB":
                    server = (int)CommonVars.ServerID.PlatformB;
                    break;
                case "MachineLearning":
                    server = (int)CommonVars.ServerID.MachineLearning;
                    break;
                case "RelayServer":
                    server = (int)CommonVars.ServerID.RelayServer;
                    break;
                case "NuclearServer":
                    server = (int)CommonVars.ServerID.NuclearServer;
                    break;
            }

            ServerResource serverResource = DataService.ServerStatus(server);
            data[0] = serverResource.CpuBaseSpeed; // CPU 기본 속도 GHz
            data[1] = serverResource.CpuUsage; // CPU 이용률 %
            data[2] = serverResource.MemoryTotalSize; // 총 RAM 용량 KB
            data[3] = serverResource.MemoryAvailable; // 사용 가능한 RAM 용량 KB
            data[4] = serverResource.DiskCapacity; // 총 HDD 용량 KB
            data[5] = serverResource.DiskAvailable; // 사용가능한 HDD 용량 KB
        }

        return data;
    }
    public void ClickAlarmHistoryValue()
    {
        DataService.RunWindow((int)CommonVars.ProgramID.AlarmLogAnalysis);
    }

    // 노심 화면용
    public Color CoreSpectrum(string symbolName)
    {
        CoreColorCode coreColorCode = DataService.CoreSpectrum(symbolName);
        Color temp = new Color(coreColorCode.R / 255f, coreColorCode.G / 255f, coreColorCode.B / 255f); // 0에서 255 사이값 (Red, Green, Blue)설정
        return temp;
    }

    public Color CoreColor(int x, int y, int level)
    {
        return new Color(DataService.GetCore(level, x, y).ColorCode.R / 255f, DataService.GetCore(level, x, y).ColorCode.G / 255f, DataService.GetCore(level, x, y).ColorCode.B / 255f);
    }

    public void SetPlantID(int num, bool refresh)
    {
        switch (num)
        {
            case 3:
                PlayerPrefs.SetString("PlantID", "SKR3");
                break;
            case 4:
                PlayerPrefs.SetString("PlantID", "SKR4");
                break;
        }
        DataService.SetPlantId(PlayerPrefs.GetString("PlantID"));

        if (refresh)
        {
            SceneChange sceneChange = new SceneChange();
            sceneChange.RefreshScene();
        }
    }

    public string GetPlantID()
    {
        string temp = "";
        switch (PlayerPrefs.GetString("PlantID"))
        {
            case "SKR3":
                temp = "2811-";
                break;
            case "SKR4":
                temp = "2812-";
                break;
        }
        return temp;
    }
}