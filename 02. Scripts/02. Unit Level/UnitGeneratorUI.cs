using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGeneratorUI : MonoBehaviour
{
    public GameObject generatorUI;

    private bool isClick = false;

    private void Update()
    {
        generatorUI.SetActive(isClick);
    }
    public void Click()
    {
        isClick = !isClick;
    }
}
