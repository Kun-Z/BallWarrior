using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {
    Rigidbody2D rig;
    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        //print(rig.velocity);
    }


}
