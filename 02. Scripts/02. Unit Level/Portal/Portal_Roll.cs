using UnityEngine;

public class Portal_Roll : MonoBehaviour
{
    public float rolling_Speed;

    void Update()
    {
        transform.Rotate(Vector3.down * rolling_Speed * Time.deltaTime, Space.World);
    }
}