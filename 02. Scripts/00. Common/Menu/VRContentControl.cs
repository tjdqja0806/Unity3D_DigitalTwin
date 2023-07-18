using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VRContentControl : MonoBehaviour
{
    public GameObject vrContents;
    [Header("VRRoomButton")]
    [SerializeField] Image[] vrRoomButton;
    [SerializeField] TextMeshProUGUI[] vrRoomText;
    [SerializeField] Sprite[] vrRoomSprite;
    private int vrRoomStatus = 0;
    private int modeStatus = 0;
    private string temp;

    private VRConnect vRConnect;
    private bool isOnOff;

    // Start is called before the first frame update
    void Awake()
    {
        vRConnect = GameObject.Find("VRConnect").GetComponent<VRConnect>();
    }

    // Update is called once per frame
    void Update()
    {
        vrContents.SetActive(isOnOff);
        for(int i = 0; i < vrRoomButton.Length; i++)
        {
            if (i == vrRoomStatus)
            {
                vrRoomButton[i].sprite = vrRoomSprite[0];
                vrRoomText[i].color = Color.black;
            }
        }
    }

    public void VRRoomButtonClick(int num)
    {
        vrRoomStatus = num;
        for(int i = 0; i < vrRoomButton.Length; i++)
        {
            if (i != vrRoomStatus)
            {
                vrRoomButton[i].sprite = vrRoomSprite[1];
                vrRoomText[i].color = Color.white;
            }
        }
    }

    public void VRButton(string name)
    {
        ConetentOff();
        vRConnect.VRServerConnect(vrRoomStatus, name);
    }
    public void ConetentOnOff() { isOnOff = !isOnOff; }
    public void ConetentOff() { isOnOff = false; }
}
