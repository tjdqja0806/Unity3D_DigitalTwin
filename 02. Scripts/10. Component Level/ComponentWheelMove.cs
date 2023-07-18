using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentWheelMove : MonoBehaviour
{
    private float moveSpeed = 30f;
    private float rotateSpeed = 50f;
    public Transform target;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * moveSpeed;

        transform.Translate(Vector3.forward * scroll * Time.deltaTime);
        if (Input.GetMouseButton(2))
        {
            float _x = Input.GetAxis("Mouse X");
            float _y = Input.GetAxis("Mouse Y");

            transform.RotateAround(target.transform.position, Vector3.down, _x * rotateSpeed * Time.deltaTime);
            transform.RotateAround(target.transform.position, Vector3.left, _y * rotateSpeed * Time.deltaTime);
            //transform.Translate(Vector3.left * rotateSpeed * -_x * Time.deltaTime, Space.Self);
            //transform.Translate(Vector3.down * rotateSpeed * -_y * Time.deltaTime, Space.Self);
        }
        transform.LookAt(target);

    }
    private void KeyBoardRotation()
    {
        
        float _x = Input.GetAxis("Mouse X");
        float _y = Input.GetAxis("Mouse Y");

        transform.Translate(Vector3.left * rotateSpeed * -_x * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.down * rotateSpeed * -_y * Time.deltaTime, Space.Self);
        //transform.Rotate(Vector3.down * rotateSpeed * -_x * Time.deltaTime, Space.World);
        //transform.Rotate(Vector3.left * rotateSpeed * _y * Time.deltaTime, Space.Self);
    }
    private void WheelMove()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * moveSpeed;

        transform.Translate(Vector3.forward * scroll * Time.deltaTime);
    }
}
