using UnityEngine;

public class MenuItemLookAt : MonoBehaviour
{
    static Vector3 lookAtZ = new Vector3(0, 0, 1);

    void Update()
    {
        transform.LookAt(transform.position + lookAtZ);
    }
}