using UnityEngine;

public class WaterLevelControl : MonoBehaviour
{
    public GameObject[] water;
    [Space]
    public string symbolName;
    public float min = 0;
    public float max = 100;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;
    private float calValue;
    private int levelNum;

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
            if (dataAgent.isAuto) { value = randomValue(min, max); }
            else { value = dataAgent.getValueBySymbolName(symbolName); }
            calValue = calculate(min, max, value);
            levelNum = CalLevel(calValue);
            if (levelNum >= water.Length) { levelNum = water.Length - 1; }
            for (int i = 0; i < water.Length; i++)
            {
                if (i == levelNum) { water[i].SetActive(true); }
                else { water[i].SetActive(false); }
            }
        }
    }

    private int CalLevel(float value)
    {
        return (int)(Mathf.Round(water.Length * value * 0.01f));
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    private float calculate(float min, float max, double value) { return (float)((value - min) / (max - min)) * 100f; }
}