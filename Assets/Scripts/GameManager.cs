using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager GM;
    public int MonsterCount;
    public int BallNum;
    public int BallScale;
    public int BallSpeed;
    public int MonsterNum;
    public bool IsStart;
    public int Point;
    public List<Vector2> MonsterPos = new List<Vector2>();
    public string[][] Cost;
    // Use this for initialization
    private void Awake()
    {
        GM = this;
        IsStart = false;
        BallNum = 0;
        BallScale = 1;
        BallSpeed = 1;
        Point = 0;
        MonsterCount = 0;
    }

    void Start () {
        //计算屏幕高度
        float y = (float)750 / Screen.width * Screen.height;
        int yCount = (int)(y - 240) / 50;
        int boxY = (int)(y - yCount * 50) / 2 + 25;
        //开始动画
        GameObject obj = GameObject.Find("Ball0");
        Vector2 BallPosition = Camera.main.WorldToScreenPoint(obj.transform.position);
        Vector2 mDirection = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
        Vector2 nDirection = mDirection.normalized;
        //打开box
        obj.GetComponent<CircleCollider2D>().enabled = true;
        //发射
        obj.GetComponent<Rigidbody2D>().WakeUp();
        obj.GetComponent<Rigidbody2D>().AddForce(nDirection * (200 + BallSpeed * 200));
        //怪物坐标
        for (int i = 0; i < yCount; i++)
        {
            for (int j = 0; j <= 13; j++)
            {
                Vector2 pos = new Vector2(50 + j * 50, boxY + i * 50);
                float dis = Vector2.Distance(BallPosition, pos);
                if (dis>30)
                {
                    MonsterPos.Add(pos);
                }
            }
        }
        MonsterPos.Remove(new Vector2(0, 0));
        MonsterNum = MonsterPos.Count;
        //初始化数据
        TextAsset CSVtxt = Resources.Load("Data/Cost", typeof(TextAsset)) as TextAsset;
        //print(CSVtxt);
        string[] lineArr = CSVtxt.text.Split('\n');
        Cost = new string[lineArr.Length][];
        for (int i = 0; i < lineArr.Length; i++)
        {
            Cost[i] = lineArr[i].Split(' ');
        }

    }
	
	// Update is called once per frame
	void Update () {

	}

}