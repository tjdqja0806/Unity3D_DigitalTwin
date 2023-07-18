using UnityEngine;
using UnityEngine.UI;

public class CameraworkingSpaceNavigatorVDI : MonoBehaviour
{
    private float speed;
    private float angularVelocity;
    public bool HorizonLock = true;
    public Camera unitCamera;
    public GameObject tourCamera;

    public Image pointerImage;
    public Sprite originPointer;
    public Sprite[] pointer;

    public Image rotaterImage;
    public Sprite originRotater;
    public Sprite[] rotater;

    private UnitLevelControl unit;

    private TourCameraMove tourCameraMove;
    [HideInInspector]
    public bool left = false;
    [HideInInspector]
    public bool right = false;
    private Vector3 lrTranslation = new Vector3(0, 0, 0);
    [HideInInspector]
    public bool forward = false;
    [HideInInspector]
    public bool reverse = false;
    private bool up = false;
    private bool down = false;
    private Vector3 frTranslation = new Vector3(0, 0, 0);
    private Vector3 udTranslation = new Vector3(0, 0, 0);
    [HideInInspector]
    public bool leftRotate = false;
    [HideInInspector]
    public bool rightRotate = false;
    private bool forwardRotate = false;
    private bool reverseRotate = false;

    void Awake()
    {
        unit = GameObject.Find("EventSystem").GetComponent<UnitLevelControl>();
        tourCameraMove = GameObject.Find("Character").GetComponent<TourCameraMove>();
    }

    void Update()
    {
        Check();
        PointerImage();
        RotaterImage();
        Move();
        Rotate();

        if (calculateRange(transform.localEulerAngles.x))
        {
            transform.Rotate(Vector3.up, transform.localEulerAngles.y * Mathf.Rad2Deg * 10, Space.Self);
        }
        else
        {
            if (transform.rotation.x >= 30)
            {
                ForwardRotatePointer(false);

            }
            else if (transform.rotation.x <= -30)
            {
                ReverseRotatePointer(false);
            }
        }
        if (!unit.isTourActive) { speed = 30f; angularVelocity = 10f; }
        else { speed = 2f; angularVelocity = 10f; }
    }

    private void Check()
    {
        if (left) { lrTranslation = new Vector3(-0.01f, 0.00f, 0.00f); }
        else if (right) { lrTranslation = new Vector3(0.01f, 0.00f, 0.00f); }
        else { lrTranslation = new Vector3(0, 0, 0); }

        if (forward) { frTranslation = new Vector3(0.0f, 0.0f, 0.01f); }
        else if (reverse) { frTranslation = new Vector3(0.0f, 0.0f, -0.01f); }
        else { frTranslation = new Vector3(0, 0, 0); }

        if (up) { udTranslation = new Vector3(0.0f, 0.01f, 0.0f); }
        else if (down) { udTranslation = new Vector3(0.0f, -0.01f, 0.0f); }
        else { udTranslation = new Vector3(0.0f, 0.0f, 0.0f); }
    }
    private void PointerImage()
    {
        if (left)
            pointerImage.sprite = pointer[0];
        else if (forward)
            pointerImage.sprite = pointer[1];
        else if (right)
            pointerImage.sprite = pointer[2];
        else if (reverse)
            pointerImage.sprite = pointer[3];
        else
            pointerImage.sprite = originPointer;
    }
    private void RotaterImage()
    {
        if (leftRotate)
            rotaterImage.sprite = rotater[0];
        else if (forwardRotate)
            rotaterImage.sprite = rotater[1];
        else if (rightRotate)
            rotaterImage.sprite = rotater[2];
        else if (reverseRotate)
            rotaterImage.sprite = rotater[3];
        else
            rotaterImage.sprite = originRotater;
    }

    private void Move()
    {
        if (!unit.isTourActive)
        {
            unitCamera.transform.Translate(lrTranslation * speed * Time.deltaTime, Space.Self);
            unitCamera.transform.Translate(frTranslation * speed * Time.deltaTime, Space.Self);
            unitCamera.transform.Translate(udTranslation * speed * Time.deltaTime, Space.Self);
        }
        else
        {
            tourCamera.transform.Translate(lrTranslation * speed * Time.deltaTime, Space.Self);
            tourCamera.transform.Translate(frTranslation * speed * Time.deltaTime, Space.Self);
            tourCamera.transform.Translate(udTranslation * speed * Time.deltaTime, Space.Self);

            switch (tourCameraMove.status)
            {
                case 0:
                    transform.position = new Vector3(transform.position.x, 0.225f, transform.position.z);
                    break;
                case 1:
                    transform.position = new Vector3(transform.position.x, 0.305f, transform.position.z);
                    break;
                case 2:
                    transform.position = new Vector3(transform.position.x, 0.42f, transform.position.z);
                    break;
                case 3:
                    transform.position = new Vector3(transform.position.x, 0.53f, transform.position.z);
                    break;
            }
        }
    }

    private void Rotate()
    {
        if (leftRotate)
        {
            if (!unit.isTourActive)
            {
                unitCamera.transform.Rotate(Vector3.up, 1.0f * angularVelocity * Time.deltaTime, Space.World);
            }
            else
            {
                tourCamera.transform.Rotate(Vector3.up, 1.0f * angularVelocity * Time.deltaTime, Space.World);
            }

        }
        else if (rightRotate)
        {
            if (!unit.isTourActive)
                unitCamera.transform.Rotate(Vector3.up, -1.0f * angularVelocity * Time.deltaTime, Space.World);
            else
                tourCamera.transform.Rotate(Vector3.up, -1.0f * angularVelocity * Time.deltaTime, Space.World);
        }
        else
        {
            if (!unit.isTourActive)
                unitCamera.transform.Rotate(Vector3.up, 0.0f * angularVelocity * Time.deltaTime, Space.World);
            else
                tourCamera.transform.Rotate(Vector3.up, 0.0f * angularVelocity * Time.deltaTime, Space.World);
        }


        if (forwardRotate)
        {
            if (!unit.isTourActive) { unitCamera.transform.Rotate(Vector3.right, 1.0f * angularVelocity * Time.deltaTime, Space.Self); }
            else
            {
                if (calculateRange(tourCamera.transform.localEulerAngles.x))
                {
                    tourCamera.transform.Rotate(Vector3.right, 1.0f * angularVelocity * Time.deltaTime, Space.Self);
                }
                else
                {
                    if (tourCamera.transform.localEulerAngles.x >= 320)
                    {
                        tourCamera.transform.Rotate(Vector3.right, 1.0f * angularVelocity * Time.deltaTime, Space.Self);
                    }
                }
            }
        }
        else if (reverseRotate)
        {
            if (!unit.isTourActive) { unitCamera.transform.Rotate(Vector3.right, -1.0f * angularVelocity * Time.deltaTime, Space.Self); }
            else
            {
                if (calculateRange(tourCamera.transform.localEulerAngles.x))
                {
                    tourCamera.transform.Rotate(Vector3.right, -1.0f * angularVelocity * Time.deltaTime, Space.Self);
                }
                else
                {
                    if (tourCamera.transform.localEulerAngles.x <= 40)
                    {
                        tourCamera.transform.Rotate(Vector3.right, -1.0f * angularVelocity * Time.deltaTime, Space.Self);
                    }
                }
            }
        }
        else
        {
            if (!unit.isTourActive)
                unitCamera.transform.Rotate(Vector3.right, 0.0f * angularVelocity * Time.deltaTime, Space.Self);
            else
                tourCamera.transform.Rotate(Vector3.right, 0.0f * angularVelocity * Time.deltaTime, Space.Self);
        }
    }

    private bool calculateRange(float value)
    {
        if ((value >= 0 && value <= 30) || (value >= 330 && value <= 360)) { return true; }
        else { return false; }
    }

    public void LeftPointer(bool check) { left = check; }
    public void RightPointer(bool check) { right = check; }
    public void ForwardPointer(bool check) { forward = check; }
    public void ReversePointer(bool check) { reverse = check; }
    public void UpPointer(bool check) { up = check;}
    public void DownPointer(bool check) { down = check;}

    public void LeftRotatePointer(bool check) { leftRotate = check; }
    public void RightRotatePointer(bool check) { rightRotate = check; }
    public void ForwardRotatePointer(bool check) { forwardRotate = check; }
    public void ReverseRotatePointer(bool check) { reverseRotate = check; }
}