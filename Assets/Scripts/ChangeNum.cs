using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNum : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnClick()
    {
        GameObject obj = (GameObject)Resources.Load("Prefabs/Ball");
        GameObject NewBall = Instantiate(obj);
        string name = string.Concat("Ball", 1);
        NewBall.name = name;
        GameObject Ballobj = GameObject.Find("name");
        Vector3 CurDirection = Ballobj.GetComponent<Rigidbody2D>().velocity;
        print(CurDirection);
        Vector3 NewDirection = CurDirection.normalized;
        Ballobj.GetComponent<Rigidbody2D>().AddForce(NewDirection * 20);
    }
}
