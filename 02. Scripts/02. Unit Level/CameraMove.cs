using SpaceNavigatorDriver;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float moveSpeed3D = 5f;
    private float rotationSpeed3D = 50f;
    private float areaLimited = 0.35f;

    private float moveSpeed = 1f;
    private float rotateSpeed = 70f;

    private float _x;
    private float _y;

    void Awake()
    { 
    }

    void Update()
    {
        Move();
        Rotation();
        KeybordMove();
        if (Input.GetMouseButton(2))
            MouseRotation();
        //AreaLimitation();
    }

    private void Move()
    {
        transform.Translate(SpaceNavigator.Translation * moveSpeed3D * Time.deltaTime, Space.Self);
    }

    private void Rotation()
    {
        transform.Rotate(Vector3.up, SpaceNavigator.Rotation.Yaw() * Mathf.Rad2Deg * rotationSpeed3D * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * rotationSpeed3D * Time.deltaTime, Space.Self);
    }

    private void AreaLimitation()
    {
        if (transform.position.y < areaLimited && SpaceNavigator.Translation.y < 0)
        {
            moveSpeed = 0;
        }
        else if (moveSpeed == 0 && SpaceNavigator.Translation.y > 0)
        {
            moveSpeed = moveSpeed3D;
        }
    }
    private void KeybordMove()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.E))
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.Self);
    }
    private void MouseRotation()
    {
        _x = Input.GetAxis("Mouse X");
        _y = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.down * rotateSpeed * -_x * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.left * rotateSpeed * _y * Time.deltaTime, Space.Self);
    }
}