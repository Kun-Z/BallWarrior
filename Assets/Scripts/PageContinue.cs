using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageContinue : MonoBehaviour {

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
        Time.timeScale = 1.0f;
    }
}
