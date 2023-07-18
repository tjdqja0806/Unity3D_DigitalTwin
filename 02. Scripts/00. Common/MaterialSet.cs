using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialSet : MonoBehaviour
{
    public Image material;
    private bool isClick = false;
    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(material.material.shader.GetPropertyName(15));
    }
    public void Click()
    {
        isClick = !isClick;
        if(isClick)
            material.material.SetFloat("_OutlineAlpha", 1);
        else
            material.material.SetFloat("_OutlineAlpha", 0);
    }

}
