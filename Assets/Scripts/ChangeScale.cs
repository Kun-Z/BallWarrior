using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScale : MonoBehaviour {
    int LV;
    // Use this for initialization
    void Start () {
        GameObject.Find("Canvas/Scale/lvl").GetComponent<Text>().text = string.Concat("LV.", 1);
        GameObject.Find("Canvas/Scale/bg/cost").GetComponent<Text>().text = GameManager.BallNumCost[1][1];
        GetComponent<Button>().onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnClick()
    {
        GameManager.BallScale += 1;
        int RandomNum = Random.Range(1, GameManager.BallNum + 1);
        //print("RandomNum:"+ RandomNum);
        string RandomBall = string.Concat("Ball", RandomNum);
        GameObject obj = GameObject.Find(RandomBall);
        Vector3 CurScale = obj.transform.localScale;
        Vector3 NewScale = CurScale + new Vector3(0.1f, 0.1f, 0);
        obj.transform.localScale = NewScale;
        //改变等级
        LV = GameManager.BallScale;
        GameObject.Find("Canvas/Scale/lvl").GetComponent<Text>().text = string.Concat("LV.", LV);
        GameObject.Find("Canvas/Scale/bg/cost").GetComponent<Text>().text = GameManager.BallNumCost[LV][1];
    }
}
