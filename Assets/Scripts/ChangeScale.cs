using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScale : MonoBehaviour {
    int LV;
    // Use this for initialization
    void Start () {
        GameObject.Find("Canvas/BottomBar/Scale/lvl").GetComponent<Text>().text = string.Concat("LV.", 1);
        GameObject.Find("Canvas/BottomBar/Scale/bg/cost").GetComponent<Text>().text = GameManager.GM.Cost[1][2];
        GetComponent<Button>().onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnClick()
    {
        GameManager.GM.Point = GameManager.GM.Point - int.Parse(GameManager.GM.Cost[GameManager.GM.BallScale][2]);
        GameManager.GM.BallScale += 1;
        int RandomNum = Random.Range(1, GameManager.GM.BallNum + 1);
        //print("RandomNum:"+ RandomNum);
        string RandomBall = string.Concat("Ball", RandomNum);
        GameObject obj = GameObject.Find(RandomBall);
        //改变大小
        Vector3 CurScale = obj.transform.localScale;
        Vector3 NewScale = CurScale + new Vector3(0.2f, 0.2f, 0);
        obj.transform.localScale = NewScale;
        //改变拖尾宽度
        obj.GetComponent<TrailRenderer>().startWidth = NewScale.x * 3.7f;
        //改变等级
        LV = GameManager.GM.BallScale;
        GameObject.Find("Canvas/BottomBar/Scale/lvl").GetComponent<Text>().text = string.Concat("LV.", LV);
        GameObject.Find("Canvas/BottomBar/Scale/bg/cost").GetComponent<Text>().text = GameManager.GM.Cost[LV][2];
        //判断按钮状态
        GameObject.Find("Canvas/BottomBar").SendMessage("Status");
    }
}
