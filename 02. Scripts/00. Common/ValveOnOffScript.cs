using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveOnOffScript : MonoBehaviour
{
    public string symbolName;

    private Animator anim;
    private DataAgent dataAgent;
    private float timer = 0.0f;
    private double value;
    public bool isOn; //private로 변경하기
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;

            if (dataAgent.isAuto) { isOn = true; }
            else
            {
                value = dataAgent.getValueBySymbolName(symbolName);
            }
            //if (value >= 1) { isOn = true; }
            //else { isOn = false; }
        }
        if (isOn)
            anim.SetBool("Play", true);
        else
            anim.SetBool("Play", false);
    }
}
