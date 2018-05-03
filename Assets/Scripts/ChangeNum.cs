using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNum : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnClick()
    {
        GameManager.BallNum += 1;
        //print("BallNum:" + GameManager.BallNum);
        GameObject obj = (GameObject)Resources.Load("Prefabs/Ball");
        GameObject NewBall = Instantiate(obj);
        //重新命名
        string name = string.Concat("Ball", GameManager.BallNum);
        NewBall.name = name;
        //改变父级
        GameObject mFather = GameObject.Find("BallList");
        NewBall.transform.parent = mFather.transform;
        //改变等级
        GameObject.Find("Canvas/Num/lvl").GetComponent<Text>().text = string.Concat("LV.", GameManager.BallNum);
        //关闭UI点击
        GameObject.Find("Canvas/Num").GetComponent<Button>().enabled = false;
        GameObject.Find("Canvas/Scale").GetComponent<Button>().enabled = false;
        //设置子弹时间
        Time.timeScale = 0.2f;
        //可以发射
        GameManager.IsStart = true;
    }

}
