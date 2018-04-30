using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour {
    public List<GameObject> BallList = new List<GameObject>();
    // Use this for initialization
    void Start () {
		
	 }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach (GameObject Balls in BallList)
            {
                Vector2 mDirection = new Vector2(mTarget.x - Balls.transform.position.x, mTarget.y - Balls.transform.position.y);
                print(mDirection);
                Balls.GetComponent<Rigidbody2D>().AddForce(mDirection * 50);
            }
        }
    }
 }