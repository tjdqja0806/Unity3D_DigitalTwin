using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area_Change : MonoBehaviour
{
    public Sprite orange;
    public Sprite blue;

    public Image area;
    public Image icon;

    public Transform camera;

    private bool isChange;
    // Start is called before the first frame update
    void Awake()
    {
    }
    private void OnEnable()
    {
        isChange = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isChange)
            area.sprite = blue;
        else
            area.sprite = orange;

        icon.transform.LookAt(camera);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Character")
        {
            isChange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Character")
        {
            isChange = false;
        }
    }
}
