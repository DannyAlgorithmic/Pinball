using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	private Vector2 StartPosition;
	private Rigidbody2D body;

	private void OnEnable(){
		StartPosition = transform.position;
		body = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Respawner")){
			body.position = StartPosition;
			body.velocity = Vector2.zero;
			// Debug.Log("Respawned");
		}
	}
}
