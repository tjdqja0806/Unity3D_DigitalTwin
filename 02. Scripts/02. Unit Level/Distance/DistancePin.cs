using TMPro;
using UnityEngine;

public class DistancePin : MonoBehaviour
{
    public GameObject character;
    [Space]
    public GameObject pin;
    public GameObject line;
    public GameObject canvas;

    private bool isFirst = false;
    private Vector3[] pos = new Vector3[2];
    private Transform coordinate;

    public void _ClickCreatePin()
    {
        if (!isFirst)
        {
            GameObject temp = Instantiate(pin,
                new Vector3(character.transform.position.x,
                character.transform.position.y + 0.004f,
                character.transform.position.z),
                new Quaternion(0, 0, 0, 0));
            coordinate = temp.transform;
            isFirst = true;
        }
        else
        {
            Instantiate(pin,
                new Vector3(character.transform.position.x,
                character.transform.position.y + 0.004f,
                character.transform.position.z),
                new Quaternion(0, 0, 0, 0));

            GameObject temp = Instantiate(line,
                new Vector3(character.transform.position.x,
                character.transform.position.y + 0.004f,
                character.transform.position.z),
                new Quaternion(0, 0, 0, 0));
            LineRenderer lineRenderer = temp.GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, coordinate.position);
            lineRenderer.SetPosition(1, temp.transform.position);
            coordinate = temp.transform;
            pos[0] = lineRenderer.GetPosition(0);
            pos[1] = lineRenderer.GetPosition(1);

            GameObject temp2 = Instantiate(canvas,
                new Vector3((pos[0].x + pos[1].x) * 0.5f,
            (pos[0].y + pos[1].y) * 0.5f + 0.002f,
            (pos[0].z + pos[1].z) * 0.5f + 0.000f),
                new Quaternion(0, 0, 0, 0));

            GameObject temp3 = temp2.transform.GetChild(0).gameObject;
            TextMeshProUGUI text = temp3.GetComponent<TextMeshProUGUI>();
            float distance = Vector3.Distance(pos[0], pos[1]) * 100.0f;
            text.text = string.Format("{0:0.00}", distance) + "m";
        }
    }

    public void _ClickReset()
    {
        var pins = GameObject.FindGameObjectsWithTag("Pin");
        foreach (var pin in pins)
        {
            Destroy(pin);
        }
        isFirst = false;
    }
}