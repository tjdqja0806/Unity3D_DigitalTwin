using UnityEngine;

public class PositionBack : MonoBehaviour
{
    private Transform originTransform;
    Vector3 position;

    private AssembleSettingScript script2;

    void Awake()
    {
        script2 = GameObject.Find("Button Group Full").GetComponent<AssembleSettingScript>();
        originTransform = gameObject.transform;
        position = originTransform.position;
    }

    void Update()
    {
        if (script2.isback)
        {
            gameObject.transform.position = position;
            Invoke("False", 0.5f);
        }
    }
    void False()
    {
        script2.isback = false;
    }
}