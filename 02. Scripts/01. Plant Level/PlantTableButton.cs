using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantTableButton : MonoBehaviour
{
    public Image[] floorButton;
    public Sprite mouseOver;
    public Sprite origin;
    private int OverStatus = 99;

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < floorButton.Length; i++)
        {
            if (i == OverStatus)
                floorButton[i].sprite = mouseOver;
            else
                floorButton[i].sprite = origin;
        }
    }

    public void MouseOver(int num)
    {
        OverStatus = num;
    }
    public void MouseExit()
    {
        OverStatus = 99;
    }

    private void OnEnable()
    {
        OverStatus = 99;
    }
}
