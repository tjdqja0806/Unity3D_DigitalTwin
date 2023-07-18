using UnityEngine;
using UnityEngine.UI;

public class JPGAnimation : MonoBehaviour
{
    public Sprite[] animationSprite;
    public Image animationImage;
    [Space]
    public int speed = 60;

    void Update()
    {
        animationImage.sprite = animationSprite[(int)(Time.time * speed) % animationSprite.Length];
    }
}