using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int MonsterCount = 0;
    public static int BallNum = 1;
    public static int BallScale = 1;
    public static bool  IsStart = true;
    public static int Point = 0;
    public static List<Vector2> MonsterPos = new List<Vector2>();
    public static string[][] BallNumCost;
    public static string[][] BallScaleCost;
    // Use this for initialization
    void Start () {
        for (int i = 0; i <= 20; i++)
        {
            for (int j = 0; j <= 12; j++)
            {
                Vector2 pos = new Vector2(-6 + j, -10 + i);
                MonsterPos.Add(pos);
            }
        }
        MonsterPos.Remove(new Vector2(0, 0));

        TextAsset CSVtxt1 = Resources.Load("Data/BallNum_cost", typeof(TextAsset)) as TextAsset;
        //print(CSVtxt1);
        string[] lineArr1 = CSVtxt1.text.Split('\n');
        BallNumCost = new string[lineArr1.Length][];
        for (int i = 0; i < lineArr1.Length; i++)
        {
            BallNumCost[i] = lineArr1[i].Split(' ');
        }
        TextAsset CSVtxt2 = Resources.Load("Data/BallScale_cost", typeof(TextAsset)) as TextAsset;
        //print(CSVtxt2);
        string[] lineArr2 = CSVtxt2.text.Split('\n');
        BallScaleCost = new string[lineArr2.Length][];
        for (int i = 0; i < lineArr2.Length; i++)
        {
            BallScaleCost[i] = lineArr2[i].Split(' ');
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (MonsterPos.Count < 10)
        {
            Time.timeScale = 0.0f;
        }
	}
}