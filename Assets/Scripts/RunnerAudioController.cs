using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAudioController : MonoBehaviour
{
	[SerializeField] private AudioSource footsteps;

	private Runner runner;

	private void Start()
	{
		runner = GetComponent<Runner>();
	}

	void Update()
    {
		if (runner.rb.velocity.x > 0.1f && footsteps.isPlaying == false)
		{
			footsteps.Play();
		}

		if (runner.rb.velocity.x < 0.1f && footsteps.isPlaying == true)
		{
			footsteps.Stop();
		}
    }
}
