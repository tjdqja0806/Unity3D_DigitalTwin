using UnityEngine;
using UnityEngine.UI;

public class ButtonRemoveSteel : MonoBehaviour
{
//    public Button button;
//    public Sprite idle;
//    public Sprite over;
    [Space]
    public GameObject steelUnit3;
    public GameObject steelUnit4;

    private bool isActive = false;

    void Update()
    {
        steelUnit3.SetActive(isActive);
        steelUnit4.SetActive(isActive);

//        if (isActive) { button.image.sprite = over; }
//        else { button.image.sprite = idle; }
    }

    public void Click() { isActive = !isActive; }
}