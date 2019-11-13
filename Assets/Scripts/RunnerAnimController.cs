using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAnimController : MonoBehaviour
{
	private Animator animator;
	private Runner runner;

	private void Start()
	{
		animator = GetComponentInChildren<Animator>();
		runner = GetComponent<Runner>();
	}

	private void Update()
	{
		if (GameManager.Instance.StartCountdown == true)
		{
			animator.SetBool("StartCountdown", true);
		}
		else
		{
			animator.SetBool("StartCountdown", false);
		}

		animator.SetFloat("RunnerVelocity", runner.rb.velocity.x);

		if (GameManager.Instance.HasRaceEnded())
		{
			animator.SetBool("RaceEnded", true);
		}
		else
		{
			animator.SetBool("RaceEnded", false);
		}
	}
}
