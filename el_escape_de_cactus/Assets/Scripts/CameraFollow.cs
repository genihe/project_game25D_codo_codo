using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public bool lookAtPlayer;
	public float smothing = 6f;
	Vector3 offset;
	
	private void Start(){
		lookAtPlayer=true;
		offset = transform.position - target.position;
		Debug.Log(offset);
	}
	private void FixedUpdate()
	{
		LookAtPlayer();
	}

	void LookAtPlayer(){
		if (lookAtPlayer){
			Vector3 targetCamPosition = target.position + offset;
			transform.position = Vector3.Lerp(transform.position , targetCamPosition, smothing * Time.deltaTime);  
		}
	}
}
