using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
	
	private int score = 0;
	//private TMP;
	
	void Start()
	{
		Physics.gravity = new Vector3(0, -9.8f, 0);
	}
	
	void UpdateScore()
	{
		//TODO: add UI elements to show score
	}
	
	public void AddScore(int incre)
	{
		score += incre;
		UpdateScore();
	}
	
}
