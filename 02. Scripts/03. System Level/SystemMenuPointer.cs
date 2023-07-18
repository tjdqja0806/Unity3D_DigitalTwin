using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemMenuPointer : MonoBehaviour
{
    public Sprite normalMain;
    public Sprite overMain;
    public Sprite selectMain;
    public Image imageMain;
    public TextMeshProUGUI text;
    [Space]
    public Sprite normalChart;
    public Sprite overChart;
    public Image imageChart;
    [Space]
    public Sprite normalSub;
    public Sprite selectSub;
    public Image imageSub;
    [Space]
    public int index = 0;

    private Color normalColor = new Color(0.07058824f, 0.07058824f, 0.1490196f);
    private SystemMenuController script;

    void Awake()
    {
        script = GameObject.Find("EventSystem").GetComponent<SystemMenuController>();
    }

    public void PointerEnterMain()
    {
        if (script.items[index].mainActive)
        {
            imageMain.sprite = normalMain;
            imageSub.sprite = normalSub;
            text.color = normalColor;
        }
        else
        {
            imageMain.sprite = overMain;
            text.color = Color.white;
            imageSub.sprite = selectSub;
        }
    }

    public void PointerExitMain()
    {
        if (script.items[index].mainActive) { PointerSelectMain(); }
        else
        {
            if (script.items[index].mainActive)
            {
                imageMain.sprite = overMain;
                text.color = Color.white;
                imageSub.sprite = selectSub;
            }
            else
            {
                imageMain.sprite = normalMain;
                imageSub.sprite = normalSub;
                text.color = normalColor;
            }
        }
    }

    public void PointerSelectMain()
    {
        imageMain.sprite = selectMain;
        text.color = Color.white;
        imageSub.sprite = selectSub;
    }

    public void PointerEnterChart()
    {
        imageChart.sprite = overChart;

    }

    public void PointerExitChart()
    {
        imageChart.sprite = normalChart;

    }
}