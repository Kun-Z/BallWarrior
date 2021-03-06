﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PageStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Time.timeScale = 0.0f;
        GetComponent<Button>().onClick.AddListener(OnClick);
        GetComponent<RectTransform>().DOShakePosition(1, 8).SetLoops(-1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnClick()
    {
        GameObject.Find("Canvas/StartPage").SetActive(false);
        GameObject obj = GameObject.Find("Ball0");
        Destroy(obj);
        GameObject.Find("GameManager").SendMessage("StratCreat");
        GameObject.Find("Canvas/BottomBar/Num").SendMessage("OnClick");
    }
}
