using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SetSlide()
    {
        float rate = (GameManager.GM.MonsterNum - GameManager.GM.MonsterPos.Count) * 1.0f / 50;
        GetComponent<Slider>().value = rate;
        string str = (rate * 100).ToString("#0.0");
        GetComponentInChildren<Text>().text = string.Concat(str, "%");
        if (rate < 0.5)
        {
            GameObject.Find("Canvas/TopBar/Slider/Fill Area/Fill").GetComponent<Image>().color = new Color(rate * 2, 1.0f, 0.0f, 1.0f);
        }
        else
        {
            GameObject.Find("Canvas/TopBar/Slider/Fill Area/Fill").GetComponent<Image>().color = new Color(1.0f, (2 - rate * 2), 0.0f, 1.0f);
        }
        if (rate >= 1)
        {
            Time.timeScale = 0.0f;
            GameManager.GM.IsStart = false;
            GameObject root = GameObject.Find("Canvas");
            root.transform.Find("OverPage").gameObject.SetActive(true);
            PlayerPrefs.SetInt("Point", GameManager.GM.Point);
        }
    }
}
