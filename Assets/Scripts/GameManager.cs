using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int MonsterCount = 0;
    public static int BallNum = 1;
    public static int BallScale = 1;
    public static bool  IsStart = true;
    public static int Point = 0;
    public static List<Vector2> MonsterPos;
    public static string[][] BallNumCost;
    public static string[][] BallScaleCost;
    TextAsset CSVtxt;
    string[] lineArr;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                Vector2 pos = new Vector2(-5 + j, -12 + i);
                print(pos);
                MonsterPos.Add(pos);
            }
        }
        print(MonsterPos);
        CSVtxt = Resources.Load("Data/BallNum_cost.csv", typeof(TextAsset)) as TextAsset;
        lineArr = CSVtxt.text.Split("\r"[0]);
        BallNumCost = new string[lineArr.Length][];
        for (int i = 0; i < lineArr.Length; i++)
        {
            BallNumCost[i] = lineArr[i].Split(',');
        }
        CSVtxt = Resources.Load("Data/BallScale_cost.csv", typeof(TextAsset)) as TextAsset;
        lineArr = CSVtxt.text.Split("\r"[0]);
        BallScaleCost = new string[lineArr.Length][];
        for (int i = 0; i < lineArr.Length; i++)
        {
            BallScaleCost[i] = lineArr[i].Split(',');
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}