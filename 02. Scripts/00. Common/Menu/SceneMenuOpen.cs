using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMenuOpen : MonoBehaviour
{
    public GameObject sceneMenu;
    [HideInInspector]
    public bool isOpen;

    private DataAgent dataAgent;
    // Start is called before the first frame update
    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        sceneMenu.SetActive(isOpen);
    }

    //씬 이동 키를 눌렀을 때 SceneMenu를 SetActive(false)시키는 함수
    public void Click()
    {
        isOpen = !isOpen;
    }

    public void _OpenWareHouse()
    {
        dataAgent.ClickWareHouse();
    }
}
