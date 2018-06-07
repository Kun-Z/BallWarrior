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
        if (GameManager.GM.IsStart)
        {
            Line.enabled = true;
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Line.SetPosition(0, MousePos);
            //关闭UI
            GameObject root1 = GameObject.Find("Canvas/BottomBar");
            root1.transform.Find("Cover").gameObject.SetActive(true);
            GameObject root2 = GameObject.Find("Canvas/TopBar");
            root2.transform.Find("Cover").gameObject.SetActive(true);

            if (Input.GetMouseButton(0))
            {
                //关闭发射
                GameManager.GM.IsStart = false;
                //删除连线
                Line.enabled = false;
                string objName = string.Concat("Ball", GameManager.GM.BallNum);
                GameObject obj = GameObject.Find(objName);
                //print("ShootBallName:" + obj);
                //获取方向
                Vector2 mTarget = Input.mousePosition;
                print(mTarget);
                //print(Camera.main.WorldToScreenPoint(Input.mousePosition));
                //print(Camera.main.WorldToViewportPoint(Input.mousePosition));
                print(obj.transform.position);
                print(Camera.main.ViewportToScreenPoint(obj.transform.position));
                print(Camera.main.ViewportToWorldPoint(obj.transform.position));
                Vector2 mDirection = new Vector2(mTarget.x - obj.transform.position.x, mTarget.y - obj.transform.position.y);
                print(mDirection);
                Vector2 nDirection = mDirection.normalized;
                //print(nDirection);
                //打开box
                obj.GetComponent<CircleCollider2D>().enabled = true;
                //发射
                obj.GetComponent<Rigidbody2D>().AddForce(nDirection * (800 + GameManager.GM.BallSpeed*200));
                //恢复时间
                Time.timeScale = 1.0f;
                //恢复UI
                Invoke("ResetUI", 0.3f);
            }
        }
    }
    private void ResetUI()
    {
        GameObject.Find("Canvas/BottomBar/Cover").SetActive(false);
        GameObject.Find("Canvas/TopBar/Cover").SetActive(false);
    }
}