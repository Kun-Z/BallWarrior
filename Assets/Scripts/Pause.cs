using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnClick()
    {
        Time.timeScale = 0.0f;
        GameObject root = GameObject.Find("Canvas");
        root.transform.Find("PausePage").gameObject.SetActive(true);
    }
}
