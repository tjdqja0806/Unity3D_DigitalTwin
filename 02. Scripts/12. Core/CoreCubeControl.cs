using System.Collections.Generic;
using UnityEngine;

public class CoreCubeControl : MonoBehaviour
{
    public GameObject cube;
    public int status;

    private List<GameObject> cubeArrays = new List<GameObject>();
    private List<string> cubeNumbers = new List<string>();
    private DataAgent dataAgent;
    private float timer = 0.0f;
    private string[] splitNumber = new string[3];

    void Awake()
    {
        dataAgent = GameObject.Find("EventSystem").GetComponent<DataAgent>();

        switch (status)
        {
            case 0:
                coreModelFull();
                break;

            case 1:
                coreModelHalf();
                break;

            case 2:
                coreModelCut();
                break;
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 5.0f;
            for (int i = 0; i < cubeArrays.Count; i++)
            {
                if (dataAgent.isAuto) { cubeArrays[i].GetComponent<Renderer>().material.SetColor("_BaseColor", new Color(randomValue(0, 255) / 255f, randomValue(0, 255) / 255f, randomValue(0, 255) / 255f)); }
                else
                {
                    splitNumber = cubeNumbers[i].Split(char.Parse("_"));
                    cubeArrays[i].GetComponent<Renderer>().material.SetColor("_BaseColor", dataAgent.CoreColor(int.Parse(splitNumber[0]), int.Parse(splitNumber[1]), int.Parse(splitNumber[2])));
                }
            }
        }
    }

    private void coreModelFull()
    {
        for (int i = 0; i < 24; i++) // 층
        {
            for (int j = 0; j < 17; j++) // Y축
            {
                for (int k = 0; k < 17; k++) // X축
                {
                    cubeInstance(i, j, k);
                }
            }
        }
    }

    private void coreModelHalf()
    {
        for (int i = 0; i < 24; i++) // 층
        {
            for (int j = 0; j < 17; j++) // Y축
            {
                for (int k = 8; k < 17; k++) // X축
                {
                    cubeInstance(i, j, k);
                }
            }
        }
    }

    private void coreModelCut()
    {
        for (int i = 0; i < 24; i++)// 층
        {
            if (i > 5)
            {
                if (i > 11)
                {
                    for (int j = 0; j < 17; j++) // Y축
                    {
                        for (int k = 8; k < 17; k++) // X축
                        {
                            cubeInstance(i, j, k);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < 17; j++) // Y축
                    {
                        for (int k = 0; k < 17; k++) // X축
                        {
                            if (!(k <= 7 && j >= 9))
                            {
                                cubeInstance(i, j, k);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int j = 0; j < 17; j++) // Y축
                {
                    for (int k = 0; k < 17; k++) // X축
                    {
                        cubeInstance(i, j, k);
                    }
                }
            }
        }
    }

    private void cubeInstance(int i, int j, int k)
    {
        if (!(
            (k == 0 && j == 0) ||
            (k == 0 && j == 1) ||
            (k == 0 && j == 2) ||
            (k == 0 && j == 3) ||
            (k == 0 && j == 4) ||
            (k == 0 && j == 12) ||
            (k == 0 && j == 13) ||
            (k == 0 && j == 14) ||
            (k == 0 && j == 15) ||
            (k == 0 && j == 16) ||

            (k == 1 && j == 0) ||
            (k == 1 && j == 1) ||
            (k == 1 && j == 2) ||
            (k == 1 && j == 14) ||
            (k == 1 && j == 15) ||
            (k == 1 && j == 16) ||

            (k == 2 && j == 0) ||
            (k == 2 && j == 1) ||
            (k == 2 && j == 15) ||
            (k == 2 && j == 16) ||

            (k == 3 && j == 0) ||
            (k == 3 && j == 16) ||

            (k == 4 && j == 0) ||
            (k == 4 && j == 16) ||

            (k == 12 && j == 0) ||
            (k == 12 && j == 16) ||

            (k == 13 && j == 0) ||
            (k == 13 && j == 16) ||

            (k == 14 && j == 0) ||
            (k == 14 && j == 1) ||
            (k == 14 && j == 15) ||
            (k == 14 && j == 16) ||

            (k == 15 && j == 0) ||
            (k == 15 && j == 1) ||
            (k == 15 && j == 2) ||
            (k == 15 && j == 14) ||
            (k == 15 && j == 15) ||
            (k == 15 && j == 16) ||

            (k == 16 && j == 0) ||
            (k == 16 && j == 1) ||
            (k == 16 && j == 2) ||
            (k == 16 && j == 3) ||
            (k == 16 && j == 4) ||
            (k == 16 && j == 12) ||
            (k == 16 && j == 13) ||
            (k == 16 && j == 14) ||
            (k == 16 && j == 15) ||
            (k == 16 && j == 16)
            ))
        {
            GameObject a = Instantiate(cube, Vector3.zero, Quaternion.identity, transform);
            a.transform.parent = transform;
            a.transform.localPosition = new Vector3(j, i, k);
            cubeArrays.Add(a);
            string number = (k + 1) + "_" + (j + 1) + "_" + (i + 1);
            cubeNumbers.Add(number);
        }
    }

    private float randomValue(float min, float max)
    {
        float random = Random.Range(min, max);
        return Mathf.Round(random * 10.0f) / 10.0f;
    }
}