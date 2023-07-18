using UnityEngine;

public class WarningFrameCamera : MonoBehaviour
{
    public GameObject camera;
    public GameObject frame;

    private AlarmControl script;

    void Awake()
    {
        script = GameObject.Find("Menu 2").GetComponent<AlarmControl>();
    }

    void Update()
    {
        camera.SetActive(script.isAlarm);
        frame.SetActive(script.isAlarm);
    }
}