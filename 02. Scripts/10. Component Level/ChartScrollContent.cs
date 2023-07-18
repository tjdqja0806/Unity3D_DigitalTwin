using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChartScrollContent : MonoBehaviour
{
    public Sprite normal;
    public Sprite check;
    [Space]
    public Image checkbox;
    public TextMeshProUGUI description;
    [HideInInspector]
    public string des = "";
    [HideInInspector]
    public string symbolName = "";
    [HideInInspector]
    public int index = 0;
    [HideInInspector]
    public string unit = "";
    [HideInInspector]
    public bool isActive = false;

    void Awake() { }

    public void _ClickEvent()
    {
        isActive = !isActive;
        ChangeCheckbox(isActive);
    }

    public void ChangeCheckbox(bool status)
    {
        isActive = status;
        if (status) { checkbox.sprite = check; }
        else { checkbox.sprite = normal; }
    }
}