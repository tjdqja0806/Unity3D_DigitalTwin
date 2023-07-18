using UnityEngine;

public class AxisRotate_Y : MonoBehaviour
{
    public string symbolName;
    public float min = 1000;
    public float max = 1000;
    [Space]
    public bool Reverse = false;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value = 0;

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
        }

        if (Reverse) { transform.Rotate(Vector3.down * (float)value * Time.deltaTime * 0.9f); }
        else { transform.Rotate(Vector3.up * (float)value * Time.deltaTime * 0.9f); }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}