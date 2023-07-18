using System.Collections.Generic;
using UnityEngine;

public class ScrollViewPerformance : MonoBehaviour
{
    public TextAsset file;
    public RectTransform content;
    public ScrollViewIndicator contentPrefab;
    [HideInInspector]
    public bool isAlarm = false;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private List<string> listStatus = new List<string>();
    private string value = "";

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();

        List<Dictionary<string, object>> data = CSVReader.Read(file.name);

        for (int i = 0; i < data.Count; i++)
        {
            CreateItemList(data[i]["Description"].ToString(), data[i]["SymbolName1"].ToString(), data[i]["SymbolName2"].ToString());
            listStatus.Add(data[i]["SymbolName2"].ToString());
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            for (int i = 0; i < listStatus.Count; i++)
            {
                if (dataAgent.isAuto) { value = "Normal"; }
                else { value = dataAgent.getValueStringBySymbolName(listStatus[i]); }

                /*if (value.Equals(""))
                {
                    isAlarm = false;
                }
                else
                {
                    if (float.Parse(value) > 0)
                    {
                        //Debug.Log("Scroll View Performance Error Value : " + value);
                        isAlarm = true;
                        return;
                    }
                    else
                    {
                        isAlarm = false;
                    }
                }*/
            }
        }
    }

    private void CreateItemList(string description, string symbolName1, string symbolName2)
    {
        ScrollViewIndicator item = Instantiate(contentPrefab);
        item.transform.SetParent(content, false);

        item.description.text = description;
        item.descriptionText = description;

        item.symbolName1 = symbolName1;
        item.symbolName2 = symbolName2;
    }
}