using Michsky.UI.Hexart;
using UnityEngine;

public class ClickCollider : MonoBehaviour
{
    private HUDManager hUDManager;
    void Awake() 
    {
        hUDManager = GameObject.Find("HUD Manager").GetComponent<HUDManager> ();
    }

    void Update()
    {
        if (!hUDManager.isOpen)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);
                if (hit.collider != null)
                {
                    switch (hit.transform.gameObject.name)
                    {
                        case "SK3_Collider":
                            AutoFade.LoadLevel(1, 0.5f, 0.5f, Color.black);
                            break;
                    }
                }
            }
        }
    }
}