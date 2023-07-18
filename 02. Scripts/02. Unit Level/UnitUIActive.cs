using UnityEngine;

public class UnitUIActive : MonoBehaviour
{
    public Animator animator;
    public Animator animator2;

    private UnitLevelControl script;

    private AlarmControl alarmControl;

    void Awake()
    {
        script = GameObject.Find("EventSystem").GetComponent<UnitLevelControl>();
        alarmControl = GameObject.Find("Menu 2").GetComponent<AlarmControl>();
    }

    void Update()
    {
        if (alarmControl.isAlarm)
        {
            script.isUIActive = true;
            animator.SetBool("Active", true);
            animator2.SetBool("Active", true);
        }
        else
        {
            animator.SetBool("Active", script.isUIActive);
            animator2.SetBool("Active", script.isUIActive); 
        }
    }
}