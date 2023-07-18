using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentParticleOn_Off : MonoBehaviour
{
    private GameObject[] particleObj;
    private ParticleSystem[] particle;
    private ComponentXrayMaterial script;
    void Awake()
    {
        script = GameObject.Find("EventSystem").GetComponent<ComponentXrayMaterial>();
        particleObj = GameObject.FindGameObjectsWithTag("Particle");
        particle = new ParticleSystem[particleObj.Length];
        for (int i = 0; i < particleObj.Length; i++)
        {
            particle[i] = particleObj[i].GetComponent<ParticleSystem>();
        }
    }
    void Update()
    {
        if (script.isChange)
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
