using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUpDown : MonoBehaviour
{
    public Animator menuAnim;
    public GameObject collisionArea;
    public GameObject arrowButton;

    private SettingScript settingScript;
    private bool isDown = false;
    // Start is called before the first frame update
    void Awake()
    {
        settingScript = GetComponentInChildren<SettingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //ImageSwap();
    }
    public void MouseOver()
    {
        menuAnim.SetBool("Down", true);
        collisionArea.SetActive(false);
        isDown = true;
        ImageSwap();
    }
    public void MouseExit()
    {
        menuAnim.SetBool("Down", false);
        Invoke("After", 1f);
        if (settingScript.isSetting)
        {
            settingScript.isSetting = false;
        }
        isDown = false;
        ImageSwap();
    }
    
    public void ImageSwap()
    {
        if (isDown)
        {
            arrowButton.transform.eulerAngles = new Vector3(arrowButton.transform.rotation.x, arrowButton.transform.rotation.y, -90f);
        }
        else
        {
            arrowButton.transform.eulerAngles = new Vector3(arrowButton.transform.rotation.x, arrowButton.transform.rotation.y, 90f);
        }
    }
    private void After()
    {
        collisionArea.SetActive(true);
    }
}
