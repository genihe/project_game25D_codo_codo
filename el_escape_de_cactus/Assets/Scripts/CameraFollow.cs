using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public Transform target2;
	public bool lookAtPlayer;
	public float smothing = 6f;
	Vector3 offset;
	
	private void Start(){
		lookAtPlayer=true;
		offset = transform.position - target.position;
		//Debug.Log(offset);
	}
	private void FixedUpdate()
	{
		LookAtPlayer();
	}

	void LookAtPlayer(){
		if (lookAtPlayer){
			Vector3 targetCamPosition = target.position + offset;
			transform.position = Vector3.Lerp(transform.position , targetCamPosition, smothing * Time.deltaTime);  
		}else{
			transform.position = Vector3.Lerp(transform.position , new Vector3(-1.05f,0.95f,0.27f), smothing * Time.deltaTime);  
		}
	}

	public void CenterCamera(){
		lookAtPlayer=false;
	}


}
