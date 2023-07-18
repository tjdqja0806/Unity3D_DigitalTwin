using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlarmSceneLoad : MonoBehaviour
{
    private bool isLoad;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isLoad = !isLoad;
        if (isLoad)
            SceneManager.LoadScene("100. Alarm", LoadSceneMode.Additive);
        else
            SceneManager.UnloadSceneAsync("100. Alarm");
    }
}
