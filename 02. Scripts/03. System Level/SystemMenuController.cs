using System;
using UnityEngine;
using UnityEngine.UI;

public class SystemMenuController : MonoBehaviour
{
    [Serializable]
    public struct ItemStruct
    {
        [HideInInspector]
        public bool mainActive;
        public GameObject main;
        public GameObject cg;
        public CanvasGroup info;
        [HideInInspector]
        public bool subActive;
        public GameObject sub;
        public SystemMenuPointer script;
    }
    public ItemStruct[] items;
    [Space]
    public CanvasGroup allInfo;
    [Space]
    public Animator animator;
    [Space]
    public Image button;
    public Sprite menuOff;
    public Sprite menuOn;
    

    [HideInInspector]
    public bool chartActive = false;
    [HideInInspector]
    public int chartIndex = 0;

    private bool isShow = true;

    void Awake()
    {
        chartIndex = 99;
        for (int i = 0; i < items.Length; i++) { items[i].subActive = false; }
        ClickALL();
    }
    private void Update()
    {
        for(int i = 0; i < items.Length; i++){
            if (i == chartIndex)
            {
                items[i].script.PointerEnterChart();
            }
            else
                items[i].script.PointerExitChart();
        }

    }
    public void ClickALL()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].mainActive = true;
            items[i].main.SetActive(true);
            items[i].script.PointerSelectMain();
            allInfo.alpha = 1;
            items[i].info.alpha = 0;
        }
    }

    public void ClickNONE()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].mainActive = false;
            items[i].main.SetActive(false);
            items[i].script.PointerExitMain();
            items[i].cg.SetActive(false);
            chartIndex = 99;
        }
    }

    public void ClickMain(int num)
    {
        items[num].mainActive = !items[num].mainActive;
        items[num].main.SetActive(items[num].mainActive);
        //chartIndex = num;
    }

    public void ClickChart(int num)
    {
        if (chartIndex == num)
        {
            items[num].cg.SetActive(false);
            chartActive = false;
            chartIndex = 99;
        }
        else
        {
            int temp = chartIndex;
            items[num].cg.SetActive(true);
            chartIndex = num;
            if (temp != 99)
            {
                items[temp].cg.SetActive(false);
                items[temp].script.PointerExitChart();
            }
            chartActive = true;
        }
        //items[num].script.PointerExitChart();
        allInfo.alpha = 0;
        for(int i = 0; i < items.Length; i++)
        {
            if(i == num)
            {
                items[num].info.alpha = 1;
            }
            else
            {
                items[i].info.alpha = 0;
            }
        }
    }

    public void ClickSub(int num)
    {
        items[num].subActive = !items[num].subActive;
        items[num].sub.SetActive(items[num].subActive);
    }

    public void ClickShow()
    {
        isShow = !isShow;
        animator.SetBool("Show", isShow);
        //if (isShow) { button.sprite = menuOn; }
        //else { button.sprite = menuOff; }
    }
}