using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour {
    public int Hp;
    public int Id;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int CurScale = (int)((collision.gameObject.transform.localScale.x - 1)*10+1);
        Hp -= CurScale;
        GameManager.Point += 1;
        if (int.Parse(GameManager.BallNumCost[GameManager.BallNum][1]) <= GameManager.Point)
        {
            GameObject.Find("Canvas/BottomBar/Num").GetComponent<Button>().interactable = true;
        }
        if (int.Parse(GameManager.BallScaleCost[GameManager.BallScale][1]) <= GameManager.Point)
        {
            GameObject.Find("Canvas/BottomBar/Scale").GetComponent<Button>().interactable = true;
        }
        GameObject.Find("Canvas/TopBar/Point").GetComponent<Text>().text = GameManager.Point.ToString();
        GetComponentInChildren<Text>().text = Hp.ToString();
        if (Hp <= 0)
        {
            Vector2 pos = gameObject.GetComponent<RectTransform>().anchoredPosition;
            GameManager.MonsterPos.Add(pos);
            GameObject.Destroy(gameObject);
        }
    }
}
