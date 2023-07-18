using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComponentAlarmButton : MonoBehaviour
{
    public TextMeshProUGUI[] text;
    public Image[] checkbox;
    public Sprite origin;
    public Sprite change;

    private int status;

    private Color yellow = new Color(224, 205, 115);
    private Color white = new Color(255, 255, 255);

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < checkbox.Length; i++)
        {
            if(i == status)
            {
                text[i].fontSize = 18;
                text[i].color = yellow;
                checkbox[i].sprite = change;
            }
            else
            {
                text[i].fontSize = 14;
                text[i].color = white;
                checkbox[i].sprite = origin;
            }
        }
/*
        if (isClick)
        {
            text.fontSize = 18;
            text.color = yellow;
            checkbox.sprite = change;
        }
        else
        {
            text.fontSize = 14;
            text.color = white;
            checkbox.sprite = origin;
        }*/
    }
    public void Click(int num)
    {
        status = num;
    }
}
