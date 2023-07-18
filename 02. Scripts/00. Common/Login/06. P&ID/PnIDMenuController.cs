using UnityEngine;
using UnityEngine.UI;

public class PnIDMenuController : MonoBehaviour
{
    public Animator animator;
    [Space]
    public Image button;
    public Sprite menuOff;
    public Sprite menuOn;

    private bool isShow = false;

    public void Click()
    {
        isShow = !isShow;
        animator.SetBool("Show", isShow);
        if (isShow) { button.sprite = menuOn; }
        else { button.sprite = menuOff; }
    }
}