using UnityEngine;
using UnityEngine.UI;

public class ServerAnimation : MonoBehaviour
{
    public Sprite[] animationSprite1;
    public Sprite[] animationSprite2;
    public GameObject alarmImage;

    private float timer = 0.0f;
    private Image image;
    private int index = 0;
    private bool check = false;

    void Awake()
    {
        image = alarmImage.GetComponent<Image>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0.05f;

            alarmImage.SetActive(true);
            if (!check) { image.sprite = animationSprite1[index]; }
            else { image.sprite = animationSprite2[index]; }
            index++;
            if (!check && index == animationSprite1.Length)
            {
                check = true;
                index = 0;
            }
            if (check && index == animationSprite2.Length) { index = 0; }
        }
    }
}