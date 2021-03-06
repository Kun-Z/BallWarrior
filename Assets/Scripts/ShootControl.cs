﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootControl : MonoBehaviour {
    LineRenderer Line;
    AudioSource Sound;
    bool Click;
    // Use this for initialization
    void Start () {
        Line = Camera.main.GetComponent<LineRenderer>();
        Sound = gameObject.GetComponent<AudioSource>();
        Click = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.IsStart)
        {
            //关闭UI
            GameObject root1 = GameObject.Find("Canvas/BottomBar");
            root1.transform.Find("Cover").gameObject.SetActive(true);
            GameObject root2 = GameObject.Find("Canvas/TopBar");
            root2.transform.Find("Cover").gameObject.SetActive(true);
            if (Input.GetMouseButton(0) || Click)
            {
                Line.enabled = true;
                Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Line.SetPosition(0, MousePos);
                Click = true;
                if (Input.GetMouseButtonUp(0))
                {
                    //关闭发射
                    Click = false;
                    GameManager.GM.IsStart = false;
                    //删除连线
                    Line.enabled = false;
                    string objName = string.Concat("Ball", GameManager.GM.BallNum);
                    GameObject obj = GameObject.Find(objName);
                    //print("ShootBallName:" + obj);
                    //获取方向
                    Vector2 mTarget = Input.mousePosition;
                    Vector2 BallPosition = Camera.main.WorldToScreenPoint(obj.transform.position);
                    Vector2 mDirection = new Vector2(mTarget.x - BallPosition.x, mTarget.y - BallPosition.y);
                    Vector2 nDirection = mDirection.normalized;
                    //print(nDirection);
                    //打开box
                    obj.GetComponent<CircleCollider2D>().enabled = true;
                    //发射
                    obj.GetComponent<Rigidbody2D>().AddForce(nDirection * (400 + GameManager.GM.BallSpeed * 50));
                    //恢复时间
                    Time.timeScale = 1.0f;
                    Sound.Play();
                    //恢复UI
                    Invoke("ResetUI", 0.3f);
                }
            }
        }
    }
    private void ResetUI()
    {
        GameObject.Find("Canvas/BottomBar/Cover").SetActive(false);
        GameObject.Find("Canvas/TopBar/Cover").SetActive(false);
    }
}