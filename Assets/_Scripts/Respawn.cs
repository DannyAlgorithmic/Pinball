using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	private Vector2 StartPosition;
	private Rigidbody2D body;
	private TrailRenderer trail;
	float startTrailTime;

	private void OnEnable(){
		StartPosition = transform.position;
		body = GetComponent<Rigidbody2D>();
		trail = GetComponent<TrailRenderer>();
		startTrailTime = trail.time;
	}

	private void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Respawner")){
			body.velocity = Vector2.zero;
			body.isKinematic = true;
			trail.emitting = false;
			trail.time = 0;
			trail.Clear();
			body.MovePosition(StartPosition);
			// Debug.Log(trail.positionCount);
			// Debug.Log("Respawned");
		}
	}

	private void OnTriggerExit2D(Collider2D col){
		if(col.CompareTag("Respawner")){
			StartCoroutine("ResetTrail", startTrailTime + 0.05);
		}
	}

	IEnumerator ResetTrail(float t){
		yield return new WaitForSecondsRealtime(t);
		body.isKinematic = false;
		trail.time = startTrailTime;
		trail.emitting = true;
	}
}
