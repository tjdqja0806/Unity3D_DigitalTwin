using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentAnimationIcon : MonoBehaviour
{
    private Image animIcon;
    // Start is called before the first frame update
    void Awake()
    {
        animIcon = GetComponent<Image>();
        StartCoroutine(FadeInOut());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        StartCoroutine(FadeInOut());
    }
    IEnumerator FadeInOut()
    {
        while(gameObject.activeSelf == true)
        {
            animIcon.color = Color.white;
            yield return new WaitForSeconds(0.2f);
            animIcon.color = Color.red;
            yield return new WaitForSeconds(0.2f);
        } 
    }
}
