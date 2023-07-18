using UnityEngine;

public class DistanceLOD : MonoBehaviour
{
    public float distance = 0.3f;
    public GameObject player;

    private CanvasGroup canvasGroup;
    private float result;
    private Vector3 targetPosition;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        /*result = Vector3.Distance(player.transform.position, transform.position);

        if (result <= (distance * 0.5f))
        {
            canvasGroup.alpha = 1;
        }
        else if (result <= (distance * 0.7f))
        {
            canvasGroup.alpha = 0.75f;
        }
        else if (result <= (distance * 0.85f))
        {
            canvasGroup.alpha = 0.5f;
        }
        else if (result <= distance)
        {
            canvasGroup.alpha = 0.25f;
        }
        else
        {
            canvasGroup.alpha = 0;
        }*/

        targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
    }
}