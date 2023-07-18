using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPASUIAnimation : MonoBehaviour
{
    private Animator rightUI;
    private Animator leftUI;
    private bool isAnimation = false;
    // Start is called before the first frame update
    void Start()
    {
        rightUI = GameObject.Find("Right UI").GetComponent<Animator>();
        leftUI = GameObject.Find("Left UI").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Animation()
    {
        isAnimation = !isAnimation;
        if (isAnimation)
        {
            rightUI.SetBool("Right", true);
            rightUI.SetBool("Left", false);
            leftUI.SetBool("Left", true);
            leftUI.SetBool("Right", false);
        }
        else
        {
            rightUI.SetBool("Right", false);
            rightUI.SetBool("Left", true);
            leftUI.SetBool("Left", false);
            leftUI.SetBool("Right", true);
        }
    }
}
