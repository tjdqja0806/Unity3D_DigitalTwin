using UnityEngine;

public class PanelControl : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject background;

    public void _ClickLevel(bool check)
    {
        canvasGroup.alpha = 1;
        if (check) { background.SetActive(true); }
        else { background.SetActive(false); }
    }
}