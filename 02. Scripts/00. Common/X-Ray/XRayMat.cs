using UnityEngine;

public class XRayMat : MonoBehaviour
{
    public Material origin;
    public Material change;
    [HideInInspector]
    public bool isAlarm = false;

    private Renderer renderer;
    private XRayControl script;
    private Color originColor;
    private Color changeColor;
    private float timer = 0.0f;
    private bool isColor = false;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        script = GameObject.Find("Menu 2").GetComponent<XRayControl>();
        originColor = origin.GetColor("_BaseColor");
        if (change.name.Contains("Ghost"))
        {
            if (change.HasProperty("_FresnelColor"))
            {
                changeColor = change.GetColor("_FresnelColor");
            }

        }
        else
        {
            if (change.HasProperty("_BaseColor"))
            {
                changeColor = change.GetColor("_BaseColor");
            }
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0.5f;

            if (isAlarm) { isColor = !isColor; }
            else { isColor = false; }

            if (isColor)
            {
                if (renderer.material.name.Contains("Ghost")) { renderer.material.SetColor("_FresnelColor", Color.red); }
                else { renderer.material.SetColor("_BaseColor", Color.red); }
            }
            else
            {
                if (renderer.material.name.Contains("Ghost")) { renderer.material.SetColor("_FresnelColor", changeColor); }
                else { renderer.material.SetColor("_BaseColor", originColor); }
            }
        }
    }

    public void ChangeMaterial()
    {
        if (script.isXRay) { renderer.material = change; }
        else { renderer.material = origin; }
    }
}