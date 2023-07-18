using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCharactorControl : MonoBehaviour
{
    [HideInInspector]
    public int charactorValue = 0;
    public GameObject[] charactor;
    public Animator[] anim;
    public Sprite characterOn;
    public Sprite characterOff;
    public Image characterOnOff;
    private bool isOnOff = true;

    // Start is called before the first frame update
    void Awake()
    {
        /*
        for(int i = 0; i < charactor.Length; i++)
        {
            if (i != charactorValue)
                charactor[i].SetActive(false);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnOff)
            characterOnOff.sprite = characterOff;
        else
            characterOnOff.sprite = characterOn;
    }

    public void Click()
    {
        if (isOnOff)
        {
            if (charactorValue == 2)
                charactorValue = 0;
            else
                charactorValue++;
            for (int i = 0; i < charactor.Length; i++)
            {
                charactor[i].SetActive(false);
                if (i == charactorValue)
                    charactor[i].SetActive(true);
            }
        }
    }
    public void _ClickOnOffObject()
    {
        isOnOff = !isOnOff;
        charactor[charactorValue].SetActive(isOnOff);
    }
}
