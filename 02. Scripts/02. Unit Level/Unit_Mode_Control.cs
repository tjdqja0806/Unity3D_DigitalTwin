using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit_Mode_Control : MonoBehaviour
{
    [Serializable]
    public struct mainGruop
    {
        public CanvasGroup mainCanvas;
        public Camera mainCamera;
        public GameObject mainObject;
    }
    [Serializable]
    public struct tourGroup
    {
        public CanvasGroup tourCanvas;
        public Camera tourCamera;
        public GameObject TourObject;
    }
    [SerializeField]
    public mainGruop main;
    [SerializeField]
    public tourGroup tour;

    private UnitLevelControl script;
    // Start is called before the first frame update
    void Awake()
    {
        script = GetComponent<UnitLevelControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ModeCheck();
    }
    
    private void ModeCheck()
    {
        tour.tourCanvas = tour.tourCanvas.GetComponent<CanvasGroup>();
        main.mainCanvas = main.mainCanvas.GetComponent<CanvasGroup>();
    }
}
