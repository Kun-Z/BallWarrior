using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetChildren : MonoBehaviour {
    public Transform[] Children;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    [ContextMenu("All Children")]
    public void DoSomething()
    {
        Children = GetComponentsInChildren<Transform>();
    }
}
