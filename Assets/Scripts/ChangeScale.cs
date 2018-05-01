using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnClick()
    {
        GameObject obj = GameObject.Find("Ball");
        Vector3 CurScale = obj.transform.localScale;
        print(CurScale);
        Vector3 NewScale = CurScale + new Vector3(0.1f, 0.1f, 0);
        obj.transform.localScale = NewScale;
    }
}
