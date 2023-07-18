using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RPASSimulationMenuControl : MonoBehaviour
{
    [Serializable]
    public struct PointStruct
    {
        public ObjectStruct[] objects;
    }
    [Serializable]
    public struct ObjectStruct
    {
        public GameObject position;
        public GameObject ui2D;
    }
    public PointStruct[] pointStruct;
    [Space]
    public GameObject[] subGroup;
    [Space]
    public Animator rightUIAnim;
    //public GameObject rightUIImage;
    public Image buttonImage;
    public Sprite buttonOrigin;
    public Sprite buttonClick;

    private float dist;
    private bool isMove = false;
    private int indexMain = 0;
    private int indexSub = 0;
    private bool isAnim = true;

    private RPASSimulationResultControl script;
    private void Awake()
    {
        script = GetComponent<RPASSimulationResultControl>();
    }
    void Start()
    {
        rightUIAnim.SetBool("On", true);
        _ClickPoint("0-0");
    }
    void Update()
    {
        if (!script.isResult)
        {
            dist = Vector3.Distance(Camera.main.transform.position, pointStruct[indexMain].objects[indexSub].position.transform.position);
            if (isMove)
            {
                Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, pointStruct[indexMain].objects[indexSub].position.transform.position, 0.05f);
                Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, pointStruct[indexMain].objects[indexSub].position.transform.rotation, 0.05f);
                if (dist < 0.001f)
                {
                    isMove = false;
                }
            }
        }

        //if (indexMain == 2 && indexSub == 1)
        //    rightUIImage.SetActive(true);
        //else
        //    rightUIImage.SetActive(false);
    }

    public void _ClickPoint(string text)
    {
        indexMain = int.Parse(text.Split(char.Parse("-"))[0]);
        indexSub = int.Parse(text.Split(char.Parse("-"))[1]);
        isMove = true;
        if (indexMain == 0 && indexSub == 0)
        {
            rightUIAnim.SetBool("On", true);
            isAnim = true;
        }
        else
        {
            rightUIAnim.SetBool("On", false);
            isAnim = false;
        }
        for (int i = 0; i < pointStruct.Length; i++)
        {
            for (int j = 0; j < pointStruct[i].objects.Length; j++)
            {
                if (i == indexMain && j == indexSub)
                {
                    pointStruct[i].objects[j].ui2D.SetActive(true);
                }
                else
                {
                    pointStruct[i].objects[j].ui2D.SetActive(false);
                }
            }
        }
    }

    public void _EnterGroup(int num) { subGroup[num].SetActive(true); }
    public void _ExitGroup(int num) { subGroup[num].SetActive(false); }

    public void _AnimClick()
    {
        isAnim = !isAnim;
        rightUIAnim.SetBool("On", isAnim);
        if (!isAnim)
            buttonImage.sprite = buttonOrigin;
        else
            buttonImage.sprite = buttonClick;
    }
}
