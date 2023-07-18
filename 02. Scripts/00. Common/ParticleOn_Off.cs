using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOn_Off : MonoBehaviour
{
    private ParticleSystem[] particle;
    private bool isChange;
    // Start is called before the first frame update
    void Awake()
    {
        particle = GameObject.FindGameObjectWithTag("Particle").GetComponentsInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChange)
        {
            for(int i = 0; i < particle.Length; i++)
            {
                particle[i].Play();
            }
        }
        else
            for (int i = 0; i < particle.Length; i++)
            {
                particle[i].Stop();
            }
    }

}
