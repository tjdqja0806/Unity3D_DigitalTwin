using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Visible()
    {
        anim.SetBool("Visible", true);
    }
    public void Invisible()
    {
        anim.SetBool("Visible", false);
    }
}
