using UnityEngine;

public class DetailInfoControl : MonoBehaviour
{
    [HideInInspector]
    public string nameString;
    [HideInInspector]
    public bool isActive = false;

    //public CanvasGroup canvas;
    //public GameObject temp;

    private PositionCheck script;

    void Awake()
    {
        script = GameObject.Find("Position Check").GetComponent<PositionCheck>();
        ClickDetail();
    }

    void Update()
    {
        nameString = script.nameString;
        //if ((nameString == "LPTBN_A" || nameString == "LPTBN_B" || nameString == "LPTBN_C" || nameString == "HP_TBN") && isActive)
        //{
        //    canvas.alpha = 1;
        //}
        //else
        //    canvas.alpha = 0;
        //if (nameString == "MSR_A")
        //    temp.SetActive(true);
        //else
        //    temp.SetActive(false);
    }

    public void ClickDetail()
    {
        isActive = !isActive;
    }
}