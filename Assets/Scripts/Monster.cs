using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Monster : MonoBehaviour {
    public int Hp;
    public int Id;
    public float BirthTime;
    AudioSource Sound;
    int TimeSpacing;
    float h;
	// Use this for initialization
	void Start () {
        Sound = gameObject.GetComponent<AudioSource>();
        BirthTime = Time.time;
        TimeSpacing = Random.Range(40,60);
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        if (Time.time-BirthTime > TimeSpacing)
        {
            h += 0.2f;
            RectTransform[] RectTransform = gameObject.GetComponentsInChildren<RectTransform>();
            if (h >= 46)
            {
                BirthTime = Time.time;
                Hp = Hp * 2;
                GetComponentInChildren<Text>().text = Hp.ToString();
                gameObject.GetComponent<RectTransform>().DOShakeScale(1);
                h = 0;
                TimeSpacing += 10;
                Sound.volume = 0.5f;
                Sound.Play();
            }
            RectTransform[1].sizeDelta = new Vector2(46,h);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int CurScale = (int)((collision.gameObject.transform.localScale.x - 1)*5+1);
        Hp -= CurScale;
        GameManager.GM.Point += CurScale;
        //判断按钮状态
        GameObject.Find("Canvas/BottomBar").SendMessage("AntiStatus");
        GetComponentInChildren<Text>().text = Hp.ToString();
        if (Hp <= 0)
        {
            Vector2 pos = gameObject.GetComponent<RectTransform>().anchoredPosition;
            GameManager.GM.MonsterPos.Add(pos);
            GameObject.Destroy(gameObject);
            GameObject.Find("Canvas/TopBar/Slider").SendMessage("SetSlide");
        }
    }
}
