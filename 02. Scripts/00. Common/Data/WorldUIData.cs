using System;
using TMPro;
using UnityEngine;

public class WorldUIData : MonoBehaviour
{
    [Serializable]
    public struct DataStruct
    {
        public TextMeshProUGUI buttonText;
        public GameObject dataGroup;
    }

    public DataStruct[] dataStructs;
    public int InitialStatus = 0;

    private int index = 0;

    void Awake()
    {
        for (int i = 0; i < dataStructs.Length; i++) { dataStructs[i].buttonText.color = Color.gray; }
        _ClickGroup(InitialStatus);
    }

    void Update()
    {
        for (int i = 0; i < dataStructs.Length; i++) { if (i.Equals(index)) { dataStructs[i].buttonText.color = Color.white; } }
    }

    public void _ClickGroup(int num)
    {
        index = num;
        for (int i = 0; i < dataStructs.Length; i++)
        {
            if (i.Equals(num)) { dataStructs[i].dataGroup.SetActive(true); }
            else { dataStructs[i].dataGroup.SetActive(false); }
            dataStructs[i].buttonText.color = Color.gray;
        }
    }

    public void _PointerEnter(int num) { dataStructs[num].buttonText.color = Color.white; }

    public void _PointerExit(int num) { dataStructs[num].buttonText.color = Color.gray; }
}