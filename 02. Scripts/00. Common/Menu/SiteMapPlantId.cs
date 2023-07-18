using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteMapPlantId : MonoBehaviour
{
    private DataAgent dataAgent;

    public int plnatID =3;
    // Start is called before the first frame update
    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Unit(int num)
    {
        plnatID = num;
        if (!dataAgent.isAuto)
            dataAgent.SetPlantID(num, true);
    }
    public void SetPlantID(int num)
    {
        plnatID = num;
        if (!dataAgent.isAuto)
            dataAgent.SetPlantID(num, false);
    }
}
