using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int Point = PlayerPrefs.GetInt("Point");
        int Record = PlayerPrefs.GetInt("Record");
        GameObject root = GameObject.Find("Canvas/OverPage/Point");
        if (Point>Record)
        {
            root.transform.Find("NewRecord").gameObject.SetActive(true);
            PlayerPrefs.SetInt("LastRecord", Record);
            PlayerPrefs.SetInt("Record", Point);
            root.GetComponent<Text>().text = Point.ToString();
            int LastRecord = PlayerPrefs.GetInt("LastRecord");
            if (LastRecord == 0)
            {
                GameObject.Find("Canvas/OverPage/Point/Record").SetActive(false);
                return;
            }
            GameObject.Find("Canvas/OverPage/Point/Record").GetComponent<Text>().text = string.Concat("上个记录：", LastRecord);
        }
        else
        {
            root.GetComponent<Text>().text = Point.ToString();
            GameObject.Find("Canvas/OverPage/Point/Record").GetComponent<Text>().text = string.Concat("最高记录：", Record);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
