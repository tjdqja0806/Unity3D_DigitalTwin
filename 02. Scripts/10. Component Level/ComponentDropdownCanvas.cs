using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentDropdownCanvas : MonoBehaviour
{
    public CanvasGroup[] windowCanvas;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(int num)
    {
        windowCanvas[num].alpha = 1;
    }
}
