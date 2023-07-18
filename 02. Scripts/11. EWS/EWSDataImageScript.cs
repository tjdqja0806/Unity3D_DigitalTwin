using UnityEngine;
using UnityEngine.UI;

public class EWSDataImageScript : MonoBehaviour
{
    [Space]
    public string symbolName;
    public float min;
    public float max;
    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;

    public Image[] valve;

    public Color red;
    public Color green;

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
                value = randomValue(min, max);
                if (value > 0.5f)
                {
                    for (int i = 0; i < valve.Length; i++)
                    {
                        valve[i].color = red;
                    }
                }
                else
                {
                    for (int i = 0; i < valve.Length; i++)
                    {
                        valve[i].color = green;
                    }
                }

            }
            else
            {
                if (symbolName.Contains(".C"))
                {
                    symbolName = symbolName.Substring(0, symbolName.Length - 2) + "_ON";     // 예 : HD-V0213-3-PBPT.C -> HD-V0213-3-PBPT_ON
                }
                //Debug.Log("[Valve] " + symbolName + " : '" + dataAgent.getValueStringBySymbolName(symbolName) + "'");
                value = dataAgent.getValueBySymbolName(symbolName);
                if (value >= 1)
                {
                    for (int i = 0; i < valve.Length; i++)
                    {
                        valve[i].color = red;
                    }
                }
                else
                {
                    for (int i = 0; i < valve.Length; i++)
                    {
                        valve[i].color = green;
                    }
                }
            }
        }
    }
    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}
