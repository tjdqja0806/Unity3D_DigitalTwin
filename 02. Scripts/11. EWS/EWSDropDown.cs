using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EWSDropDown : MonoBehaviour
{
    public GameObject dropDown;
    private bool active = false;
    public void Click()
    {
        active = !active;
        dropDown.SetActive(active);
    }
}
