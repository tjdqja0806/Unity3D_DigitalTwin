using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoreDataScript : MonoBehaviour
{
    public Transform imageTrans;
    public TextMeshProUGUI text;
    public Image statusBackground;
    public Sprite[] statusSprite;
    [Space]
    public string symbolName;
    [Space]
    public float randomMin;
    public float randomMax;
    public float transformMin;
    public float transformMax;
    public float rangeMin;
    public float rangeMax;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private Vector3 defaultPos;
    private double value;
    private float calValue;
    private float result;


    void Awake()
    {
        defaultPos = imageTrans.transform.localPosition;
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (dataAgent.isAuto) { value = randomValue(randomMin, randomMax); }
            else { value = dataAgent.getValueBySymbolName(symbolName); }

            calValue = calculate(rangeMin, rangeMax, value);
            result = (transformMax - transformMin) * calValue * 0.01f;
            imageTrans.transform.localPosition = new Vector3(defaultPos.x + result, defaultPos.y, defaultPos.z);
            if (calValue >= 80.0f)
            {
                statusBackground.sprite = statusSprite[4];
                text.text = "Severe";
            }
            else if (calValue >= 60.0f && calValue < 80.0f)
            {
                statusBackground.sprite = statusSprite[3];
                text.text = "Alart";
            }
            else if (calValue >= 40.0f && calValue < 60f)
            {
                statusBackground.sprite = statusSprite[2];
                text.text = "Warning";
            }
            else if(calValue >= 20 && calValue < 40)
            {
                statusBackground.sprite = statusSprite[1];
                text.text = "Attention";
            }
            else if (calValue >= 0 && calValue < 20)
            {
                statusBackground.sprite = statusSprite[0];
                text.text = "Normal";
            }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    private float calculate(float min, float max, double value) { return (float)((value - min) / (max - min)) * 100f; }
}

