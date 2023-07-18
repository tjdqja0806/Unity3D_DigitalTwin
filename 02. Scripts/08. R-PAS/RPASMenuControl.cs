using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RPASMenuControl : MonoBehaviour
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
        public GameObject ui;
        public GameObject ui2D;
    }
    public PointStruct[] pointStruct;

    private float dist;
    private bool isMove = false;
    private int indexMain = 0;
    private int indexSub = 0;
    private Color grayColor = new Color(0.5f, 0.5f, 0.5f, 1);


    private void Start()
    {
    }
    void Update()
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

    public void _ClickPoint(string text)
    {
        indexMain = int.Parse(text.Split(char.Parse("-"))[0]);
        indexSub = int.Parse(text.Split(char.Parse("-"))[1]);
        isMove = true;
        for (int i = 0; i < pointStruct.Length; i++)
        {
            for (int j = 0; j < pointStruct[i].objects.Length; j++)
            {
                if (i == indexMain && j == indexSub)
                {
                    pointStruct[i].objects[j].ui.SetActive(true);
                    pointStruct[i].objects[j].ui2D.SetActive(true);
                }
                else
                {
                    pointStruct[i].objects[j].ui.SetActive(false);
                    pointStruct[i].objects[j].ui2D.SetActive(false);
                }
            }
        }
    }

}