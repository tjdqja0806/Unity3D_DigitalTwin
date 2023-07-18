using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassLoding : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Invoke("Alpha", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Alpha()
    {
        canvasGroup.alpha = 1;
    }
}
