using UnityEngine;

public class MenuCircle : MonoBehaviour
{
    [SerializeField] private float radius = 40f;
    [SerializeField] private float rotateSpeed = 10f;

    private Transform[] items;
    private int[] groundIndexs;
    private int groundCount = 0;
    private int groundCal = 0;
    private bool isOdd = false;
    private int count = 0;
    private int currentTarget = 0;
    private float offsetRotation;
    private Quaternion dummyRotation;

    void Awake()
    {
        dummyRotation = transform.rotation;

        items = new Transform[transform.childCount];
        groundIndexs = new int[transform.childCount];
        foreach (Transform child in transform)
        {
            items[count] = child;
            count++;
        }
        groundCount = items.Length / 2;
        if (items.Length % 2 == 0) { isOdd = false; }
        else { isOdd = true; }

        offsetRotation = 360.0f / count;
        for (int i = 0; i < count; i++)
        {
            float angle = i * Mathf.PI * 2f / count;
            Vector3 newPos = new Vector3(-Mathf.Sin(angle) * radius, 0, -Mathf.Cos(angle) * radius);
            if (i == 0) { items[i].localPosition = newPos; }
            else { items[count - i].localPosition = newPos; }

            if (i <= groundCount) { groundIndexs[i] = i; }
            else
            {
                groundCal++;
                if (isOdd) { groundIndexs[i] = i - (2 * groundCal - 1); }
                else { groundIndexs[i] = i - (2 * groundCal); }
            }
        }

        for (int i = 0; i < groundIndexs.Length; i++)
        {
            float temp = 1 - (groundIndexs[i] * 0.1f);
            items[i].localScale = new Vector3(temp, temp, temp);
            items[i].localPosition = new Vector3(items[i].localPosition.x, groundIndexs[i] * 80, items[i].localPosition.z);
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, dummyRotation, rotateSpeed * Time.deltaTime);

        for (int i = 0; i < groundIndexs.Length; i++)
        {
            float temp = 1 - (groundIndexs[i] * 0.1f);
            Vector3 v3 = new Vector3(temp, temp, temp);
            items[i].localScale = Vector3.Slerp(items[i].localScale, v3, rotateSpeed * Time.deltaTime);
            v3 = new Vector3(items[i].localPosition.x, groundIndexs[i] * 80, items[i].localPosition.z);
            items[i].localPosition = Vector3.Slerp(items[i].localPosition, v3, rotateSpeed * Time.deltaTime);
            //Debug.Log("i : " + i + ", groundIndexs[i] : " + groundIndexs[i] + ", name : " + items[i].gameObject.name);
        }
    }

    public void ChangeTarget(int offset)
    {
        currentTarget += offset;
        if (currentTarget > items.Length - 1) currentTarget = 0;
        else if (currentTarget < 0) currentTarget = items.Length - 1;
        dummyRotation *= Quaternion.Euler(Vector3.up * offset * offsetRotation);

        if (offset > 0)
        {
            int temp = groundIndexs[groundIndexs.Length - 1];
            for (int i = groundIndexs.Length - 1; i >= 1; i--)
            {
                groundIndexs[i] = groundIndexs[i - 1];
            }
            groundIndexs[0] = temp;
        }
        else
        {
            int temp = groundIndexs[0];
            for (int i = 0; i < groundIndexs.Length - 1; i++)
            {
                groundIndexs[i] = groundIndexs[i + 1];
            }
            groundIndexs[groundIndexs.Length - 1] = temp;
        }
    }
}