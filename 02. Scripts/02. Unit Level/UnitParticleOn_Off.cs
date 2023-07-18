using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitParticleOn_Off : MonoBehaviour
{
    private GameObject[] particleObj;
    private ParticleSystem[] particle;
    private XRayControl script;
    // Start is called before the first frame update
    void Awake()
    {
        script = GameObject.Find("Menu 2").GetComponent<XRayControl>();
        particleObj = GameObject.FindGameObjectsWithTag("Particle");
        particle = new ParticleSystem[particleObj.Length];
        for (int i = 0; i < particleObj.Length; i++)
        {
            particle[i] = particleObj[i].GetComponent<ParticleSystem>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (script.isXRay)
        {
            for (int i = 0; i < particle.Length; i++)
            {
                particle[i].Play();
            }
        }
        else
        {
            for (int i = 0; i < particle.Length; i++)
            {
                particle[i].Stop();
            }
        }

    }
}
