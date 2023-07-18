using UnityEngine;
using UnityEngine.UI;

public class PlantStatusImage : MonoBehaviour
{
    public Color operationCircle;
    public Color operationLine;
    public Color stopCircle;
    public Color stopLine;
    public Color alarmCircle;
    public Color alarmLine;
    [Space]
    public Sprite[] primarys;
    public Sprite[] secondarys1;
    public Sprite[] secondarys2;
    [Space]
    public Image threePri;
    public Image threeSecCircle;
    public Image threeSecLine;
    public Image fourPri;
    public Image fourSecCircle;
    public Image fourSecLine;
    [Space]
    public int frameSpeed = 20;

    private PlantLevelControl script;

    void Awake()
    {
        script = GameObject.Find("EventSystem").GetComponent<PlantLevelControl>();
    }

    void Update()
    {
        ChangeImage(threePri, script.status3rdPri, primarys, false);
        ChangeImage(threeSecCircle, script.status3rdSec, secondarys1, false);
        ChangeImage(threeSecLine, script.status3rdSec, secondarys2, true);
        ChangeImage(fourPri, script.status4thPri, primarys, false);
        ChangeImage(fourSecCircle, script.status4thSec, secondarys1, false);
        ChangeImage(fourSecLine, script.status4thSec, secondarys2, true);
    }

    private void ChangeImage(Image image, int status, Sprite[] sprites, bool line)
    {
        switch (status)
        {
            case 0:
                if (line) { image.color = operationLine; }
                else { image.color = operationCircle; }
                image.sprite = sprites[(int)(Time.time * frameSpeed) % sprites.Length];
                break;

            case 1:
                if (line) { image.color = stopLine; }
                else { image.color = stopCircle; }
                image.sprite = sprites[sprites.Length - 1];
                break;

            case 2:
                if (line) { image.color = alarmLine; }
                else { image.color = alarmCircle; }
                image.sprite = sprites[(int)(Time.time * frameSpeed) % sprites.Length];
                break;
        }
    }
}