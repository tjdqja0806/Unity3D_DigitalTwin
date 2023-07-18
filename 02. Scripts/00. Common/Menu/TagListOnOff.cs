using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagListOnOff : MonoBehaviour
{
    public GameObject tagListUI;
    [HideInInspector]
    public bool isOpen = false;

    private void Update()
    {
        tagListUI.SetActive(isOpen);
    }
    public void MenuClick()
    {
        isOpen = !isOpen;
    }
    public void Exit()
    {
        isOpen = false;
    }
}
