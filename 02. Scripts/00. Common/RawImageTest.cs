using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawImageTest : MonoBehaviour
{
    public GameObject[] rawImage;

    public int status;
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
        for(int i = 0; i < rawImage.Length; i++)
        {
            if (num == i)
                rawImage[i].SetActive(true);
            else
                rawImage[i].SetActive(false);
        }
    }
}
