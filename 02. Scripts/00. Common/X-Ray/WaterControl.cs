using UnityEngine;

[RequireComponent(typeof(XRayMat))]
public class WaterControl : MonoBehaviour
{
    public Material waterMaterial;
    [Space]
    public string symbolName;
    public bool tempCheck = true;
    public bool flowCheck = true;
    [Space]
    public float tempMin = 0.0f;
    public float tempMax = 100.0f;
    public float flowMin = 0.0f;
    public float flowMax = 100.0f;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private float tempValue;
    private float flowValue;

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

            if (dataAgent.isAuto)
            {
                if (tempCheck) { tempValue = randomValue(tempMin, tempMax); }
                if (flowCheck) { flowValue = randomValue(flowMin, flowMax); }
            }
            else
            {
                // value = dataAgent.getValueBySymbolName(symbolName);
            }

            waterMaterial.SetInt("Blending_Branch", 0);  // Boolean : 0 or 1
            if (flowCheck)
            {
                waterMaterial.SetFloat("Flow_Speed", calculateRate(flowMin, flowMax, flowValue));  // float : 0 ~ 1
            }
            if (tempCheck)
            {
                waterMaterial.SetFloat("Blending", calculateRate(tempMin, tempMax, tempValue));  // float : 0 ~ 1
            }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    // Return : 0 ~ 1
    private float calculateRate(float min, float max, float value) { return (float)((value - min) / (max - min)); }
}