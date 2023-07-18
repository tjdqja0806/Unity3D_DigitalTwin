using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DateTimeScript : MonoBehaviour
{
    public TextMeshProUGUI date; 
    public TextMeshProUGUI time;
    
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        date.text = DateTime.Now.ToString("yyyy-MM-dd");
        time.text = DateTime.Now.ToString("HH:mm:ss");
    }
}
