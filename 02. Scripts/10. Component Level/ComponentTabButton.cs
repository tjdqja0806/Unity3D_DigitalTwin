using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComponentTabButton : MonoBehaviour
{
    [Space]
    public GameObject[] contents;
    [Space]
    public TextMeshProUGUI[] text;
    [Space]
    public Image[] line;

    private int status = 0;
    private Color seletColor = new Color(1, 1 ,1 ,1);
    private Color noneColor = new Color(1, 1, 1, 0.3f);

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < contents.Length; i++)
        {
            if(i == status)
            {
                contents[i].SetActive(true);
                text[i].alpha = 1f;
                line[i].color = seletColor;
            }
            else
            {
                contents[i].SetActive(false);
                text[i].alpha = 0.3f;
                line[i].color = noneColor;
            }
        }
    }
    public void Click(int num)
    {
        status = num;
    }
}
