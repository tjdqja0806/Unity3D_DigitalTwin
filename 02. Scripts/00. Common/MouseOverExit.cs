using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverExit : MonoBehaviour
{

    public Image image;
    public Sprite originImage;
    public Sprite overImage;

    public void MouseOver() 
    {
        image.sprite = overImage;
    }
    public void MouseExit()
    {
        image.sprite = originImage;
    }
}
