using UnityEngine;

public class WaterViewControl : MonoBehaviour
{

    public Material waterMaterial;
    /*public float min = 0;
    public float max = 100;*/
    [Space]
    [Range(0, 100)]
    public float temp = 50.0f;
    public string tempSymbolName;
    /*public float tempMin;
    public float tempMax;*/
    private float tempAverage = 100f;
    private float tempCal = 0;
    [Range(0, 100)]
    public float pressure = 50.0f;
    public string pressureSymbolName;
    /*public float pressureMin;
    public float pressureMax;*/
    private float pressureAverage = 100f;
    private float pressureCal = 0;
    [Space]
    [Range(0, 100)]
    public float flow = 50.0f;
    public string flowSymbolName;
    public float flowMin;
    public float flowMax;

    private float timer = 0.0f;
    private DataAgent dataAgent;
    private bool isTemp;
    private int blendingBranchInt = 0;
    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    private void Start()
    {
        //tempAverage = (tempMax + tempMin) / 2;
        //pressureAverage = (pressureMax + pressureMin) / 2;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (tempSymbolName == "00")
            {
                temp = 50.0f;
            }
            else
            {
                if (dataAgent.isAuto)
                    temp = randomValue(0, 100);
                else
                    temp = (float)dataAgent.getValueBySymbolName(tempSymbolName);
            }

            if (flowSymbolName == "00")
            {
                flow = 50.0f;
            }
            else
            {
                if (dataAgent.isAuto)
                    flow = randomValue(0, 100);
                else
                    flow = (float)dataAgent.getValueBySymbolName(flowSymbolName);
            }

            if (pressureSymbolName == "00")
            {
                pressure = 50.0f;
            }
            else
            {
                if (dataAgent.isAuto)
                    pressure = randomValue(0, 100);
                else
                    pressure = (float)dataAgent.getValueBySymbolName(pressureSymbolName);
            }

            if (temp > tempAverage && isTemp)
            {
                blendingBranchInt = 1;
                temp = (temp - tempAverage) * 2;
            }
            else if (temp <= tempAverage && isTemp)
            {
                blendingBranchInt = 0;
                temp = temp * 2;
            }
            else if (pressure > pressureAverage && !isTemp)
            {
                blendingBranchInt = 1;
                pressure = (pressure - pressureAverage) * 2;
            }
            else if (pressure <= pressureAverage && !isTemp)
            {
                blendingBranchInt = 0;
                pressure = pressure * 2;
            }

            waterMaterial.SetInt("Blending_Branch", blendingBranchInt);  // Boolean : 0 or 1
            
            if (isTemp)
            {
                tempCal = calculateRate(0, 200, temp);  // float : 0 ~ 1
                if (tempCal >= 1) { waterMaterial.SetFloat("Blending", 1); }
                else { waterMaterial.SetFloat("Blending", tempCal); }
            }
            else
            {
                pressureCal = calculateRate(0, 200, pressure);  // float : 0 ~ 1
                if (pressureCal >= 1) { waterMaterial.SetFloat("Blending", 1); }
                else { waterMaterial.SetFloat("Blending", pressureCal); }
            }
            
            waterMaterial.SetFloat("Flow_Speed", calculateRate(flowMin, flowMax, flow));  // float : 0 ~ 1
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