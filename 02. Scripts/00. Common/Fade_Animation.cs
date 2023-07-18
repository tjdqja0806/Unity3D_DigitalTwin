using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_Animation : MonoBehaviour
{
    public Image material;
    private bool isClick = false;
    private bool isAnim = true;
    private float timer;
    private float amount = 1f;
    // Start is called before the first frame update
    void Awake()
    {
        material = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        material.material.SetFloat("_FadeAmount", amount);
        if(isClick)
        {
            if (amount > -0.1f)
                amount -= timer;
            else if (amount < -0.1f)
                amount = -0.1f;
        }
        else 
        {
            if(amount < 1f)
                amount += timer;
            else if(amount > 1f)
            {
                amount = 1f;
            }
        }
        
        //Debug.Log(min);

        //Debug.Log(material.material.shader.GetPropertyName(8)); Property 이름 찾기
       
        //material.material.SetFloat("_FadeAmount", 1);
       
            

    }
    public void Click()
    {
        isClick = !isClick;

    }
    //if (isClick)
    //        material.material.SetFloat("_OutlineAlpha", 1);
    //    else
    //        material.material.SetFloat("_OutlineAlpha", 0);
}
