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
        Hp -= 1;
        GameManager.Point += 1;
        GameObject.Find("Canvas/Point").GetComponent<Text>().text = GameManager.Point.ToString();
        GetComponentInChildren<Text>().text = Hp.ToString();
        if (Hp == 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
