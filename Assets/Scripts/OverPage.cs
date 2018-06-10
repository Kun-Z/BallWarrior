using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OverPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int Point = PlayerPrefs.GetInt("Point");
        int Record = PlayerPrefs.GetInt("Record");
        GameObject root = GameObject.Find("Canvas/OverPage/Point");
        string PointText = string.Format("{0:N0}", Point);
        root.GetComponent<Text>().text = PointText;
        root.GetComponent<RectTransform>().DOShakePosition(3,3);
        if (Point>Record)
        {
            root.transform.Find("NewRecord").gameObject.SetActive(true);
            PlayerPrefs.SetInt("LastRecord", Record);
            PlayerPrefs.SetInt("Record", Point);
            if (Record == 0)
            {
                GameObject.Find("Canvas/OverPage/Point/Record").SetActive(false);
                return;
            }
            GameObject.Find("Canvas/OverPage/Point/Record").GetComponent<Text>().text = string.Concat("上个记录：", string.Format("{0:N0}", Record));
        }
        else
        {
            GameObject.Find("Canvas/OverPage/Point/Record").GetComponent<Text>().text = string.Concat("最高记录：", string.Format("{0:N0}", Record));
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
