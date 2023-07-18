using Michsky.UI.Hexart;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantColliderScene : MonoBehaviour
{
    [Serializable]
    public struct PlantStruct
    {
        public Transform ab;
        public Transform rcb;
        public Transform tgb;
    }
    public PlantStruct[] plantStructs;
    public Color colorPlant;
    public Color colorSK3;
    public Color colorSK4;

    //private HUDManager hUDManager;
    private string plantName;

    /*void Awake()
    {
        hUDManager = GameObject.Find("HUD Manager").GetComponent<HUDManager>();
    }*/

    /*void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.transform.gameObject.name != null) { plantName = hit.transform.gameObject.name; }

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider != null)
                {
                    switch (plantName)
                    {
                        case "SK3_Collider":
                            //AutoFade.LoadLevel("02. Unit3", 0.5f, 0.5f, Color.black);
                            LodingBarScript.LoadScene("02. Unit3");
                            break;

                        case "SK4_Collider":
                            LodingBarScript.LoadScene("02. Unit4");
                            //AutoFade.LoadLevel("02. Unit4", 0.5f, 0.5f, Color.black);
                            break;
                    }
                }
            }

            switch (plantName)
            {
                case "SK3_Collider":
                    SetLayersRecursively(plantStructs[0].ab, colorPlant, "Glow");
                    SetLayersRecursively(plantStructs[0].rcb, colorPlant, "Glow");
                    SetLayersRecursively(plantStructs[0].tgb, colorPlant, "Glow");
                    SetLayersRecursively(plantStructs[1].ab, Color.white, "Default");
                    SetLayersRecursively(plantStructs[1].rcb, Color.white, "Default");
                    SetLayersRecursively(plantStructs[1].tgb, Color.white, "Default");
                    break;

                case "SK4_Collider":
                    SetLayersRecursively(plantStructs[0].ab, Color.white, "Default");
                    SetLayersRecursively(plantStructs[0].rcb, Color.white, "Default");
                    SetLayersRecursively(plantStructs[0].tgb, Color.white, "Default");
                    SetLayersRecursively(plantStructs[1].ab, colorPlant, "Glow");
                    SetLayersRecursively(plantStructs[1].rcb, colorPlant, "Glow");
                    SetLayersRecursively(plantStructs[1].tgb, colorPlant, "Glow");
                    break;

                default:
                    PointerExit();
                    break;
            }
        }
    }*/

    public void PointerEnter(string name)
    {
        switch (name)
        {
            case "SK3 Primary":
                SetLayersRecursively(plantStructs[0].ab, Color.white, "Default");
                SetLayersRecursively(plantStructs[0].rcb, colorSK3, "Glow");
                SetLayersRecursively(plantStructs[0].tgb, Color.white, "Default");
                SetLayersRecursively(plantStructs[1].ab, Color.white, "Default");
                SetLayersRecursively(plantStructs[1].rcb, Color.white, "Default");
                SetLayersRecursively(plantStructs[1].tgb, Color.white, "Default");
                break;

            case "SK3 Secondary":
                SetLayersRecursively(plantStructs[0].ab, Color.white, "Default");
                SetLayersRecursively(plantStructs[0].rcb, Color.white, "Default");
                SetLayersRecursively(plantStructs[0].tgb, colorSK3, "Glow");
                SetLayersRecursively(plantStructs[1].ab, Color.white, "Default");
                SetLayersRecursively(plantStructs[1].rcb, Color.white, "Default");
                SetLayersRecursively(plantStructs[1].tgb, Color.white, "Default");
                break;

            case "SK4 Primary":
                SetLayersRecursively(plantStructs[0].ab, Color.white, "Default");
                SetLayersRecursively(plantStructs[0].rcb, Color.white, "Default");
                SetLayersRecursively(plantStructs[0].tgb, Color.white, "Default");
                SetLayersRecursively(plantStructs[1].ab, Color.white, "Default");
                SetLayersRecursively(plantStructs[1].rcb, colorSK4, "Glow");
                SetLayersRecursively(plantStructs[1].tgb, Color.white, "Default");
                break;

            case "SK4 Secondary":
                SetLayersRecursively(plantStructs[0].ab, Color.white, "Default");
                SetLayersRecursively(plantStructs[0].rcb, Color.white, "Default");
                SetLayersRecursively(plantStructs[0].tgb, Color.white, "Default");
                SetLayersRecursively(plantStructs[1].ab, Color.white, "Default");
                SetLayersRecursively(plantStructs[1].rcb, Color.white, "Default");
                SetLayersRecursively(plantStructs[1].tgb, colorSK4, "Glow");
                break;
        }
    }

    public void PointerExit()
    {
        for (int i = 0; i < plantStructs.Length; i++)
        {
            SetLayersRecursively(plantStructs[i].ab, Color.white, "Default");
            SetLayersRecursively(plantStructs[i].rcb, Color.white, "Default");
            SetLayersRecursively(plantStructs[i].tgb, Color.white, "Default");
        }
    }

    public void _ClickUI(int unit) {
        switch (unit) {
            case 3:
                LodingBarScript.LoadScene("02. Unit3");
                break;
            case 4:
                LodingBarScript.LoadScene("02. Unit4");
                break;
        }
    }

    private void SetLayersRecursively(Transform trans, Color color, string name)
    {
        SetColorRecursively(trans, color);
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans)
        {
            SetColorRecursively(child, color);
            SetLayersRecursively(child, color, name);
        }
    }

    private void SetColorRecursively(Transform trans, Color color)
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