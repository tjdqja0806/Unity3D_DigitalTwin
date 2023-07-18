using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDiagram : MonoBehaviour
{
    public Material waterMaterial;
    private float isBlendin_Branch = 0f;
    private bool isUp = false;
    private float blendingFloat = 0f;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(blendingFloat <= 0f && isBlendin_Branch == 0f)
        {
            isUp = true;
        }
        else if(blendingFloat >= 1f && isBlendin_Branch == 1f)
        {
            isUp = false;
        }

        if (isUp)
        {
            blendingFloat += 0.01f;
        }
        else
        {
            blendingFloat -= 0.01f;
        }

        if(blendingFloat >= 1f && isUp && isBlendin_Branch == 0)
        {
            isBlendin_Branch = 1f;
            blendingFloat = 0f;
        }
        else if(blendingFloat <= 0f && !isUp && isBlendin_Branch == 1)
        {
            isBlendin_Branch = 0f;
            blendingFloat = 1f;
        }
        waterMaterial.SetFloat("Blending", blendingFloat);
        waterMaterial.SetFloat("Blending_Branch", isBlendin_Branch);
    }
}
