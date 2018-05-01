using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour {
    // Use this for initialization
    void Start () {
		
	 }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsShoot)
        {
            CreateBall();
        }
        if (GameManager.IsStart)
        {
            if (Input.GetMouseButtonUp(0))
            {
                GameManager.IsStart = false;
                GameManager.FlyBallNum += 1;
                string objName = string.Concat("Ball", GameManager.BallNum);
                GameObject obj = GameObject.Find(objName);
                print("ShootBallName:" + obj);
                Vector2 mTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mDirection = new Vector2(mTarget.x - obj.transform.position.x, mTarget.y - obj.transform.position.y);
                Vector2 nDirection = mDirection.normalized;
                //print(nDirection);
                obj.GetComponent<Rigidbody2D>().AddForce(nDirection * 30);
                if (GameManager.FlyBallNum < GameManager.BallNum)
                {
                    GameManager.IsShoot = true;
                }
            }
        }
    }

    void CreateBall()
    {
        GameObject obj = (GameObject)Resources.Load("Prefabs/Ball");
        GameObject NewBall = Instantiate(obj);
        string name = string.Concat("Ball", GameManager.FlyBallNum+1);
        NewBall.name = name;
        GameObject mFather = GameObject.Find("BallList");
        NewBall.transform.parent = mFather.transform;
        GameManager.IsShoot = false;
        GameManager.IsStart = true;
    }
 }