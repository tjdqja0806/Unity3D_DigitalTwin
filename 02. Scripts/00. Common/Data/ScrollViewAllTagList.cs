using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ScrollViewAllTagList : MonoBehaviour
{
    public TextAsset filePI;
    public TextAsset fileAPD;
    public TextAsset filePHI;
    public TextAsset fileRPASDiag;
    public TextAsset fileRPASSimSend;
    public TextAsset fileRPASSimResult;
    public TextAsset fileCore;
    [Space]
    public RectTransform content;
    public ScrollViewTagContent contentPrefab;
    [Space]
    public TextMeshProUGUI lastUpdateTime;
    public TextMeshProUGUI pageNumber;
    public TextMeshProUGUI totalCount;
    [Space]
    public TextMeshProUGUI groupPI;
    public TextMeshProUGUI groupAPD;
    public TextMeshProUGUI groupPHI;
    public TextMeshProUGUI groupRPASDiag;
    public TextMeshProUGUI groupRPASSimSend;
    public TextMeshProUGUI groupRPASSimResult;
    public TextMeshProUGUI groupCore;

    private List<GroupForm> listPI = new List<GroupForm>();
    private List<GroupForm> listAPD = new List<GroupForm>();
    private List<GroupForm> listPHI = new List<GroupForm>();
    private List<GroupForm> listRPASDiag = new List<GroupForm>();
    private List<GroupForm> listRPASSimSend = new List<GroupForm>();
    private List<GroupForm> listRPASSimResult = new List<GroupForm>();
    private List<GroupForm> listCore = new List<GroupForm>();

    private int groupIndex = 0;
    private int pageIndex = 0;
    private int groupCount = 0;

    [SerializeField] TMP_InputField searchText;
    [SerializeField] GameObject buttonGroup;
    private bool isSearch;

    private DataAgent dataAgent;
    public struct GroupForm
    {
        public string dataType;
        public string tagName;
        public string description;
        public string unit;
    }

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();

        List<Dictionary<string, object>> data = CSVReader.Read(filePI.name);
        for (int i = 0; i < data.Count; i++) { CreateList(listPI, data[i]["DataType"].ToString(), data[i]["TagName"].ToString(), data[i]["Description"].ToString(), data[i]["Unit"].ToString()); }

        data = CSVReader.Read(fileAPD.name);
        for (int i = 0; i < data.Count; i++) { CreateList(listAPD, data[i]["DataType"].ToString(), data[i]["TagName"].ToString(), data[i]["Description"].ToString(), data[i]["Unit"].ToString()); }

        data = CSVReader.Read(filePHI.name);
        for (int i = 0; i < data.Count; i++) { CreateList(listPHI, data[i]["DataType"].ToString(), data[i]["TagName"].ToString(), data[i]["Description"].ToString(), data[i]["Unit"].ToString()); }

        data = CSVReader.Read(fileRPASDiag.name);
        for (int i = 0; i < data.Count; i++) { CreateList(listRPASDiag, data[i]["DataType"].ToString(), data[i]["TagName"].ToString(), data[i]["Description"].ToString(), data[i]["Unit"].ToString()); }

        data = CSVReader.Read(fileRPASSimSend.name);
        for (int i = 0; i < data.Count; i++) { CreateList(listRPASSimSend, data[i]["DataType"].ToString(), data[i]["TagName"].ToString(), data[i]["Description"].ToString(), data[i]["Unit"].ToString()); }

        data = CSVReader.Read(fileRPASSimResult.name);
        for (int i = 0; i < data.Count; i++) { CreateList(listRPASSimResult, data[i]["DataType"].ToString(), data[i]["TagName"].ToString(), data[i]["Description"].ToString(), data[i]["Unit"].ToString()); }

        data = CSVReader.Read(fileCore.name);
        for (int i = 0; i < data.Count; i++) { CreateList(listCore, data[i]["DataType"].ToString(), data[i]["TagName"].ToString(), data[i]["Description"].ToString(), data[i]["Unit"].ToString()); }

        _ClickGroup(0);
    }

    /*private void Start()
    {
        outTextPI();
    }*/

    void Update()
    {
        buttonGroup.SetActive(!isSearch);
        switch (groupIndex)
        {
            case 0:
                groupPI.color = Color.black;
                break;
            case 1:
                groupAPD.color = Color.black;
                break;
            case 2:
                groupPHI.color = Color.black;
                break;
            case 3:
                groupRPASDiag.color = Color.black;
                break;
            case 4:
                groupRPASSimSend.color = Color.black;
                break;
            case 5:
                groupRPASSimResult.color = Color.black;
                break;
            case 6:
                groupCore.color = Color.black;
                break;
        }
    }

    // ------------------------------------------------------------------------------------

    string filePath = "Assets/TextLog/";
    StreamWriter streamWriter;

    public void outTextPI()
    {
        Debug.Log("1");
        if (File.Exists(filePath + "PI") == false)
        {
            Debug.Log("2");
            streamWriter = new StreamWriter(filePath + "PI.txt");

            for (int i = 0; i < listPI.Count; i++)
            {
                if (dataAgent.getValueByTagID(listPI[i].tagName) > 0 && dataAgent.getValueByTagID(listPI[i].tagName) < 1)
                {
                    streamWriter.WriteLine("Tag : " + listPI[i].tagName + "          Value : " + dataAgent.getValueByTagID(listPI[i].tagName));
                }
            }

            streamWriter.Flush();
            streamWriter.Close();
            Debug.Log("3");
        }
    }

    public void outTextPHI()
    {
        Debug.Log("1");
        if (File.Exists(filePath + "PHI") == false)
        {
            Debug.Log("2");
            streamWriter = new StreamWriter(filePath + "PHI.txt");

            for (int i = 0; i < listPHI.Count; i++)
            {

                if (listPHI[i].tagName.Contains("_IX") && dataAgent.getValueByTagID(listPHI[i].tagName) == 0)
                {
                    streamWriter.WriteLine(
                        listPHI[i].tagName
                        + " : "
                        + dataAgent.getValueByTagID(listPHI[i].tagName)
                        + "           "
                        + listPHI[i].tagName.Substring(0, listPHI[i].tagName.Length - 3) + "_WL"
                        + " : "
                        + dataAgent.getValueByTagID(listPHI[i].tagName.Substring(0, listPHI[i].tagName.Length - 3) + "_WL")
                        );
                }
                else if (listPHI[i].tagName.Contains("_WL") && dataAgent.getValueByTagID(listPHI[i].tagName) != 0
                  && listPHI[i].tagName.Contains("_WL") && dataAgent.getValueByTagID(listPHI[i].tagName) != 1
                  && listPHI[i].tagName.Contains("_WL") && dataAgent.getValueByTagID(listPHI[i].tagName) != 2
                  && listPHI[i].tagName.Contains("_WL") && dataAgent.getValueByTagID(listPHI[i].tagName) != 3)
                {
                    streamWriter.WriteLine(
                        listPHI[i].tagName.Substring(0, listPHI[i].tagName.Length - 3) + "_IX"
                        + " : "
                        + dataAgent.getValueByTagID(listPHI[i].tagName.Substring(0, listPHI[i].tagName.Length - 3) + "_IX")
                        + "           "
                        + listPHI[i].tagName
                        + " : "
                        + dataAgent.getValueByTagID(listPHI[i].tagName)
                        );
                }
            }



            streamWriter.Flush();
            streamWriter.Close();
            Debug.Log("3");
        }
    }

    public void outTextRPASDiag()
    {
        Debug.Log("1");
        if (File.Exists(filePath + "RPASDiag") == false)
        {
            Debug.Log("2");
            streamWriter = new StreamWriter(filePath + "RPASDiag.txt");

            for (int i = 0; i < listRPASDiag.Count; i++)
            {
                streamWriter.WriteLine("Tag : " + listRPASDiag[i].tagName + "          Value : " + dataAgent.getValueByTagID(listRPASDiag[i].tagName));
            }

            streamWriter.Flush();
            streamWriter.Close();
            Debug.Log("3");
        }
    }

    // ------------------------------------------------------------------------------------

    public void ChangeContent()
    {
        ResetContent();
        AddContent();
    }
    public void SearchContent()
    {
        isSearch = true;
        int count = 0;
        ResetContent();
        switch (groupIndex)
        {
            case 0:
                for (int i = 0; i < listPI.Count; i++)
                {
                    if (listPI[i].tagName.Contains(searchText.text))
                    {
                        count++;
                        CreateItemList(listPI[i].dataType, listPI[i].tagName.ToString(), listPI[i].description.ToString(), listPI[i].unit.ToString());
                        totalCount.text = "Total Count : " + string.Format("{0:N0}", count);
                    }
                }
                break;
            case 1:
                for (int i = 0; i < listAPD.Count; i++)
                {
                    if (listAPD[i].tagName.Contains(searchText.text))
                    {
                        count++;
                        CreateItemList(listAPD[i].dataType, listAPD[i].tagName.ToString(), listAPD[i].description.ToString(), listAPD[i].unit.ToString());
                        totalCount.text = "Total Count : " + string.Format("{0:N0}", count);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < listPHI.Count; i++)
                {
                    if (listPHI[i].tagName.Contains(searchText.text))
                    {
                        count++;
                        CreateItemList(listPHI[i].dataType, listPHI[i].tagName.ToString(), listPHI[i].description.ToString(), listPHI[i].unit.ToString());
                        totalCount.text = "Total Count : " + string.Format("{0:N0}", count);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < listRPASDiag.Count; i++)
                {
                    if (listRPASDiag[i].tagName.Contains(searchText.text))
                    {
                        count++;
                        CreateItemList(listRPASDiag[i].dataType, listRPASDiag[i].tagName.ToString(), listRPASDiag[i].description.ToString(), listRPASDiag[i].unit.ToString());
                        totalCount.text = "Total Count : " + string.Format("{0:N0}", count);
                    }
                }
                break;
            case 4:
                for (int i = 0; i < listRPASSimSend.Count; i++)
                {
                    if (listPI[i].tagName.Contains(searchText.text))
                    {
                        count++;
                        CreateItemList(listRPASSimSend[i].dataType, listRPASSimSend[i].tagName.ToString(), listRPASSimSend[i].description.ToString(), listRPASSimSend[i].unit.ToString());
                        totalCount.text = "Total Count : " + string.Format("{0:N0}", count);

                    }
                }
                break;
            case 5:
                for (int i = 0; i < listRPASSimResult.Count; i++)
                {
                    if (listPI[i].tagName.Contains(searchText.text))
                    {
                        count++;
                        CreateItemList(listRPASSimResult[i].dataType, listRPASSimResult[i].tagName.ToString(), listRPASSimResult[i].description.ToString(), listRPASSimResult[i].unit.ToString());
                        totalCount.text = "Total Count : " + string.Format("{0:N0}", count);
                    }
                }
                break;
            case 6:
                for (int i = 0; i < listPI.Count; i++)
                {
                    if (listPI[i].tagName.Contains(searchText.text))
                    {
                        count++;
                        CreateItemList(listCore[i].dataType, listCore[i].tagName.ToString(), listCore[i].description.ToString(), listCore[i].unit.ToString());
                        totalCount.text = "Total Count : " + string.Format("{0:N0}", count);
                    }
                }
                break;
        }
    }
    public void SearchCancle()
    {
        isSearch = false;
        searchText.text = "";
        pageIndex = 0;
        ResetContent();
        AddContent();
    }
    private void ResetContent()
    {
        var contents = GameObject.FindGameObjectsWithTag("Tag Content");
        foreach (var content in contents)
        {
            Destroy(content);
        }
        groupPI.color = Color.white;
        groupAPD.color = Color.white;
        groupPHI.color = Color.white;
        groupRPASDiag.color = Color.white;
        groupRPASSimSend.color = Color.white;
        groupRPASSimResult.color = Color.white;
        groupCore.color = Color.white;
    }

    // 버튼을 누를때마다 Group Count에 맞춰 100개씩 출력
    private void AddContent()
    {
        switch (groupIndex)
        {
            case 0:
                if (pageIndex + 1 != groupCount)
                {
                    for (int i = 0 + (100 * pageIndex); i < 100 + (100 * pageIndex); i++)
                    {
                        CreateItemList(listPI[i].dataType, listPI[i].tagName.ToString(), listPI[i].description.ToString(), listPI[i].unit.ToString());
                    }
                }
                else
                {
                    for (int i = 0 + (100 * (groupCount - 1)); i < listPI.Count; i++)
                    {
                        CreateItemList(listPI[i].dataType, listPI[i].tagName.ToString(), listPI[i].description.ToString(), listPI[i].unit.ToString());
                    }
                }
                totalCount.text = "Total Count : " + string.Format("{0:N0}", listPI.Count);
                break;

            case 1:
                if (pageIndex + 1 != groupCount)
                {
                    for (int i = 0 + (100 * pageIndex); i < 100 + (100 * pageIndex); i++)
                    {
                        CreateItemList(listAPD[i].dataType, listAPD[i].tagName.ToString(), listAPD[i].description.ToString(), listAPD[i].unit.ToString());
                    }
                }
                else
                {
                    for (int i = 0 + (100 * (groupCount - 1)); i < listAPD.Count; i++)
                    {
                        CreateItemList(listAPD[i].dataType, listAPD[i].tagName.ToString(), listAPD[i].description.ToString(), listAPD[i].unit.ToString());
                    }
                }
                totalCount.text = "Total Count : " + string.Format("{0:N0}", listAPD.Count);
                break;

            case 2:
                if (pageIndex + 1 != groupCount)
                {
                    for (int i = 0 + (100 * pageIndex); i < 100 + (100 * pageIndex); i++)
                    {
                        CreateItemList(listPHI[i].dataType, listPHI[i].tagName.ToString(), listPHI[i].description.ToString(), listPHI[i].unit.ToString());
                    }
                }
                else
                {
                    for (int i = 0 + (100 * (groupCount - 1)); i < listPHI.Count; i++)
                    {
                        CreateItemList(listPHI[i].dataType, listPHI[i].tagName.ToString(), listPHI[i].description.ToString(), listPHI[i].unit.ToString());
                    }
                }
                totalCount.text = "Total Count : " + string.Format("{0:N0}", listPHI.Count);
                break;

            case 3:
                if (pageIndex + 1 != groupCount)
                {
                    for (int i = 0 + (100 * pageIndex); i < 100 + (100 * pageIndex); i++)
                    {
                        CreateItemList(listRPASDiag[i].dataType, listRPASDiag[i].tagName.ToString(), listRPASDiag[i].description.ToString(), listRPASDiag[i].unit.ToString());
                    }
                }
                else
                {
                    for (int i = 0 + (100 * (groupCount - 1)); i < listRPASDiag.Count; i++)
                    {
                        CreateItemList(listRPASDiag[i].dataType, listRPASDiag[i].tagName.ToString(), listRPASDiag[i].description.ToString(), listRPASDiag[i].unit.ToString());
                    }
                }
                totalCount.text = "Total Count : " + string.Format("{0:N0}", listRPASDiag.Count);
                break;

            case 4:
                if (pageIndex + 1 != groupCount)
                {
                    for (int i = 0 + (100 * pageIndex); i < 100 + (100 * pageIndex); i++)
                    {
                        CreateItemList(listRPASSimSend[i].dataType, listRPASSimSend[i].tagName.ToString(), listRPASSimSend[i].description.ToString(), listRPASSimSend[i].unit.ToString());
                    }
                }
                else
                {
                    for (int i = 0 + (100 * (groupCount - 1)); i < listRPASSimSend.Count; i++)
                    {
                        CreateItemList(listRPASSimSend[i].dataType, listRPASSimSend[i].tagName.ToString(), listRPASSimSend[i].description.ToString(), listRPASSimSend[i].unit.ToString());
                    }
                }
                totalCount.text = "Total Count : " + string.Format("{0:N0}", listRPASSimSend.Count);
                break;

            case 5:
                if (pageIndex + 1 != groupCount)
                {
                    for (int i = 0 + (100 * pageIndex); i < 100 + (100 * pageIndex); i++)
                    {
                        CreateItemList(listRPASSimResult[i].dataType, listRPASSimResult[i].tagName.ToString(), listRPASSimResult[i].description.ToString(), listRPASSimResult[i].unit.ToString());
                    }
                }
                else
                {
                    for (int i = 0 + (100 * (groupCount - 1)); i < listRPASSimResult.Count; i++)
                    {
                        CreateItemList(listRPASSimResult[i].dataType, listRPASSimResult[i].tagName.ToString(), listRPASSimResult[i].description.ToString(), listRPASSimResult[i].unit.ToString());
                    }
                }
                totalCount.text = "Total Count : " + string.Format("{0:N0}", listRPASSimResult.Count);
                break;

            case 6:
                if (pageIndex + 1 != groupCount)
                {
                    for (int i = 0 + (100 * pageIndex); i < 100 + (100 * pageIndex); i++)
                    {
                        CreateItemList(listCore[i].dataType, listCore[i].tagName.ToString(), listCore[i].description.ToString(), listCore[i].unit.ToString());
                    }
                }
                else
                {
                    for (int i = 0 + (100 * (groupCount - 1)); i < listCore.Count; i++)
                    {
                        CreateItemList(listCore[i].dataType, listCore[i].tagName.ToString(), listCore[i].description.ToString(), listCore[i].unit.ToString());
                    }
                }
                totalCount.text = "Total Count : " + string.Format("{0:N0}", listCore.Count);
                break;
        }

        lastUpdateTime.text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        pageNumber.text = (pageIndex + 1) + " / " + groupCount;
    }

    public void _ClickLeft()
    {
        if (pageIndex > 0)
        {
            pageIndex--;
            ChangeContent();
        }
    }

    public void _ClickRight()
    {
        if (pageIndex + 1 != groupCount)
        {
            pageIndex++;
            ChangeContent();
        }
    }

    public void _ClickGroup(int num)
    {
        groupIndex = num;
        pageIndex = 0;
        switch (num)
        {
            case 0:
                groupCount = (int)(listPI.Count * 0.01f) + 1;
                break;
            case 1:
                groupCount = (int)(listAPD.Count * 0.01f) + 1;
                break;
            case 2:
                groupCount = (int)(listPHI.Count * 0.01f) + 1;
                break;
            case 3:
                groupCount = (int)(listRPASDiag.Count * 0.01f) + 1;
                break;
            case 4:
                groupCount = (int)(listRPASSimSend.Count * 0.01f) + 1;
                break;
            case 5:
                groupCount = (int)(listRPASSimResult.Count * 0.01f) + 1;
                break;
            case 6:
                groupCount = (int)(listCore.Count * 0.01f) + 1;
                break;
        }
        ChangeContent();
    }

    private void CreateList(List<GroupForm> list, string dataType, string tagName, string description, string unit)
    {
        GroupForm item = new GroupForm();
        item.dataType = dataType;
        item.tagName = tagName;
        item.description = description;
        item.unit = unit;
        list.Add(item);
    }

    private void CreateItemList(string dataType, string tagName, string description, string unit)
    {
        ScrollViewTagContent item = Instantiate(contentPrefab);
        item.transform.SetParent(content, false);
        item.dataType.text = dataType;
        item.tagName.text = tagName;
        item.description.text = description;
        item.unitText = unit;
    }
}