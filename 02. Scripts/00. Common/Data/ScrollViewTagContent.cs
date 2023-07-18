using TMPro;
using UnityEngine;

public class ScrollViewTagContent : MonoBehaviour
{
    public TextMeshProUGUI dataType;
    public TextMeshProUGUI tagName;
    public TextMeshProUGUI description;
    public TextMeshProUGUI value;
    [Space]
    public LineChartTagList chartPrefab;
    [HideInInspector]
    public string unitText;

    private DataAgent dataAgent;
    private double resultData;

    void Start()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        UpdateValue();
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    public void UpdateValue()
    {
        if (dataAgent.isAuto)
        {
            resultData = randomValue(0, 100);
        }
        else
        {
            resultData = dataAgent.getValueByTagID(tagName.text);
            /*if (resultData > -1 && resultData < 1 && resultData != 0) { result = string.Format("{0:N3}", resultData) + ""; }
            else { result = string.Format("{0:N1}", resultData) + ""; }*/
        }
        value.text = resultData + " " + unitText;
    }

    public void _ClickChartButton()
    {
        CreateChart(tagName.text);
    }

    private void CreateChart(string tagName)
    {
        LineChartTagList item = Instantiate(chartPrefab);
        item.transform.SetParent(GameObject.Find("Menu 2").transform, false);

        item.tagID.text = tagName;
        item.tagName = tagName;
    }
}