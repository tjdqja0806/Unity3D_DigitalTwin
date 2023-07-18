using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private TagListOnOff tagListOnOff;
    private DataAgent dataAgent;

    private void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();
        tagListOnOff = GetComponent<TagListOnOff>();
    }

    void Start()
    {
        if (!PlayerPrefs.GetString("PostScene").Contains("Unit"))
        {
            PlayerPrefs.SetInt("UnitMode", 0);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            RefreshScene();
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && !tagListOnOff.isOpen)
        {
            PostScene();
        }
    }

    public void click(int index) { AutoFade.LoadLevel(index, 0.5f, 0.5f, Color.black); }

    public void clickString(string index)
    {
        //AutoFade.LoadLevel(index, 0.5f, 0.5f, Color.black);
        string nowScene = SceneManager.GetActiveScene().name;

        if (PlayerPrefs.GetString("PostScene") != index)
            PlayerPrefs.SetString("PostScene", nowScene);

        /*if (nowScene.Contains("Unit"))
        {
            UnitLevelControl unitLevelControl = GameObject.Find("EventSystem").GetComponent<UnitLevelControl>();
            if (!unitLevelControl.isTourActive)
            {
                //0이면 UnitMode
                PlayerPrefs.SetInt("UnitMode", 0);
            }
            else
            {
                //1이면 TourMode
                PlayerPrefs.SetInt("UnitMode", 1);
            }
        }*/

        if (index.Contains("Unit3")) { dataAgent.SetPlantID(3, false); }
        else if (index.Contains("Unit4")) { dataAgent.SetPlantID(4, false); }
        //Debug.Log(PlayerPrefs.GetString("PostScene"));
        LodingBarScript.LoadScene(index);
    }

    public void PostScene()
    {
        string postSceneName;
        if (PlayerPrefs.HasKey("PostScene") && PlayerPrefs.GetString("PostScene") != null)
        {
            postSceneName = PlayerPrefs.GetString("PostScene");
        }
        else
        {
            postSceneName = "00. LoginScene";
        }
        //LodingBarScript.LoadScene(postSceneName);
        clickString(postSceneName);
    }

    public void RefreshScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        LodingBarScript.LoadScene(sceneName);
    }

    public void HomeScene()
    {
        string sceneName = "01. Plant";
        clickString(sceneName);
        //LodingBarScript.LoadScene(sceneName);
    }
}
