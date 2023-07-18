using UnityEngine;

public class PlantUIActive : MonoBehaviour
{
    public Animator animator;

    private PlantLevelControl script;
    private AlarmControl alarmControl;
    void Awake()
    {
        script = GameObject.Find("EventSystem").GetComponent<PlantLevelControl>();
        alarmControl = GameObject.Find("Menu 2").GetComponent<AlarmControl>();

    }

    void Update()
    {
        if (alarmControl.isAlarm)
        {
            script.isUIActive = true;
            animator.SetBool("Active", true);
        }
        else
        {
            animator.SetBool("Active", script.isUIActive);
        }
    }
}