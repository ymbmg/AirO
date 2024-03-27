using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
	
	[SerializeField]
	int worth;
	
	private bool isInAnimation = false;
	private float elapsedTime = 0f;
	private Vector3 scale;
	private GM gm;
	
	void Start()
	{
		scale = gameObject.transform.localScale;
		gm = GameObject.FindWithTag("GameManager").GetComponent<GM>();
	}
		
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("entered");
		if(isInAnimation)
		{
			return;
		}
		isInAnimation = true;
		//gm.AddScore(worth);
		Destroy(gameObject, 0.4f);
	}
	
	void Update()
	{
		if(isInAnimation)
		{
			transform.localScale = Mathf.Clamp(1f - 2.5f * elapsedTime, 0f, 1f) * scale;
			elapsedTime += Time.deltaTime;
		}
	}
	
}
