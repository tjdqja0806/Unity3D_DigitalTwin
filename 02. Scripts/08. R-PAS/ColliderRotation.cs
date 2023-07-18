using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 30.0f);
    }
}