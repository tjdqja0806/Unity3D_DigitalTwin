using System;
using UnityEngine;

public class SystemClose_Up : MonoBehaviour
{
    [Serializable]
    public struct ItemStruct
    {
        public GameObject obj;
        public float distance;
    }
    public ItemStruct[] items;
    [Space]
    public GameObject camera;
    [Space]
    public Transform defalutPos;

    private int status;
    private float speed;
    private float dist;
    private SystemCameraMove systemCameraMove;

    void Awake()
    {
        systemCameraMove = GameObject.Find("Main Camera").GetComponent<SystemCameraMove>();
    }

    void Update()
    {
        dist = Vector3.Distance(items[status].obj.transform.position, camera.transform.position);
        if (dist > items[status].distance)
        {
            camera.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        }
        else
        {
            speed = 0;
            systemCameraMove.isCloseUp = false;
        }
    }

    public void Click(int num)
    {
        systemCameraMove.isCloseUp = true;
        status = num;
        camera.transform.position = defalutPos.position;
        speed = 1f;
        camera.transform.LookAt(items[num].obj.transform);
    }
}