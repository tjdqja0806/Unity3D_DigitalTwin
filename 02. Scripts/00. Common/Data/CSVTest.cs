using System.Collections.Generic;
using UnityEngine;

public class CSVTest : MonoBehaviour
{
    public TextAsset file;
    public RectTransform content;
    public ScrollViewContent contentPrefab;

    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(file.name);

        if (file.name.Contains("_PI"))
        {
            for (var i = 0; i < data.Count; i++)
            {
                CreateItemList(data[i]["Description"].ToString(), data[i]["EnUnit"].ToString(), data[i]["SymbolName"].ToString());
            }
        }
        if (file.name.Contains("_APD"))
        {
            for (var i = 0; i < data.Count; i++)
            {
                CreateItemList(data[i]["Description"].ToString() + " (" + data[i]["구분"].ToString() + ")", "", data[i]["SymbolName"].ToString());
            }
        }
        if (file.name.Contains("_PHI"))
        {
            for (var i = 0; i < data.Count; i++)
            {
                CreateItemList(data[i]["Description"].ToString(), data[i]["SymbolUnit"].ToString(), data[i]["SymbolName"].ToString());
            }
        }
        if (file.name.Contains("_RPAS"))
        {
            for (var i = 0; i < data.Count; i++)
            {
                CreateItemList(data[i]["Description"].ToString(), data[i]["EnUnit"].ToString(), data[i]["SymbolName"].ToString());
            }
        }


    }

    void Update()
    {

    }

    private ScrollViewContent CreateItemList(string description, string unit, string symbolName)
    {
        ScrollViewContent item = Instantiate(contentPrefab);
        item.transform.SetParent(content, false);
        item.description.text = description;
        item.unit.text = unit;
        item.symbolName = symbolName;
        return item.GetComponent<ScrollViewContent>();
    }
}