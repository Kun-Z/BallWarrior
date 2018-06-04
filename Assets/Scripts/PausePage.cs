﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePage : MonoBehaviour {

	// Use this for initialization
    UnityEngine.Events.UnityAction [] actions ;

	void Start () {
        Button[] PauseButton = GetComponentsInChildren<Button>();
        for (int i = 0; i < PauseButton.Length; i++)
        {
            var b = PauseButton[i];
            b.onClick.AddListener(()=> {
                print(b);
                Invoke(b.name, 0);
            });
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Share()
    {
        print("22222222222222222222");
    }

    private void Restart()
    {
        Time.timeScale = 0.0f;
        GameObject root = GameObject.Find("Canvas");
        root.transform.Find("PausePage").gameObject.SetActive(true);
    }

    private void Exit()
    {
        Time.timeScale = 0.0f;
        GameObject root = GameObject.Find("Canvas");
        root.transform.Find("PausePage").gameObject.SetActive(true);
    }

    private void Continue()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}
