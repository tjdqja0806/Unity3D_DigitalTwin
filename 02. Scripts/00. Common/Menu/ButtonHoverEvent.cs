using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEvent : MonoBehaviour
{
    public Image image;
    public Sprite idle;
    public Sprite over;
    [Space]
    public GameObject line;
    public GameObject text;

    public void _PointerEnter() { image.sprite = over;
        line.SetActive(true);
        text.SetActive(true);
    }

    public void _PointerExit() { image.sprite = idle;
        line.SetActive(false);
        text.SetActive(false);
    }
}