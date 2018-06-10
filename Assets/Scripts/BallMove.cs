using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {
    public AudioClip[] SoundClip;
    AudioSource Sound;
    // Use this for initialization
    void Start () {
        Sound = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            return;
        }
        RandomSound();
    }

    private void RandomSound()
    {
        int index = Random.Range(0, SoundClip.Length);
        Sound.clip = SoundClip[index];
        float volume = 0.8f - GameManager.GM.BallNum * 0.3f;
        if (volume > 0.1f)
        {
            Sound.volume = volume;
        }
        else
        {
            Sound.volume = 0.05f;
        }
        Sound.Play();
    }
}
