using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find : MonoBehaviour
{
    private string name;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        name = GameObject.FindGameObjectWithTag("XrayUnit").name;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(name);
    }
}
