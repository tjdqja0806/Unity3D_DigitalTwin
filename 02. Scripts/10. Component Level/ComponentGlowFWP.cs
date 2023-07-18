using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentGlowFWP : MonoBehaviour
{
    [Serializable]
    public struct glow
    {
        public Transform drag;
        public Transform[] auto;
    }
    [SerializeField]
    public glow[] glowEquipment;
    public Color color;
    [Space]
    public Image[] buttonImage;
    public Sprite origin;
    public Sprite hover;
    private int status = -1;
    private bool isClick = false;
    private void Update()
    {
        if (status == -1)
        {
            for (int i = 0; i < glowEquipment.Length; i++)
            {
                for(int j = 0; j < glowEquipment[i].auto.Length; j++)
                {
                    SetLayersRecursively(glowEquipment[i].drag, "Default");
                    SetLayersRecursively(glowEquipment[i].auto[j], "Default");
                }
            }
        }
        else
        {
            for (int i = 0; i < glowEquipment.Length; i++)
            {
                if (i != status)
                {
                    for (int j = 0; j < glowEquipment[i].auto.Length; j++)
                    {
                        SetLayersRecursively(glowEquipment[i].drag, "Default");
                        SetLayersRecursively(glowEquipment[i].auto[j], "Default");
                    }
                }
                else
                {
                    for (int j = 0; j < glowEquipment[i].auto.Length; j++)
                    {
                        SetLayersRecursively(glowEquipment[status].drag, "Glow");
                        SetLayersRecursively(glowEquipment[status].auto[j], "Glow");
                    }
                }
            }
        }
        for (int i = 0; i < buttonImage.Length; i++)
        {
            if (i != (status + 1))
                buttonImage[i].sprite = origin;
            else
                buttonImage[status + 1].sprite = hover;
        }
    }
    public void Click(int num)
    {
        status = num - 1;
    }

    private void SetLayersRecursively(Transform trans, string name)
    {
        SetColorRecursively(trans);
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            SetColorRecursively(child);
            SetLayersRecursively(child, name);
        }
    }

    private void SetColorRecursively(Transform trans)
    {
        var rndr = trans.GetComponent<Renderer>();
        if (rndr != null)
        {
            var propertyBlock = new MaterialPropertyBlock();
            rndr.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor("_SelectionColor", color);
            rndr.SetPropertyBlock(propertyBlock);
        }
    }
}
