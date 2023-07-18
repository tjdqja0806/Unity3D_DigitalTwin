using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingBarScript : MonoBehaviour
{
    static string nextScene;
    private bool sceneLoad = false;
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("00. LodingScene");
    }
    [SerializeField]
    Image progressBar;
    // Start is called before the first frame update
    void Awake()
    {
        progressBar.fillAmount = 0f;
        StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    private IEnumerator LoadScene()
    {
        float timer = 0f;
        while (progressBar.fillAmount <= 0.5f)
        {
            yield return null;
            progressBar.fillAmount += Time.deltaTime;
        }
        if (progressBar.fillAmount >= 0.5f)
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
            op.allowSceneActivation = false;
            yield return new WaitForSecondsRealtime(1f);
            while (!op.isDone)
            {
                //progressBar.fillAmount = op.progress;
                
                if(op.progress >= 0.9f)
                {
                    timer += Time.unscaledDeltaTime;
                    progressBar.fillAmount = Mathf.Lerp(0.5f, 1f, timer);
                    if(progressBar.fillAmount >= 1f)
                    {
                        yield return new WaitForSeconds(0.5f);
                        op.allowSceneActivation = true;
                    }
                }
            }

        }
    }
    /*private IEnumerator LoadScene()
    {
        float timer = 0f;
        float timer2 = 3f;
        while (progressBar.fillAmount <= 0.5f)
        {
            yield return null;
            progressBar.fillAmount += Time.deltaTime;
        }
        if (progressBar.fillAmount >= 0.5f)
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
            op.allowSceneActivation = false;
            yield return new WaitForSecondsRealtime(2f);
            while (!op.isDone)
            {
                yield return null;
                if (op.progress <= 0.9f)
                {
                    progressBar.fillAmount = op.progress;
                    Debug.Log(progressBar.fillAmount);
                }
                else
                {
                    timer += Time.deltaTime;
                    progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                    if (progressBar.fillAmount >= 1f)
                    {
                        op.allowSceneActivation = true;
                        yield break;
                    }
                }
            }

        }
    }*/
}
