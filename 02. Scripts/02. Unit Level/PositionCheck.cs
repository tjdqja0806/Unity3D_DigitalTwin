using UnityEngine;
using UnityEngine.UI;

public class PositionCheck : MonoBehaviour
{
    public Text positionText;
    [HideInInspector]
    public string nameString;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != null)
        {
            positionText.text = other.gameObject.name;
            nameString = other.gameObject.name;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        positionText.text = "Position";
        nameString = "Position";
    }
}