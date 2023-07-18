using System;
using UnityEngine;

public class ServerXrayMaterial : MonoBehaviour
{
    [Serializable]
    public struct ServerObject
    {
        public string serverName;
        public GameObject[] xrayObject;
        [HideInInspector]
        public double[] valueData;
        [HideInInspector]
        public Renderer[] xrayObjectRenderer;
    }

    [SerializeField]
    public ServerObject[] serverObject;
    public Material xrayMaterial;

    private float scaleY;
    private float timer;
    private DataAgent dataAgent;
    private void Awake()
    {
        dataAgent = GetComponent<DataAgent>();
        for (int i = 0; i < serverObject.Length; i++)
        {
            serverObject[i].xrayObjectRenderer = new Renderer[serverObject[i].xrayObject.Length];
            for (int j = 0; j < serverObject[i].xrayObject.Length; j++)
            {
                serverObject[i].xrayObjectRenderer[j] = serverObject[i].xrayObject[j].GetComponent<Renderer>();
            }
        }
    }
    private void Start()
    {
        _LevelColor();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 5f;
            _LevelColor();
        }
    }

    private void _LevelColor()
    {
        //Level 모델 색 변환 하는 부분
        for (int i = 0; i < serverObject.Length; i++)
        {
            serverObject[i].valueData = dataAgent.ServerStatus(serverObject[i].serverName);
            scaleY = 1 - ((float)serverObject[i].valueData[5] / (float)serverObject[i].valueData[4]);
            for (int j = 0; j < serverObject[i].xrayObject.Length; j++)
            {
                serverObject[i].xrayObject[j].transform.localScale = new Vector3(1, scaleY, 1);
                serverObject[i].xrayObjectRenderer[j].material = xrayMaterial;
                if (serverObject[i].xrayObject[j].gameObject.transform.localScale.y >= 0.8)
                    serverObject[i].xrayObjectRenderer[j].material.SetColor("_FresnelColor", Color.red);
                else if (serverObject[i].xrayObject[j].gameObject.transform.localScale.y >= 0.5)
                    serverObject[i].xrayObjectRenderer[j].material.SetColor("_FresnelColor", Color.yellow);
                else if (serverObject[i].xrayObject[j].gameObject.transform.localScale.y <= 0.5)
                    serverObject[i].xrayObjectRenderer[j].material.SetColor("_FresnelColor", Color.green);
            }
        }

    }
}