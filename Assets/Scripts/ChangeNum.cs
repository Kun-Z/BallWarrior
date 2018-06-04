using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNum : MonoBehaviour {
    int LV;
    // Use this for initialization
    void Start () {
        GameObject.Find("Canvas/BottomBar/Num/lvl").GetComponent<Text>().text = string.Concat("LV.", 1);
        GameObject.Find("Canvas/BottomBar/Num/bg/cost").GetComponent<Text>().text = GameManager.BallNumCost[1][1];
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnClick()
    {
        GameManager.Point = GameManager.Point - int.Parse(GameManager.BallNumCost[GameManager.BallNum][1]);
        GameManager.BallNum += 1;
        //print("BallNum:" + GameManager.BallNum);
        GameObject obj = (GameObject)Resources.Load("Prefabs/Ball");
        GameObject NewBall = Instantiate(obj);
        //重新命名
        string name = string.Concat("Ball", GameManager.BallNum);
        NewBall.name = name;
        //改变父级
        GameObject mFather = GameObject.Find("BallList");
        NewBall.transform.SetParent(mFather.transform,false);
        //改变等级
        LV = GameManager.BallNum;
        GameObject.Find("Canvas/BottomBar/Num/lvl").GetComponent<Text>().text = string.Concat("LV.", LV);
        GameObject.Find("Canvas/BottomBar/Num/bg/cost").GetComponent<Text>().text = GameManager.BallNumCost[LV][1];
        //关闭UI点击
        //判断按钮状态
        if (int.Parse(GameManager.BallNumCost[LV][1])>GameManager.Point)
        {
            GameObject.Find("Canvas/BottomBar/Num").GetComponent<Button>().interactable = false;
        }
        if (int.Parse(GameManager.BallNumCost[GameManager.BallScale][1]) > GameManager.Point)
        {
            GameObject.Find("Canvas/BottomBar/Scale").GetComponent<Button>().interactable = false;
        }
        //设置子弹时间
        Time.timeScale = 0.2f;
        //可以发射
        GameManager.IsStart = true;
    }

}
