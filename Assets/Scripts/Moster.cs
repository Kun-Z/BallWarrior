using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moster : MonoBehaviour {
    public int Hp;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hp -= 1;
        if (Hp == 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
