using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLookAt : MonoBehaviour
{
    void Update()
    {
        Vector3 targetPosition = new Vector3(GameObject.Find("Main Camera").transform.position.x,
            gameObject.transform.position.y, GameObject.Find("Main Camera").transform.position.z);
        gameObject.transform.LookAt(targetPosition);
    }
}