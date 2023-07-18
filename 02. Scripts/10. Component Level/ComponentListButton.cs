using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentListButton : MonoBehaviour
{
    public GameObject popupImage;
    private bool isClick;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick) { popupImage.gameObject.SetActive(true); }
        else { popupImage.gameObject.SetActive(false); }
    }
    public void Click() { isClick = true; }
    public void CancelClick() { isClick = false; }
}
