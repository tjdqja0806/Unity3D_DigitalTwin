using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchColorChange : MonoBehaviour
{
	[HideInInspector]
	public bool isSelect = false;
	
	public Color basic;
	[Space]
	public Color selected;

	private SearchScene searchScene;
	private TextMeshProUGUI text;

	private void Awake()
	{
		searchScene = GameObject.Find("Menu 2").GetComponent<SearchScene>();
		text = GetComponent<TextMeshProUGUI>();
	}
    private void Update()
    {
		if (searchScene.isSearch && !isSelect)
		{
			text.color = basic;
		}
		else if(searchScene.isSearch && isSelect)
		{
			text.color = selected;
		}
        else
        {
			text.color = basic;
        }
	}

}
