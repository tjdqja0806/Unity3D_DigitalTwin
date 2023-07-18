using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentScreenMode : MonoBehaviour
{
    public GameObject[] camera;
    public CanvasGroup[] canvas;
    public bool isFullScreen = false;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFullScreen)
        {
            camera[0].SetActive(false);
            canvas[0].alpha = 0;
            canvas[0].blocksRaycasts = false;
            camera[1].SetActive(true);
            canvas[1].gameObject.SetActive(true);
        }
        else
        {
            camera[1].SetActive(false);
            canvas[1].gameObject.SetActive(false);
            camera[0].SetActive(true);
            canvas[0].alpha = 1;
            canvas[0].blocksRaycasts = true;
        }
    }

    public void Click()
    {
        isFullScreen = !isFullScreen;
    }
    
}
