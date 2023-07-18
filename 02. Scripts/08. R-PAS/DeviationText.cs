using TMPro;
using UnityEngine;

public class DeviationText : MonoBehaviour
{
    public TextMeshProUGUI text;
    [Space]
    public string symbolNamePredicted;
    public string symbolNameCurrent;
    public float min = 0;
    public float max = 10;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double predicted;
    private double current;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (dataAgent.isAuto) {
                predicted = randomValue(min, max);
                current = randomValue(min, max);
            }
            else {
                predicted = float.Parse(string.Format("{0:N1}", dataAgent.getValueBySymbolName(symbolNamePredicted)));
                current = float.Parse(string.Format("{0:N1}", dataAgent.getValueBySymbolName(symbolNameCurrent)));
            }
            text.text = float.Parse(string.Format("{0:N1}", current - predicted)) + "";
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}