using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {
    public float VSpeed;
    public float HSpeed;
    public Rigidbody rig;
    Vector3 moveVSpeed;
    Vector3 moveHSpeed;
    Vector3 moveSpeed;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
        moveVSpeed = new Vector3(0, VSpeed,0);
        moveHSpeed = new Vector3(HSpeed,0,0);
        rig.velocity = moveVSpeed + moveHSpeed;
    }
	
	// Update is called once per frame
	void Update ()
    {
        moveSpeed = rig.velocity;
        transform.position += moveSpeed * Time.deltaTime;
    }

}
