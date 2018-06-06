using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNum : MonoBehaviour {
    int LV;
    // Use this for initialization
    void Start () {
        GameObject.Find("Canvas/BottomBar/Num/lvl").GetComponent<Text>().text = string.Concat("LV.", 1);
        GameObject.Find("Canvas/BottomBar/Num/bg/cost").GetComponent<Text>().text = GameManager.GM.BallNumCost[1][1];
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnClick()
    {
        GameManager.GM.Point = GameManager.GM.Point - int.Parse(GameManager.GM.BallNumCost[GameManager.GM.BallNum][1]);
        GameManager.GM.BallNum += 1;
        //print("BallNum:" + GameManager.BallNum);
        GameObject obj = (GameObject)Resources.Load("Prefabs/Ball");
        GameObject NewBall = Instantiate(obj);
        //重新命名
        string name = string.Concat("Ball", GameManager.GM.BallNum);
        NewBall.name = name;
        //改变小球颜色
        Color newColor = Random.ColorHSV(0f, 1f,0f,1f,0f,1f);
        NewBall.GetComponent<Image>().color = newColor;
        NewBall.GetComponent<TrailRenderer>().startColor = newColor;
        //改变父级
        GameObject mFather = GameObject.Find("BallList");
        NewBall.transform.SetParent(mFather.transform,false);
        //改变等级
        LV = GameManager.GM.BallNum;
        GameObject.Find("Canvas/BottomBar/Num/lvl").GetComponent<Text>().text = string.Concat("LV.", LV);
        GameObject.Find("Canvas/BottomBar/Num/bg/cost").GetComponent<Text>().text = GameManager.GM.BallNumCost[LV][1];
        //判断按钮状态
        if (int.Parse(GameManager.GM.BallNumCost[GameManager.GM.BallNum][1]) > GameManager.GM.Point)
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
        //设置子弹时间
        Time.timeScale = 0.2f;
        //可以发射
        GameManager.GM.IsStart = true;
    }

}
