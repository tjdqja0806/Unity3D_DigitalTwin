using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RPASPerformance : MonoBehaviour
{
    [Header("Box")]
    public Material normalMat;
    public Material increaseMat;
    public Material decreaseMat;
    public MeshRenderer meshRenderer;
    [Space]
    [Header("UI")]
    public Sprite normalImg;
    public Sprite increaseImg;
    public Sprite decreaseImg;
    public Image background;
    [Space]
    [Header("Data")]
    public TextMeshProUGUI data1;
    public TextMeshProUGUI data2;
    public TextMeshProUGUI data3;
    [Space]
    public string symbolName1;
    public string symbolName2;
    public string symbolName3;
    public float min = -1.0f;
    public float max = 1.0f;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value1;
    private double value2;
    private double value3;
    private int performance;

    void Start()
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
                value1 = randomValue(min, max);
                value2 = randomValue(min, max);
                value3 = randomValue(min, max);
                if ((value1 + value2 + value3) > 0) { performance = 1; }
                else if ((value1 + value2 + value3) < 0) { performance = 2; }
                else { performance = 0; }
            }
            else { /*value = dataAgent.getValueBySymbolName(symbolName);*/ }

            data1.text = string.Format("{0:N1}", value1) + "";
            data2.text = string.Format("{0:N1}", value2) + "";
            data3.text = string.Format("{0:N1}", value3) + "";

            switch (performance)
            {
                case 0:
                    meshRenderer.material = normalMat;
                    background.sprite = normalImg;
                    break;
                case 1:
                    meshRenderer.material = increaseMat;
                    background.sprite = increaseImg;
                    break;
                case 2:
                    meshRenderer.material = decreaseMat;
                    background.sprite = decreaseImg;
                    break;
            }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}