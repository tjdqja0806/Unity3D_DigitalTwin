using UnityEngine;
using UnityEngine.UI;

public class BooleanAnimationChart : MonoBehaviour
{
    public Image image;
    public Sprite trueSprite;
    public Sprite falseSprite;
    [Space]
    public string symbolName;

    private DataAgent dataAgent;
    private float timer = 0.0f;
    private bool isTrue = false;

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            if (dataAgent.isAuto) { isTrue = !isTrue; }
            else { /*value = dataAgent.getValueBySymbolName(symbolName);*/ }
            if (isTrue) { image.sprite = trueSprite; }
            else { image.sprite = falseSprite; }
        }
    }
}