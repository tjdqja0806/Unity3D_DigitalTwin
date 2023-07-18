using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchScene : MonoBehaviour
{
    public TMP_InputField inputField;
    public SearchColorChange[] scripts;
    [HideInInspector]
    public bool isSearch = false;

    void Awake()
    {

    }

    void Update()
    {
        if (!inputField.text.Equals(""))
        {
            isSearch = true;
            for (int i = 0; i < scripts.Length; i++)
            {
                if (scripts[i].gameObject.name.Contains(inputField.text))
                {
                    scripts[i].isSelect = true;
                }
                else { scripts[i].isSelect = false; }
            }
        }
        else { isSearch = false; }
    }
}
