using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStickMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float angularVelocity = 1.0f;

    public Image pointerImage;
    public Sprite originPointer;
    public Sprite[] pointer;

    public Image rotaterImage;
    public Sprite originRotater;
    public Sprite[] rotater;

    private bool left = false;
    private bool right = false;
    private Vector3 lrTranslation = new Vector3(0, 0, 0);
    private bool forward = false;
    private bool reverse = false; 
    private bool up = false;
    private bool down = false;
    private Vector3 frTranslation = new Vector3(0, 0, 0);
    private Vector3 udTranslation = new Vector3(0, 0, 0);
    private bool leftRotate = false;
    private bool rightRotate = false;
    private bool forwardRotate = false;
    private bool reverseRotate = false;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PointerImage();
        RotaterImage();

        if (left) { lrTranslation = new Vector3(-0.01f, 0.00f, 0.00f); }
        else if (right) { lrTranslation = new Vector3(0.01f, 0.00f, 0.00f); }
        else { lrTranslation = new Vector3(0, 0, 0); }

        if (forward) { frTranslation = new Vector3(0.0f, 0.0f, 0.01f); }
        else if (reverse) { frTranslation = new Vector3(0.0f, 0.0f, -0.01f); }
        else { frTranslation = new Vector3(0, 0, 0); }
        if (up) { udTranslation = new Vector3(0.0f, 0.01f, 0.0f); }
        else if (down) { udTranslation = new Vector3(0.0f, -0.01f, 0.0f); }
        else { udTranslation = new Vector3(0.0f, 0.0f, 0.0f); }

        transform.Translate(lrTranslation * speed * Time.deltaTime, Space.Self);
        transform.Translate(frTranslation * speed * Time.deltaTime, Space.Self);
        transform.Translate(udTranslation * speed * Time.deltaTime, Space.Self);

        if (leftRotate) { transform.Rotate(Vector3.up, 1.0f * angularVelocity * Time.deltaTime, Space.World); }
        else if (rightRotate) { transform.Rotate(Vector3.up, -1.0f * angularVelocity * Time.deltaTime, Space.World); }
        else { transform.Rotate(Vector3.up, 0.0f * angularVelocity * Time.deltaTime, Space.World); }

        if (forwardRotate) { transform.Rotate(Vector3.right, 1.0f * angularVelocity * Time.deltaTime, Space.Self); }
        else if (reverseRotate) { transform.Rotate(Vector3.right, -1.0f * angularVelocity * Time.deltaTime, Space.Self); }
        else { transform.Rotate(Vector3.right, 0.0f * angularVelocity * Time.deltaTime, Space.Self); }
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
    public void LeftPointer(bool check) { left = check; }
    public void RightPointer(bool check) { right = check; }
    public void ForwardPointer(bool check) { forward = check; }
    public void ReversePointer(bool check) { reverse = check; }
    public void UpPointer(bool check) { up = check; }
    public void DownPointer(bool check) { down = check; }
    public void LeftRotatePointer(bool check) { leftRotate = check; }
    public void RightRotatePointer(bool check) { rightRotate = check; }
    public void ForwardRotatePointer(bool check) { forwardRotate = check; }
    public void ReverseRotatePointer(bool check) { reverseRotate = check; }
}
