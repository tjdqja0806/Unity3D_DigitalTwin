using SpaceNavigatorDriver;
using UnityEngine;
using UnityEngine.UI;

public class TourCameraMove : MonoBehaviour
{
    [HideInInspector]
    public int status = 2;

    [HideInInspector]
    public bool isMovePosition = true;

    [HideInInspector]
    public bool equipmentMove = false;

    [HideInInspector]
    public bool isMoving = false;

    [Space]
    public GameObject[] movePoint;
    [Space]
    public GameObject[] equipmentPoint;
    [Space]
    public GameObject floorImage;
    [Space]
    public Text floorText;
    ///public GameObject dummy;
    public GameObject JPG;
    [Space]
    public MiniMapButton minimapButton;

    private float _3DSpeed = 0.5f;
    private float _3DRotateSpeed = 5f;
    private float moveSpeed = 0.06f;
    private float rotateSpeed = 70;
    private float cameraPositionMoveSpeed = 3f;
    private float _x;
    private float _y;
    private float scroll;
    private bool isListClick = false;
    private int clickStatus;
    private CameraworkingSpaceNavigatorVDI VDI;
    private UnitCharactorControl unitCharactorControl;

    private bool isFoward;
    private bool isBackward;

    void Awake()
    {
        VDI = GameObject.Find("EventSystem").GetComponent<CameraworkingSpaceNavigatorVDI>();
        unitCharactorControl = GameObject.Find("Character").GetComponent<UnitCharactorControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMovePosition && !isListClick)
        {
            Move();
            Rotation();
            WalkAnimation();
        }
        MouseMoveFoward();
        if (Input.GetMouseButton(2))
            MouseMoveSide();
        if (Input.GetMouseButton(1))
            KeyBoardRotation();
        CameraPosition();
        PointMove();
        JPG.transform.position = transform.position;
        JPG.transform.localRotation = Quaternion.Euler(0, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * SpaceNavigator.Translation.z * Time.deltaTime * _3DSpeed, Space.Self);
        transform.Translate(Vector3.right * SpaceNavigator.Translation.x * Time.deltaTime * _3DSpeed, Space.Self);
        switch (status)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, 0.223f, transform.position.z);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x, 0.305f, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x, 0.41606f, transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x, 0.53f, transform.position.z);
                break;
        }
        //transform.position = new Vector3(transform.position.x, 0.45f, transform.position.z);
    }
    private void Rotation()
    {
        // 3D 마우스 회전 기준 Input
        // SpaceNavigator.Rotation.eulerAngles.x : SpaceNavigator.Rotation.Pitch() (위, 아래)
        // SpaceNavigator.Rotation.eulerAngles.y : SpaceNavigator.Rotation.Yaw() (좌, 우)
        // SpaceNavigator.Rotation.eulerAngles.z : SpaceNavigator.Rotation.Roll() (왼쪽 기울기, 오른쪽 기울기)
        // Vector3.up : 오른쪽
        // Vector3.down : 왼쪽
        // Vector3.left : 아래
        // Vector3.right : 위
        // Vector3.forward : 오른쪽 기울기
        // Vector3.back : 왼쪽 기울기

        transform.Rotate(Vector3.up, SpaceNavigator.Rotation.Yaw() * Mathf.Rad2Deg * _3DRotateSpeed, Space.World);

        if (calculateRange(transform.localEulerAngles.x))
        {
            transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * _3DRotateSpeed, Space.Self);
        }
        else
        {
            if (transform.localEulerAngles.x >= 320 && SpaceNavigator.Rotation.Pitch() > 0)
            {
                transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * _3DRotateSpeed, Space.Self);
            }
            else if (transform.localEulerAngles.x <= 40 && SpaceNavigator.Rotation.Pitch() < 0)
            {
                transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * _3DRotateSpeed, Space.Self);
            }
        }
        //if (transform.localEulerAngles.x <= 330 && SpaceNavigator.Rotation.Pitch() > 0)
        //{
        //    transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg * rotateSpeed, Space.Self);
        //}

        //Debug.Log("x : " + transform.localEulerAngles.x + ", Pitch : " + SpaceNavigator.Rotation.Pitch());
    }

    private void MouseMoveSide()
    {
        _x = Input.GetAxis("Mouse X");
        _y = Input.GetAxis("Mouse Y");

        transform.Translate(Vector3.left * moveSpeed * -_x * Time.deltaTime, Space.Self);
    }
    private void MouseMoveFoward()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0 && !isBackward)
            isFoward = true;
        else if (scroll > 0 && isBackward)
            isBackward = false;
        if (scroll < 0 && !isFoward)
            isBackward = true;
        else if (scroll < 0 && isFoward)
            isFoward = false;
        if (isFoward)
            transform.Translate(Vector3.forward * moveSpeed * 0.3f * Time.deltaTime);
        else if (isBackward)
            transform.Translate(Vector3.back * moveSpeed * 0.3f * Time.deltaTime);
    }
    private void KeyBoardRotation()
    {
        _x = Input.GetAxis("Mouse X");
        _y = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.down * rotateSpeed * -_x * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.left * rotateSpeed * _y * Time.deltaTime, Space.Self);
    }
    private bool calculateRange(float value)
    {
        if ((value >= 0 && value <= 30) || (value >= 330 && value <= 360)) { return true; }
        else { return false; }
    }
    private void CameraPosition()
    {
        if (isMovePosition)
        {
            isMoving = true;
            unitCharactorControl.charactor[unitCharactorControl.charactorValue].SetActive(false);
            floorText.text = (status + 1) + "F";
            transform.position = Vector3.Lerp(transform.position, movePoint[status].transform.position, cameraPositionMoveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, movePoint[status].transform.localRotation, cameraPositionMoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint[status].transform.position) < 0.005)
            {
                isMovePosition = false;
                unitCharactorControl.charactor[unitCharactorControl.charactorValue].SetActive(true);
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!equipmentMove)
        {
            switch (other.gameObject.name)
            {
                case "Portal":
                    floorImage.gameObject.SetActive(true);
                    break;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Portal":
                floorImage.gameObject.SetActive(false);
                break;
        }
    }
    public void ListClick(int num)
    {
        isListClick = true;

        floorImage.SetActive(false);
        equipmentMove = true;
        clickStatus = num;
        switch (num)
        {
            case 0:
            case 1:
            case 2:
                status = 0;
                break;
            case 3:
            case 4:
            case 5:
                status = 1;
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                status = 2;
                break;
            case 11:
            case 12:
                status = 3;
                break;
        }
        minimapButton.ButtonSprite();
    }
    private void PointMove()
    {
        if (isListClick)
        {
            isMoving = true;
            unitCharactorControl.charactor[unitCharactorControl.charactorValue].SetActive(false);
            transform.position = Vector3.Lerp(transform.position, equipmentPoint[clickStatus].transform.position, 3f * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, equipmentPoint[clickStatus].transform.localRotation, 3f * Time.deltaTime);
            if (Vector3.Distance(transform.position, equipmentPoint[clickStatus].transform.position) < 0.005)
            {
                equipmentMove = false;
                isMoving = false;
                unitCharactorControl.charactor[unitCharactorControl.charactorValue].SetActive(true);
                isListClick = false;
            }
        }
    }
    private void WalkAnimation()
    {
        if (SpaceNavigator.Translation.z > 0 || isFoward || VDI.forward)
        {
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("Forward", true);
        }
        else if (SpaceNavigator.Translation.z < 0 || isBackward || VDI.reverse)
        {
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("Backward", true);
        }
        else if ((SpaceNavigator.Translation.z == 0 && SpaceNavigator.Translation.x > 0) || (Input.GetMouseButton(2) && _x < 0) || VDI.right)
        {
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("Forward", true);
        }
        else if ((SpaceNavigator.Translation.z == 0 && SpaceNavigator.Translation.x < 0) || (Input.GetMouseButton(2) && _x > 0) || VDI.left)
        {
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("Forward", true);
        }
        else if (SpaceNavigator.Rotation.Yaw() > 0 || VDI.rightRotate || (Input.GetMouseButton(1) && _y > 0))
        {
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("LeftTurn", true);
        } 
        else if (SpaceNavigator.Rotation.Yaw() < 0 || VDI.leftRotate || (Input.GetMouseButton(1) && _y < 0))
        {
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("RightTurn", true);
        }
        else
        {
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("Forward", false);
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("Backward", false);
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("Right", false);
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("Left", false);
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("RightTurn", false);
            unitCharactorControl.anim[unitCharactorControl.charactorValue].SetBool("LeftTurn", false);
        }
    }
}