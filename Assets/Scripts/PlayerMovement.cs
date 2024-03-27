using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	
	[SerializeField]
	GameObject player;
	
	[SerializeField]
	Rigidbody prb;
	
	float initialTime = 0f, stop = 0.5f;
	
	void Start()
	{
		
	}
	
	void Update()
	{
		transform.localEulerAngles = prb.velocity.normalized;
	}
	
	void FixedUpdate()
	{
		if(initialTime < stop)
		{
			prb.AddForce(150f * player.transform.up, ForceMode.Force);
		}
		initialTime += Time.fixedDeltaTime;
	}
	
	public bool ReadyForPlayerControl()
	{
		return initialTime >= stop;
	}
	
}
