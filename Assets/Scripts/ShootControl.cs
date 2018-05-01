using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControl : MonoBehaviour {
    public List<GameObject> BallList = new List<GameObject>();
    bool IsStart = true;
    // Use this for initialization
    void Start () {
		
	 }

    // Update is called once per frame
    void Update()
    {
        if (IsStart)
        {
            if (Input.GetMouseButtonUp(0))
            {
                IsStart = false;
                Vector2 mTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                foreach (GameObject Balls in BallList)
                {
                    Vector2 mDirection = new Vector2(mTarget.x - Balls.transform.position.x, mTarget.y - Balls.transform.position.y);
                    Vector2 nDirection = mDirection.normalized;
                    print(nDirection);
                    Balls.GetComponent<Rigidbody2D>().AddForce(nDirection * 20);
                }
            }
        }
    }
 }