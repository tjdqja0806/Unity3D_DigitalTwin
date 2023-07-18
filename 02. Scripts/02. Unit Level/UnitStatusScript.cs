using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatusScript : MonoBehaviour
{
    public Image onImage;
    public Image offImage;
    [Space]
    public Sprite[] onSprite;
    public Sprite[] offSprite;
    [Space]
    public string symbolName;
    public float min = 0;
    public float max = 100;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;

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

            if(value >= 0.5f)
            {
                onImage.sprite = onSprite[1];
                offImage.sprite = offSprite[0];
            }
            else
            {
                onImage.sprite = onSprite[0];
                offImage.sprite = offSprite[1];
            }
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}
