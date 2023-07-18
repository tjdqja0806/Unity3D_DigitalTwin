using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClickChangeImage : MonoBehaviour
{
    public Image image;
    public Sprite originSprite;
    public Sprite clickSprite;

    private bool isClick;

    void Update()
    {
        if (isClick)
            image.sprite = clickSprite;
        else
            image.sprite = originSprite;
    }

    public void Click()
    {
        isClick = !isClick;
    }
}
