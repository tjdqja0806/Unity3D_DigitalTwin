using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitTempScript : MonoBehaviour
{
    public Image image;
    [Space]
    public Sprite[] imageAnim;
    public TextMeshProUGUI text;
    [Space]
    public string symbolName;
    public float rangeMin;
    public float rangeMax;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private float value;
    private float calValue;

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
            if (dataAgent.isAuto) { value = randomValue(rangeMin, rangeMax); }
            else { value = (float)dataAgent.getValueBySymbolName(symbolName); }
            calValue = calculate(0, 100, value);
            text.text = string.Format("{0:N0}", value);
        }
        if (calValue > 90)
            image.sprite = imageAnim[9];
        else if (calValue > 80)
            image.sprite = imageAnim[8];
        else if (calValue > 70)
            image.sprite = imageAnim[7];
        else if (calValue > 60)
            image.sprite = imageAnim[6];
        else if (calValue > 50)
            image.sprite = imageAnim[5];
        else if (calValue > 40)
            image.sprite = imageAnim[4];
        else if (calValue > 30)
            image.sprite = imageAnim[3];
        else if (calValue > 20)
            image.sprite = imageAnim[2];
        else if (calValue > 10)
            image.sprite = imageAnim[1];
        else
            image.sprite = imageAnim[0];
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }

    private float calculate(float min, float max, double value)
    {
        return (float)(value / max) * 100f;
    }
}
