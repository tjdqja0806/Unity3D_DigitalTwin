using UnityEngine;

public class ComponentDataButton : MonoBehaviour
{
    public GameObject scrollChart;

    public void _ClickOpen() { scrollChart.SetActive(true); }

    public void _ClickClose() { scrollChart.SetActive(false); }
}