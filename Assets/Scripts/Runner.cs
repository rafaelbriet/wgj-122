using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
	public float RaceTime;
	public bool HasFinishedRacing;

	public Rigidbody rb { get; private set; }
	private bool run;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		RaceTime = 0;
		GameManager.Instance.Runners.Add(this);
		HasFinishedRacing = false;
	}

	private void Update()
	{
		if (transform.position.x > GameManager.Instance.RaceLength)
		{
			HasFinishedRacing = true;
		}

		if (GameManager.Instance.HasRaceStarted == true && HasFinishedRacing == false)
		{
			RaceTime += Time.deltaTime;
		}
	}

	public void Run(float speed)
	{
		if (rb.velocity.x <= 20f)
		{
			rb.AddForce(Vector3.right * speed, ForceMode.VelocityChange);
		}
	}
}
