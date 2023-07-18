using UnityEngine;

public class DistanceLookAt : MonoBehaviour
{
    void Update()
    {
        Vector3 targetPosition = new Vector3(GameObject.Find("Tour Camera").transform.position.x,
            gameObject.transform.position.y, GameObject.Find("Tour Camera").transform.position.z);
        gameObject.transform.LookAt(targetPosition);
    }
}