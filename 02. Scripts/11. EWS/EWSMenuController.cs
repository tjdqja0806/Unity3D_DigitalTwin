using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EWSMenuController : MonoBehaviour
{
    [Space]
    public Animator animator;

    private bool isShow = false;

    void Awake()
    {

    }
    private void Update()
    {

    }

    public void ClickShow()
    {
        isShow = !isShow;
        animator.SetBool("Open", isShow);
        //if (isShow) { button.sprite = menuOn; }
        //else { button.sprite = menuOff; }
    }
}
