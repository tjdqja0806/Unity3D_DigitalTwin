using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AssembleSettingScriptGenerator : MonoBehaviour
{
    [Space]
    [Header("Game Object")]
    public GameObject goDrag;
    public GameObject goAnimate;
    public Animator animator;
    public Animator animatorExciter;
    public Animator animIcon;
    [HideInInspector]
    public bool isback = false;

    private bool statusDrag = true;
    private bool isAnimate = false;
    private bool isReAnimate = false;
    [Space]
    public TextMeshProUGUI buttonText;
    public GameObject[] background;

    void Awake()
    {

    }

    void Update()
    {

        if (statusDrag)
        {
            goDrag.SetActive(true);
            goAnimate.SetActive(false);
            animIcon.gameObject.SetActive(false);
        }
        else
        {
            goDrag.SetActive(false);
            goAnimate.SetActive(true);
            animIcon.gameObject.SetActive(true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && 
            animator.GetCurrentAnimatorStateInfo(0).IsName("GEN_boom"))
        {
            if (isAnimate)
            {
                animator.SetFloat("speed", 0);
                isAnimate = false;
            }
        }
        if (isReAnimate && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0 &&
            animator.GetCurrentAnimatorStateInfo(0).IsName("GEN_boom"))
        {
            animator.SetFloat("speed", 0);
            isReAnimate = false;
        }
        if (animatorExciter.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1
            && animatorExciter.GetCurrentAnimatorStateInfo(0).IsName("Exciter"))
        {
            if (isAnimate)
            {
                animatorExciter.SetFloat("speed", 0);
                isAnimate = false;
            }
        }
        if (isReAnimate && animatorExciter.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0 &&
            animatorExciter.GetCurrentAnimatorStateInfo(0).IsName("Exciter"))
        {
            if (isAnimate)
            {
                animatorExciter.SetFloat("speed", 0);
                isReAnimate = false;
            }
        }
        if (animIcon.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1
            && animIcon.GetCurrentAnimatorStateInfo(0).IsName("GENIcon"))
        {
            if (isAnimate)
            {
                animIcon.SetFloat("speed", 0);
                isAnimate = false;
            }
        }
        if (isReAnimate && animIcon.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0 &&
            animIcon.GetCurrentAnimatorStateInfo(0).IsName("GENIcon"))
        {
            if (isAnimate)
            {
                animIcon.SetFloat("speed", 0);
                isReAnimate = false;
            }
        }
    }

    public void ClickBtnDrag()
    {
        if (statusDrag) { isback = true; }
        else { animator.Rebind(); animatorExciter.Rebind(); animIcon.Rebind(); }
        statusDrag = !statusDrag;
        if (statusDrag)
        {
            background[0].SetActive(true);
            background[1].SetActive(false);
        }
        else
        {
            background[0].SetActive(false);
            background[1].SetActive(true);
        }
    }
    public void ClickBtnDssmbl()
    {
        animator.SetBool("play", true);
        animatorExciter.SetBool("play", true);
        animator.SetFloat("speed", 1.0f);
        animatorExciter.SetFloat("speed", 1.0f);
        animIcon.SetBool("isOn", true);
        animIcon.SetFloat("speed", 1.0f);
        isAnimate = true;
    }

    public void ClickBtnAsmbl()
    {
        if (statusDrag) { isback = true; }
        else
        {
            isReAnimate = true;
            animator.SetFloat("speed", -1.0f);
            animatorExciter.SetFloat("speed", -1.0f);
            animIcon.SetFloat("speed", -1.0f);
        }
    }
    public void _AmimationReset()
    {
        ClickBtnDrag();
        ClickBtnDrag();
    }
}
