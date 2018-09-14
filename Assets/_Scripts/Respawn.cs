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

    public void OnGoalEnter()
    {
        body.velocity = Vector2.zero;
        body.isKinematic = true;
        trail.emitting = false;
        trail.time = 0;
        trail.Clear();
        body.position = StartPosition;
    }

    public void OnGoalExit()
    {
        StartCoroutine("ResetTrail", startTrailTime + 0.05);
    }

	IEnumerator ResetTrail(float t){
		yield return new WaitForSecondsRealtime(t);
		body.isKinematic = false;
		trail.time = startTrailTime;
		trail.emitting = true;
	}
}
