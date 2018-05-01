using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMonster : MonoBehaviour {
    int MonsterCount = 0;
    int Hp;
    int Rotation;
    GameObject[] MonsterList;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Create", 2.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Create()
    {
        GameObject obj = (GameObject)Resources.Load("Prefabs/Monster");
        GameObject Monster = Instantiate(obj);
        MonsterCount += 1;
        Hp = 17;
        Monster.transform.position = new Vector2(Random.Range(-4.0f, 5.0f), Random.Range(-8.0f, 10.0f));
        Rotation = Random.Range(0, 90);
        Monster.transform.Rotate(0, 0, Rotation);
        Monster.name = string.Concat("Monster", MonsterCount);
        Monster.GetComponent<Monster>().Hp = Hp;
        Monster.GetComponent<Monster>().Id = MonsterCount;
        Monster.GetComponentInChildren<Text>().text = Hp.ToString();
        Monster.GetComponentInChildren<Text>().transform.Rotate(0, 0, -Rotation);
    }
}
