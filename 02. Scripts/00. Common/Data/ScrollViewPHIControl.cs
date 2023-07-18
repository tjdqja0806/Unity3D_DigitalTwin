using System.Collections.Generic;
using UnityEngine;

public class ScrollViewPHIControl : MonoBehaviour
{
    public TextAsset file;
    public RectTransform content;
    public ScrollViewPHI contentPrefab;

    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read(file.name);

        int temp = data.Count / 4;
        for (var i = 0; i < temp; i++)
        {
            CreateItemList(data[i * 4]["Description"].ToString(),
                data[i * 4]["EuUnit"].ToString(), data[i * 4]["SymbolName"].ToString(),
                data[(i * 4) + 1]["EuUnit"].ToString(), data[(i * 4) + 1]["SymbolName"].ToString(),
                data[(i * 4) + 2]["EuUnit"].ToString(), data[(i * 4) + 2]["SymbolName"].ToString(),
                data[(i * 4) + 3]["SymbolName"].ToString()
                );
        }
    }

    private ScrollViewPHI CreateItemList(string description,
        string alarmValueUnit, string symbolNameAlarmValue,
        string expectedValueUnit, string symbolNameExpectedValue,
        string alarmIndexUnit, string symbolNameAlarmIndex,
        string symbolNameAlarmWarningLevel)
    {
        ScrollViewPHI item = Instantiate(contentPrefab);
        item.transform.SetParent(content, false);
        string[] temp = description.Split(char.Parse("_"));

        item.description.text = temp[0];
        item.descriptionText = description;

        item.alarmValueUnit.text = alarmValueUnit;
        item.symbolNameAlarmValue = symbolNameAlarmValue;

        item.expectedValueUnit.text = expectedValueUnit;
        item.symbolNameExpectedValue = symbolNameExpectedValue;

        item.alarmIndexUnit.text = alarmIndexUnit;
        item.symbolNameAlarmIndex = symbolNameAlarmIndex;

        item.symbolNameAlarmWarningLevel = symbolNameAlarmWarningLevel;

        return item.GetComponent<ScrollViewPHI>();
    }
}