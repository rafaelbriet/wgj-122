using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
	private Rigidbody rb;
	private bool run;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void Run(float speed)
	{
		if (rb.velocity.x <= 20f)
		{
			rb.AddForce(Vector3.right * speed, ForceMode.VelocityChange);
		}
	}
}
