using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoachmarkingChange : MonoBehaviour
{
    public GameObject[] coachmarking;
    public int status;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < coachmarking.Length; i++)
        {
            if (i == status)
                coachmarking[i].SetActive(true);
            else
                coachmarking[i].SetActive(false);
        }
    }

    public void RightClick()
    {
        status++;
        if (status > coachmarking.Length - 1)
            status = 0;
    }
    public void LeftClick()
    {
        status--;
        if (status < 0)
            status = coachmarking.Length - 1;
    }
}
