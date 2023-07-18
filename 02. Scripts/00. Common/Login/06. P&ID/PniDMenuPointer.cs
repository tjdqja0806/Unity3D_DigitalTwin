using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PniDMenuPointer : MonoBehaviour
{
    public Sprite normal;
    public Sprite over;
    [Space]
    public TextMeshProUGUI text;

    private Image image;

    void Awake() { image = GetComponent<Image>(); }

    public void PointerEnter()
    {
        image.sprite = over;
        text.color = Color.white;
    }

    public void PointerExit()
    {
        image.sprite = normal;
        text.color = Color.white;
    }
}