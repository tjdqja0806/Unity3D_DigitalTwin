using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EWSMenuPointer : MonoBehaviour
{
    public Sprite normalMain;
    public Sprite overMain;
    public Image imageMain;
    public TextMeshProUGUI text;

    private Color normalColor = new Color(0.07058824f, 0.07058824f, 0.1490196f);

    void Awake()
    {

    }

    public void PointerEnterMain()
    {
        imageMain.sprite = overMain;
        text.color = Color.white;
    }

    public void PointerExitMain()
    {
        imageMain.sprite = normalMain; 
        text.color = normalColor;
    }
}
