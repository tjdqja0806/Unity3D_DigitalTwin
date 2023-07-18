using TMPro;
using UnityEngine;

public class LODPinScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float min;
    public float max;
    public string contentName;
    public string contentUnit;

    private float timer = 0.0f;
    private double value;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            value = randomValue(min, max);
            text.text = contentName + " : " + float.Parse(string.Format("{0:N1}", value)) + " " + contentUnit;
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}