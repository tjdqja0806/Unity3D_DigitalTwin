using UnityEngine;

public class AlarmControl : MonoBehaviour
{
    [HideInInspector]
    public bool isAlarm = false;

    public void ChangeAlarmStatus() { isAlarm = !isAlarm; }
}