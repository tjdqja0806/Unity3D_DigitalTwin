using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentMenuController : MonoBehaviour
{
    [Serializable]
    public struct ItemStruct
    {
        [HideInInspector]
        public bool mainActive;
        public GameObject main;
        public GameObject sub;
    }
    public ItemStruct[] items;
    [Space]
    public Animator animator;

    private bool isShow = false;

    void Awake()
    {
        for (int i = 0; i < items.Length; i++) { items[i].mainActive = false; }
    }
    private void Update()
    {

    }

    public void ClickMain(int num)
    {
        items[num].mainActive = !items[num].mainActive;
        items[num].sub.SetActive(items[num].mainActive);
        //chartIndex = num;
    }

    public void ClickShow()
    {
        isShow = !isShow;
        animator.SetBool("Open", isShow);
        //if (isShow) { button.sprite = menuOn; }
        //else { button.sprite = menuOff; }
    }
}
