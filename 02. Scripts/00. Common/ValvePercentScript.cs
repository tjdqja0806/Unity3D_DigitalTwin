using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValvePercentScript : MonoBehaviour
{
    public string symbolName;
    public float min;
    public float max;
    private float timer = 0.0f;
    private double random;
    private float before = 0;
    private float percent = 0;
    private DataAgent dataAgent;
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        anim = GetComponent<Animator>();
        //anim.SetBool("play", true);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (dataAgent.isAuto)
                random = Double.Parse(string.Format("{0:N1}", dataAgent.getValueBySymbolName(symbolName)));
            else
                random = randomValue(min, max);
            percent = calculate((int)min, (int)max, random);
        }
        if (Mathf.Abs(percent - before) > 0.01)
        {
            before = Mathf.Lerp(before, percent, Time.deltaTime * 3);
        }
        else
        {
            before = percent;
        }
        anim.SetFloat("Speed", before);
    }

    private float calculate(int min, int max, double value)
    {
        return (float)((value - min) / (max - min));
    }

    private float randomValue(float min, float max)
    {
        float random = UnityEngine.Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}
