using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	public AudioClip BumperClip, PaddleClip, WallClip, ScoreClip;

	private AudioSource SoundSource;

	private void OnEnable(){
		SoundSource = GetComponent<AudioSource>();
	}
	
	private void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.CompareTag("Bumper") == true)
			SoundSource.PlayOneShot(BumperClip);
        if (col.gameObject.CompareTag("Paddle") == true)
            SoundSource.PlayOneShot(PaddleClip);
        if (col.gameObject.CompareTag("Arena Wall") == true)
            SoundSource.PlayOneShot(WallClip);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal") == true)
            SoundSource.PlayOneShot(ScoreClip);
    }
}
