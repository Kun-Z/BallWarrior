using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpeed : MonoBehaviour {
    int LV;
    // Use this for initialization
    void Start () {
        GameObject.Find("Canvas/BottomBar/Speed/lvl").GetComponent<Text>().text = string.Concat("LV.", 1);
        GameObject.Find("Canvas/BottomBar/Speed/bg/cost").GetComponent<Text>().text = GameManager.GM.BallSpeedCost[1][1];
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnClick()
    {
        GameManager.GM.BallSpeed += 1;
        //print("BallSpeed:" + GameManager.BallSpeed);
        int BallNum = GameManager.GM.BallNum;
        for (int i = 1; i <= BallNum; i++)
        {
            string name = string.Concat("Ball", i);
            GameObject obj = GameObject.Find(name);
            Vector2 nDirection = obj.GetComponent<Rigidbody2D>().velocity.normalized;
            //print(nDirection);
            obj.GetComponent<Rigidbody2D>().AddForce(nDirection * 200);
        }
        //改变等级
        LV = GameManager.GM.BallSpeed;
        GameObject.Find("Canvas/BottomBar/Speed/lvl").GetComponent<Text>().text = string.Concat("LV.", LV);
        GameObject.Find("Canvas/BottomBar/Speed/bg/cost").GetComponent<Text>().text = GameManager.GM.BallSpeedCost[LV][1];
        //判断按钮状态
        if (int.Parse(GameManager.GM.BallNumCost[GameManager.GM.BallNum][1])>GameManager.GM.Point)
        {
            GameObject.Find("Canvas/BottomBar/Num").GetComponent<Button>().interactable = false;
        }
        if (int.Parse(GameManager.GM.BallNumCost[GameManager.GM.BallScale][1]) > GameManager.GM.Point)
        {
            GameObject.Find("Canvas/BottomBar/Scale").GetComponent<Button>().interactable = false;
        }
        if (int.Parse(GameManager.GM.BallSpeedCost[GameManager.GM.BallSpeed][1]) > GameManager.GM.Point)
        {
            GameObject.Find("Canvas/BottomBar/Speed").GetComponent<Button>().interactable = false;
        }
    }

}
