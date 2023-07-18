using System.Collections.Generic;
using UnityEngine;

public class ScrollViewControl : MonoBehaviour
{
    public TextAsset file;
    public RectTransform content;
    public ScrollViewContent contentPrefab;

    private string replaceTemp = "";

    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(file.name);

        if (file.name.Contains("_PI"))
        {
            for (int i = 0; i < data.Count; i++)
            {
                CreateItemList(data[i]["Description"].ToString(), data[i]["EnUnit"].ToString(), data[i]["SymbolName"].ToString());
            }
        }
        if (file.name.Contains("_APD"))
        {
            for (int i = 0; i < data.Count; i++)
            {
                replaceTemp = data[i]["구분"].ToString();
                if (replaceTemp.Contains("진단 결과")) { replaceTemp = replaceTemp.Replace("진단 결과", "결함 원인"); }
                CreateItemList(replaceTemp, "", data[i]["SymbolName"].ToString());
            }
        }
        if (file.name.Contains("_RPAS"))
        {
            for (int i = 0; i < data.Count; i++)
            {
                CreateItemList(data[i]["Description"].ToString(), data[i]["EnUnit"].ToString(), data[i]["SymbolName"].ToString());
            }
        }


    }

    private ScrollViewContent CreateItemList(string description, string unit, string symbolName)
    {
        ScrollViewContent item = Instantiate(contentPrefab);
        item.transform.SetParent(content, false);

        item.description.text = description;
        item.descriptionText = description;

        item.unit.text = unit;

        item.symbolName = symbolName;

        return item.GetComponent<ScrollViewContent>();
    }
}