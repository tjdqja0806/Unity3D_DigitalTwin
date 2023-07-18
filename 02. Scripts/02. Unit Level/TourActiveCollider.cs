using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourActiveCollider : MonoBehaviour
{

    [Serializable]
    public struct CollisionObject
    {
        public GameObject[] Object;
        //public string name;
    }
    [SerializeField]
    public CollisionObject collisionObject;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Collision Check")
        {
            for(int i = 0; i < collisionObject.Object.Length; i++)
            {
                collisionObject.Object[i].gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Collision Check")
        {
            for (int i = 0; i < collisionObject.Object.Length; i++)
            {
                collisionObject.Object[i].gameObject.SetActive(true);
            }
        }
    }
}
