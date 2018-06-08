using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnClick()
    {
        GameObject.Find("Canvas/PausePage").SetActive(false);
        Time.timeScale = 0.0f;
        GameManager.GM.IsStart = false;
        GameObject root = GameObject.Find("Canvas");
        root.transform.Find("OverPage").gameObject.SetActive(true);
        PlayerPrefs.SetInt("Point", GameManager.GM.Point);
    }
}
