using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RPASArrowContent : MonoBehaviour
{
    public TextAsset fileCSV;

    [Space]
    public RectTransform content;
    public RPASArrowPrefabContent[] arrowContentPrefab;

    [Space]
    public TextMeshProUGUI equipmentTitle;

    private List<Form> forms = new List<Form>();
    public struct Form
    {
        public string arrowType;
        public string mainTitle;
        public string subTitle;
        public string fTagName;
        public string pTagName;
        public string tTagName;
        public string hTagName;
        public string mTagName;
        public string fDigit;
        public string pDigit;
        public string tDigit;
        public string hDigit;
        public string mDigit;
    }
    // Start is called before the first frame update
    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(fileCSV.name);
        for (int i = 0; i < data.Count; i++) 
        { CreateList(
            forms, 
            data[i]["ArrowType"].ToString(), 
            data[i]["MainTitle"].ToString(), 
            data[i]["SubTitle"].ToString(), 
            data[i]["FTagName"].ToString(), 
            data[i]["PTagName"].ToString(), 
            data[i]["TTagName"].ToString(), 
            data[i]["HTagName"].ToString(), 
            data[i]["MTagName"].ToString(), 
            data[i]["FDigit"].ToString(), 
            data[i]["PDigit"].ToString(), 
            data[i]["TDigit"].ToString(), 
            data[i]["HDigit"].ToString(), 
            data[i]["MDigit"].ToString()); }
        for(int i = 0; i < forms.Count; i++) 
        { CreateContentList(
            forms[i].arrowType, 
            forms[i].mainTitle, 
            forms[i].subTitle, 
            forms[i].fTagName, 
            forms[i].pTagName, 
            forms[i].tTagName, 
            forms[i].hTagName, 
            forms[i].mTagName, 
            forms[i].fDigit, 
            forms[i].pDigit, 
            forms[i].tDigit, 
            forms[i].hDigit, 
            forms[i].mDigit); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CreateList(List<Form> list, string arrowType, string mainTitle, string subTitle, string fTagName, string pTagName, string tTagName, string hTagName, string mTagName
        , string fDigit, string pDigit, string tDigit, string hDigit, string mDigit)
    {
        Form item = new Form();
        item.arrowType = arrowType;
        item.mainTitle = mainTitle;
        item.subTitle = subTitle;
        item.fTagName = fTagName;
        item.pTagName = pTagName;
        item.tTagName = tTagName;
        item.hTagName = hTagName;
        item.mTagName = mTagName;
        item.fDigit = fDigit;
        item.pDigit = pDigit;
        item.tDigit = tDigit;
        item.hDigit = hDigit;
        item.mDigit = mDigit;
        list.Add(item);
    }
    private void CreateContentList(string arrowType, string mainTitle, string subTitle, string fTagName, string pTagName, string tTagName, string hTagName, string mTagName
        , string fDigit, string pDigit, string tDigit, string hDigit, string mDigit)
    {
        RPASArrowPrefabContent item;
        if (arrowType == "0")
        {
            //오른쪽 화살표
            item = Instantiate(arrowContentPrefab[0]);
        }
        else
        {
            //왼쪽화살표
            item = Instantiate(arrowContentPrefab[1]);
        }
        item.transform.SetParent(content, false);
        item.mainTitle.text = mainTitle;
        item.subTitle.text = subTitle;
        item.fTagName = fTagName;
        item.pTagName = pTagName;
        item.tTagName = tTagName;
        item.hTagName = hTagName;
        item.mTagName = mTagName;
        item.fDigit = fDigit;
        item.pDigit = pDigit;
        item.tDigit = tDigit;
        item.hDigit = hDigit;
        item.mDigit = mDigit;
    }
}
