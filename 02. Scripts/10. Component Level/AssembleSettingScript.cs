using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssembleSettingScript : MonoBehaviour
{
    [Space]
    [Header("Game Object")]
    public GameObject goDrag;
    public GameObject goAnimate;
    public Animator animator;
    public Animator animIcon;
    [HideInInspector]
    public bool isback = false;

    private bool statusDrag = true;
    private bool isAnimate = false;
    private bool isReAnimate = false;
    private bool isIconAnim = false;
    private bool isIconReAnim = false;
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
            //imageDrag.sprite = spriteOn;
            //imageAuto.sprite = spriteOff;
            //btnDssmbl.interactable = false;
        }
        else
        {
            goDrag.SetActive(false);
            goAnimate.SetActive(true);
            animIcon.gameObject.SetActive(true);
            //imageDrag.sprite = spriteOff;
            //imageAuto.sprite = spriteOn;
            //btnDssmbl.interactable = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && 
            (animator.GetCurrentAnimatorStateInfo(0).IsName("HPTBN_boom")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("LPTBN_boom")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("GEN_boom")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("FWP_boom")))
        {
            if (isAnimate)
            {
                animator.SetFloat("speed", 0);
                isAnimate = false;
            }
        }
        if(isReAnimate && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0 &&
            (animator.GetCurrentAnimatorStateInfo(0).IsName("HPTBN_boom")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("LPTBN_boom")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("GEN_boom")
            || animator.GetCurrentAnimatorStateInfo(0).IsName("FWP_boom")))
        {
            animator.SetFloat("speed", 0);
            isReAnimate = false;
        }
        if (animIcon.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 &&
            (animIcon.GetCurrentAnimatorStateInfo(0).IsName("HPTBNIcon")
            || animIcon.GetCurrentAnimatorStateInfo(0).IsName("LPTBNIcon")
            || animIcon.GetCurrentAnimatorStateInfo(0).IsName("GENIcon")
            || animIcon.GetCurrentAnimatorStateInfo(0).IsName("FWPIcon")))
        {
            if (isAnimate)
            {
                animIcon.SetFloat("speed", 0);
                isIconAnim = false;
            }
        }
        if (isIconReAnim && animIcon.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0 &&
            (animIcon.GetCurrentAnimatorStateInfo(0).IsName("HPTBNIcon")
            || animIcon.GetCurrentAnimatorStateInfo(0).IsName("LPTBNIcon")
            || animIcon.GetCurrentAnimatorStateInfo(0).IsName("GENIcon")
            || animIcon.GetCurrentAnimatorStateInfo(0).IsName("FWPIcon")))
        {
            animIcon.SetFloat("speed", 0);
            isIconReAnim = false;
        }
    }

    public void ClickBtnDrag()
    {
        if (statusDrag) { isback = true; }
        else { animator.Rebind(); animIcon.Rebind(); }
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
        animator.SetFloat("speed", 1.0f);
        animIcon.SetBool("isOn", true);
        animIcon.SetFloat("speed", 1.0f);
        isAnimate = true;
        isIconAnim = true;
    }

    public void ClickBtnAsmbl()
    {
        if (statusDrag) { isback = true; }
        else
        {
            isReAnimate = true;
            isIconReAnim = true;
            animator.SetFloat("speed", -1.0f);
            animIcon.SetFloat("speed", -1.0f);
        }
    }

    public void _AmimationReset()
    {
        ClickBtnDrag();
        ClickBtnDrag();
    }
}