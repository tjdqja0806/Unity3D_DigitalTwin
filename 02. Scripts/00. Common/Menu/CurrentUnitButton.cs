using TMPro;
using UnityEngine;

public class CurrentUnitButton : MonoBehaviour
{
    public TextMeshProUGUI currentUnit;
    public TextMeshProUGUI unitChangeButtonText;
    public TextMeshProUGUI siteMapCurrentUnit;

    public int plnatID = 3;

    private DataAgent dataAgent;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    private void OnEnable()
    {
    }

    void Update()
    {
        if (PlayerPrefs.GetString("PlantID").Equals("SKR3"))
        {
            currentUnit.text = "3호기";
            unitChangeButtonText.text = "4호기";
        }
        else if (PlayerPrefs.GetString("PlantID").Equals("SKR4"))
        {
            currentUnit.text = "4호기";
            unitChangeButtonText.text = "3호기";
        }
        siteMapCurrentUnit.text = currentUnit.text;
    }

    public void UnitButtonClick()
    {
        if(currentUnit.text == "3호기")
            dataAgent.SetPlantID(4, true);
        else if(currentUnit.text == "4호기")
            dataAgent.SetPlantID(3, true);

    }

    public void SetPlantID(int num)
    {
        plnatID = num;
        if (!dataAgent.isAuto)
            dataAgent.SetPlantID(num, false);
    }
}