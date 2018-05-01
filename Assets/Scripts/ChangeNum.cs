using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNum : MonoBehaviour {
	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnClick()
    {
        GameManager.BallNum += 1;
        //print("BallNum:" + GameManager.BallNum);
        if (GameManager.BallNum - GameManager.FlyBallNum == 1)
        {
            GameManager.IsShoot = true;
        }
    }
    
    private void CopyDirection()
    {
        GameObject Ballobj = GameObject.Find("Ball0");
        print(Ballobj);
        Vector3 CurDirection = Ballobj.GetComponent<Rigidbody2D>().velocity;
        print(CurDirection);
        Vector3 NewDirection = CurDirection.normalized;
        //NewBall.GetComponent<Rigidbody2D>().AddForce(NewDirection * 30);
    }
}
