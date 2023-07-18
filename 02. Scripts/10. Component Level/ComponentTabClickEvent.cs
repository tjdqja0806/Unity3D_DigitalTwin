using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentTabClickEvent : MonoBehaviour
{
    [Serializable]
    public struct tab
    {
        public Image buttonImage;
        public CanvasGroup lineChartGroup;
        public TextMeshProUGUI text;
        public GameObject scrollChartGroup;
    }
    [SerializeField]
    public tab[] tabButton;
    public Sprite origin;
    public Sprite click;
    public int status;

    private int overStatus = 99;
    private ChartScrollControl[] chartScrollControls = new ChartScrollControl[4];

    void Awake()
    {
        for (int i = 0; i < chartScrollControls.Length; i++) {
            chartScrollControls[i] = tabButton[i].scrollChartGroup.GetComponent<ChartScrollControl>();
        }
    }

    void Update()
    {
        for (int i = 0; i < tabButton.Length; i++)
        {
            if (i == status)
            {
                tabButton[i].buttonImage.sprite = click;
                tabButton[i].lineChartGroup.alpha = 1;
                tabButton[i].lineChartGroup.blocksRaycasts = true;
                //tabButton[i].lineChart1.ChangeData(chartScrollControls[i].ReturnDescription(0), chartScrollControls[i].ReturnSymbolName(0));
                //tabButton[i].lineChart2.ChangeData(chartScrollControls[i].ReturnDescription(1), chartScrollControls[i].ReturnSymbolName(1));
                //tabButton[i].lineChart3.ChangeData(chartScrollControls[i].ReturnDescription(2), chartScrollControls[i].ReturnSymbolName(2));
                //tabButton[i].lineChart4.ChangeData(chartScrollControls[i].ReturnDescription(3), chartScrollControls[i].ReturnSymbolName(3));
                tabButton[i].text.color = Color.white;
                tabButton[i].scrollChartGroup.SetActive(true);

            }
            else if (i == overStatus)
            {
                tabButton[i].buttonImage.sprite = click;
                tabButton[i].text.color = Color.white;
            }
            else
            {
                tabButton[i].buttonImage.sprite = origin;
                tabButton[i].lineChartGroup.alpha = 0;
                tabButton[i].lineChartGroup.blocksRaycasts = false;
                tabButton[i].text.color = Color.gray;
                tabButton[i].scrollChartGroup.SetActive(false);
            }
        }
    }
    public void Click(int num)
    {
        status = num;
    }

    public void MouseOver(int num)
    {
        overStatus = num;
    }
    public void MouseExit()
    {
        overStatus = 99;
    }
}
