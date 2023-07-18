using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LodingBGScript : MonoBehaviour
{
    public Sprite[] manual;
    public Image background;

    private bool status;
    // Start is called before the first frame update
    void Start()
    {
        status = Random.value > 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(status)
            background.sprite = manual[0];
        else
            background.sprite = manual[1];
    }
}
