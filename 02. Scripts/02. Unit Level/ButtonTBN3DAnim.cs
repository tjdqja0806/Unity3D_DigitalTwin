using UnityEngine;

public class ButtonTBN3DAnim : MonoBehaviour
{
    public Animator animator;

    private bool isPlay = false;

    void Awake()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { isPlay = !isPlay; }
        if (isPlay)
        {
            animator.SetBool("Play", true);
        }
        else
        {
            animator.SetBool("Play", false);
        }
    }

    public void click()
    {
        isPlay = !isPlay;
        if (isPlay)
        {
            animator.SetBool("Play", true);
        }
        else
        {
            animator.SetBool("Play", false);
        }
    }
}