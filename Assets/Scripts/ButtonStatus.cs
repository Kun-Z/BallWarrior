using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Status()
    {
        GameObject.Find("Canvas/TopBar/Point").GetComponent<Text>().text = string.Format("{0:N0}", GameManager.GM.Point);
        if (int.Parse(GameManager.GM.Cost[GameManager.GM.BallNum][1]) > GameManager.GM.Point)
        {
            GameObject.Find("Canvas/BottomBar/Num").GetComponent<Button>().interactable = false;
        }
        if (int.Parse(GameManager.GM.Cost[GameManager.GM.BallScale][2]) > GameManager.GM.Point)
        {
            GameObject.Find("Canvas/BottomBar/Scale").GetComponent<Button>().interactable = false;
        }
        if (int.Parse(GameManager.GM.Cost[GameManager.GM.BallSpeed][3]) > GameManager.GM.Point)
        {
            GameObject.Find("Canvas/BottomBar/Speed").GetComponent<Button>().interactable = false;
        }
    }

    private void AntiStatus()
    {
        GameObject.Find("Canvas/TopBar/Point").GetComponent<Text>().text = string.Format("{0:N0}", GameManager.GM.Point);
        if (int.Parse(GameManager.GM.Cost[GameManager.GM.BallNum][1]) <= GameManager.GM.Point)
        {
            GameObject.Find("Canvas/BottomBar/Num").GetComponent<Button>().interactable = true;
        }
        if (int.Parse(GameManager.GM.Cost[GameManager.GM.BallScale][2]) <= GameManager.GM.Point)
        {
            GameObject.Find("Canvas/BottomBar/Scale").GetComponent<Button>().interactable = true;
        }
        if (int.Parse(GameManager.GM.Cost[GameManager.GM.BallSpeed][3]) <= GameManager.GM.Point)
        {
            GameObject.Find("Canvas/BottomBar/Speed").GetComponent<Button>().interactable = true;
        }
    }
}
