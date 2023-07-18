using UnityEngine;
using UnityEngine.UI;

public class PlantStatusBackAni : MonoBehaviour
{
    public GameObject circle;
    public GameObject back;
    public Image backImage;
    public CanvasGroup cg;
    public Sprite[] backs;

    private PlantLevelControl script;
    private float timer = 0.0f;
    private bool actionCheck = false;
    private int index = 0;

    void Awake()
    {
        script = GameObject.Find("EventSystem").GetComponent<PlantLevelControl>();
        index = backs.Length;
    }

    void Update()
    {
        if (script.isUIActive.Equals(actionCheck))
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 0.05f;
                if (script.isUIActive)
                {
                    circle.SetActive(true);
                    back.SetActive(true);
                    if (index < backs.Length - 1) { index++; }
                    backImage.sprite = backs[index];
                    if (index.Equals(backs.Length - 1) && cg.alpha < 1)
                    {
                        cg.alpha += 0.2f;
                        if (cg.alpha.Equals(1)) { actionCheck = !actionCheck; }
                    }
                }
                else
                {
                    if (cg.alpha > 0) { cg.alpha -= 0.2f; }
                    if (cg.alpha.Equals(0))
                    {
                        if (index > 0) { index--; }
                        backImage.sprite = backs[index];
                        if (index.Equals(0))
                        {
                            back.SetActive(false);
                            circle.SetActive(false);
                            actionCheck = !actionCheck;
                        }
                    }
                }
            }
        }
    }
}