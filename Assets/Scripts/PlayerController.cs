using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float speed = 3f;
	private bool canRun;

	private Runner runner;

	private void Start()
	{
		runner = GetComponent<Runner>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			canRun = true;
		}
	}

	private void FixedUpdate()
	{
		if (canRun == true)
		{
			runner.Run(speed);

			canRun = false;
		}
	}
}
