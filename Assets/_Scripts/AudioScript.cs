using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	public AudioClip PlaceholderClip;
	public string CollisionTag = "";

	private AudioSource SoundSource;

	private void OnEnable(){
		SoundSource = GetComponent<AudioSource>();
	}
	
	private void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.CompareTag(CollisionTag) == true)
			SoundSource.PlayOneShot(PlaceholderClip);
	}

}
