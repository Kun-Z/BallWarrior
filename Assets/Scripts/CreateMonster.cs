﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMonster : MonoBehaviour {
    int Hp;
    int Rotation;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Create", 2.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Create()
    {
        GameManager.GM.MonsterCount += 1;
        //print("MonsterCount:" + GameManager.MonsterCount);
        GameObject obj = (GameObject)Resources.Load("Prefabs/Monster");
        GameObject Monster = Instantiate(obj);
        Hp = (GameManager.GM.MonsterCount/20+1)*Random.Range(10,20);
        //随机位置;
        int index = Random.Range(0, GameManager.GM.MonsterPos.Count);
        Vector2 NewPos = GameManager.GM.MonsterPos[index];
        Monster.GetComponent<RectTransform>().anchoredPosition = NewPos;
        GameManager.GM.MonsterPos.RemoveAt(index);
        //设置父级
        GameObject mFather = GameObject.Find("MonsterList");
        Monster.transform.SetParent(mFather.transform, false);
        //旋转怪物
        Rotation = Random.Range(0, 90);
        Monster.transform.Rotate(0, 0, Rotation);
        Monster.name = string.Concat("Monster", GameManager.GM.MonsterCount);
        Monster.GetComponent<Monster>().Hp = Hp;
        Monster.GetComponent<Monster>().Id = GameManager.GM.MonsterCount;
        Monster.GetComponentInChildren<Text>().text = Hp.ToString();
        Monster.GetComponentInChildren<Text>().transform.Rotate(0, 0, -Rotation);
        //设置进度条
        Slide();
    }

    private void Slide()
    {
        float rate = 1 - (GameManager.GM.MonsterPos.Count * 1.0f / GameManager.GM.MonsterNum);
        GameObject.Find("Canvas/TopBar/Slider").GetComponent<Slider>().value = rate;
        string str = (rate * 100).ToString("#0.0");
        GameObject.Find("Canvas/TopBar/Slider/Text").GetComponent<Text>().text = string.Concat(str, "%");
    }
}
