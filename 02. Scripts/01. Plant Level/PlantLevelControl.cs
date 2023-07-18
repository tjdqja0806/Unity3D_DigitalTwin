using UnityEngine;

public class PlantLevelControl : MonoBehaviour
{
    // 0 : 운전
    // 1 : 정지
    // 2 : 알람
    [HideInInspector]
    public int status3rdPri = 0;
    [HideInInspector]
    public int status3rdSec = 0;
    [HideInInspector]
    public int status4thPri = 0;
    [HideInInspector]
    public int status4thSec = 0;
    [HideInInspector]
    public bool isUIActive = true;
    [HideInInspector]
    //public bool isXrayActive = false;

    private AlarmControl script;

    void Awake()
    {
        script = GameObject.Find("Menu 2").GetComponent<AlarmControl>();
    }

    void Update()
    {
        // 알람 발생 시나리오 : 3호기 2차측 LP 터빈 A 축 문제 발생
        // 결론 : 클릭 시 3호기 2차측 알람상태로 변경
        if (script.isAlarm) { isUIActive = true; }
        //else { status3rdSec = 0; }
    }

    // 발전소 상태 시나리오 : 4호기 운전 -> 정지 상태로 변경
    // 결론 : 클릭 시 다음 상태(Status)로 변경
    public void ChangePlantStatus()
    {
        status4thPri++;
        if (status4thPri > 1) { status4thPri = 0; }
        status4thSec++;
        if (status4thSec > 1) { status4thSec = 0; }
    }

    // 클릭 시 UI On/Off 및 슬라이더 표현
    public void ChangeUIActive() { isUIActive = !isUIActive; }

    // 클릭 시 X-Ray 상태 <-> 정상 상태
    //public void ChangeXrayActive() { isXrayActive = !isXrayActive; }
    
    private void ModelClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.name == "SU1")
            {

            }
        }
    }
}