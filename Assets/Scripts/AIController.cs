using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
	[SerializeField] private float maxSpeed = 3f;
	[SerializeField] private float minSpeed = 2.5f;
	private float speed;
	private bool canRun;
	[SerializeField] private float maxRunTimer = 0.1f;
	[SerializeField] private float minRunTimer = 0.01f;
	[SerializeField] private float canRunTimer;
	private Runner runner;

	private void Start()
	{
		runner = GetComponent<Runner>();
		speed = Random.Range(minSpeed, maxSpeed);
		canRunTimer = 0f;
		canRun = true;
	}

	private void Update()
	{
		canRunTimer -= Time.deltaTime;

		if (canRunTimer <= 0f)
		{
			canRun = true;
			canRunTimer = Random.Range(minRunTimer, maxRunTimer);
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
