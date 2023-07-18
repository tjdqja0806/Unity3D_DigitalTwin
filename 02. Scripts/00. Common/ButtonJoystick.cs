using UnityEngine;
using UnityEngine.UI;

public class ButtonJoystick : MonoBehaviour
{
    //public Button button;
    //public Sprite idle;
    //public Sprite over;
    [Space]
    public GameObject joystickGroup;

    private bool isActive = false;

    void Update()
    {
        joystickGroup.SetActive(isActive);
        //if (isActive) { button.image.sprite = over; }
        //else { button.image.sprite = idle; }
    }

    public void Click() { isActive = !isActive; }
}