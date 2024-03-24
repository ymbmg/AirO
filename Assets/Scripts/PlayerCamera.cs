using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	[SerializeField]
	GameObject player;
	
	[SerializeField]
	Rigidbody prb;
	
	float accumT = 0f, dir = 1f, horizVelo = 0f; 
	
	void Start()
	{
		prb.velocity = new Vector3(0f, 4.15f, 0) + player.transform.forward;
		gameObject.transform.position = player.transform.position - 4 * Vector3.left;
	}
	
	void Update()
	{
		dir = Input.GetAxis("Horizontal");
		if(dir != 0)
		{
			accumT = Mathf.Clamp(accumT + dir * Time.deltaTime, -1.5f, 1.5f);
		}
		else
		{
			accumT = Mathf.Clamp(accumT + (accumT > 0 ? Mathf.Clamp(-1f * Time.deltaTime, -1f * accumT, 0f) : Mathf.Clamp(Time.deltaTime, 0f, -1f * accumT)), -1.5f, 1.5f);  
		}
		player.transform.Rotate(20 * Vector3.up * accumT * Time.deltaTime);
		prb.AddForce(0.9f * player.transform.forward + accumT * 0.5f * player.transform.right, ForceMode.Force);
		if(prb.velocity.magnitude >= 15f)
		{
			prb.velocity = prb.velocity.normalized * 15f;
		}
		gameObject.transform.position = 1.5f * Vector3.up + player.transform.position - 4 * player.transform.forward;
		gameObject.transform.LookAt(player.transform.position);
	}
	
}
