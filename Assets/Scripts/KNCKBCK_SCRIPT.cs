using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KNCKBCK_SCRIPT : MonoBehaviour
{
	Vector3 pushDirection;

	//gets rigid body
	public Rigidbody2D rb;
	//knockback bool
	public bool knockBack;
	//thrust force added
	public float upwardThrust;
	public float directionatalthrust;
	// Use this for initialization
	void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		knocked();
	}


	void knocked()
	{
		//makes knockback happen when equal true
		if (knockBack== true)
		{
			knockBack = false;
			//if intfont of player make - thrust if behind player make thrust

			rb.AddForce(pushDirection * 100);
			//rb.AddForce(transform.up * upwardThrust);
		}

	}	
}
