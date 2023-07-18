using UnityEngine;

public class AlarmMaterialColor : MonoBehaviour
{
    private Renderer renderer;
    private AlarmControl script;
    private bool changeColor = false;
    private float timer = 0.0f;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
        script = GameObject.Find("Menu 2").GetComponent<AlarmControl>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0.5f;
            changeColor = !changeColor;
        }

        if (script.isAlarm)
        {
            if (changeColor) { renderer.material.SetColor("_BaseColor", Color.red); }
            else { renderer.material.SetColor("_BaseColor", Color.white); }
        }
        else { renderer.material.SetColor("_BaseColor", Color.white); }
    }
}