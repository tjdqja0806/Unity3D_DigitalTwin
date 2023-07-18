using UnityEngine;
using UnityEngine.UI;

public class AlarmAnimation : MonoBehaviour
{
    public Sprite[] animationSprite1;
    public Sprite[] animationSprite2;
    public GameObject group;
    public Image image;

    private AlarmControl script;
    private float timer = 0.0f;
    private int index = 0;
    private bool check = false;

    void Awake()
    {
        script = GameObject.Find("Menu 2").GetComponent<AlarmControl>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 0.05f;

            if (script.isAlarm)
            {
                group.SetActive(true);
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
            else
            {
                check = false;
                index = 0;
                group.SetActive(false);
            }
        }
    }
}