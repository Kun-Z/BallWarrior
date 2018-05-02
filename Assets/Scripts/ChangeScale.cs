using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScale : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnClick()
    {
        int RandomNum = Random.Range(1, GameManager.BallNum + 1);
        print("RandomNum:"+ RandomNum);
        string RandomBall = string.Concat("Ball", RandomNum);
        GameObject obj = GameObject.Find(RandomBall);
        Vector3 CurScale = obj.transform.localScale;
        Vector3 NewScale = CurScale + new Vector3(0.1f, 0.1f, 0);
        obj.transform.localScale = NewScale;
    }
}
