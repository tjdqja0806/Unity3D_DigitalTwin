using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentMenuPointer : MonoBehaviour
{
    public Sprite normalMain;
    public Sprite overMain;
    public Sprite selectMain;
    public Image imageMain;
    public TextMeshProUGUI text;

    [Space]
    public Sprite normalSub;
    public Sprite selectSub;
    public Image imageSub;
    [Space]
    public int index = 0;

    private Color overColor = new Color(0, 0.01568628f, 0.1647059f);
    void Awake()
    {
    }

    public void PointerEnterMain()
    {
        imageMain.sprite = overMain;
        text.color = Color.white;
        imageSub.sprite = normalSub;
    }

    public void PointerExitMain()
    {
        imageMain.sprite = normalMain;
        imageSub.sprite = normalSub;
        text.color = overColor;
    }

    public void PointerSelectMain()
    {
        imageMain.sprite = selectMain;
        text.color = Color.white;
        imageSub.sprite = selectSub;
    }
}
