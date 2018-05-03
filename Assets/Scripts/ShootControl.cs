using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootControl : MonoBehaviour {
    LineRenderer Line;
    // Use this for initialization
    void Start () {
        Line = Camera.main.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsStart)
        {
            Line.enabled = true;
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Line.SetPosition(0, MousePos);
            if (Input.GetMouseButton(0))
            {
                //关闭发射
                GameManager.IsStart = false;
                //删除连线
                Line.enabled = false;
                string objName = string.Concat("Ball", GameManager.BallNum);
                GameObject obj = GameObject.Find(objName);
                print("ShootBallName:" + obj);
                //获取方向
                Vector2 mTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mDirection = new Vector2(mTarget.x - obj.transform.position.x, mTarget.y - obj.transform.position.y);
                Vector2 nDirection = mDirection.normalized;
                //print(nDirection);
                //打开box
                obj.GetComponent<Collider2D>().enabled = true;
                //发射
                obj.GetComponent<Rigidbody2D>().AddForce(nDirection * 30);
                //恢复UI
                GameObject.Find("Canvas/Num").GetComponent<Button>().enabled = true;
                GameObject.Find("Canvas/Scale").GetComponent<Button>().enabled = true;
                //恢复时间
                Time.timeScale = 1.0f;
            }
        }
    }
 }