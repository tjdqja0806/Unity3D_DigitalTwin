using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerStatusUIOnOffScript : MonoBehaviour
{
    public GameObject serverUI;
    public int serverStatus = 99;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void _TitleClick(int num)
    {
        if (serverStatus != num)
        {
            serverStatus = num;
            if (!serverUI.activeSelf)
            {
                serverUI.SetActive(true);
            }
            serverUI.GetComponent<ServerStatusScript>()._DataInit();
        }
        else
        {
            serverUI.SetActive(false);
            serverStatus = 99;
        }
    }
    public void _ExitClick()
    {
        serverUI.SetActive(false);
    }
}
