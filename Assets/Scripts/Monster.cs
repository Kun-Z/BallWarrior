using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour {
    public int Hp;
    public int Id;
    public AudioClip[] SoundClip;
    public AudioSource Sound;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RandomSound();
        int CurScale = (int)((collision.gameObject.transform.localScale.x - 1)*2+1);
        Hp -= CurScale;
        GameManager.GM.Point += CurScale;
        //判断按钮状态
        GameObject.Find("Canvas/BottomBar").SendMessage("AntiStatus");
        GameObject.Find("Canvas/TopBar/Point").GetComponent<Text>().text = GameManager.GM.Point.ToString();
        GetComponentInChildren<Text>().text = Hp.ToString();
        if (Hp <= 0)
        {
            Vector2 pos = gameObject.GetComponent<RectTransform>().anchoredPosition;
            GameManager.GM.MonsterPos.Add(pos);
            GameObject.Destroy(gameObject);
            GameObject.Find("Canvas/TopBar/Slider").SendMessage("SetSlide");
        }
    }

    private void RandomSound()
    {
        int index = Random.Range(0, SoundClip.Length);
        Sound.clip = SoundClip[index];
        Sound.volume = Random.Range(0.2f, 0.6f);
        Sound.Play();
    }
}
