using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[HideInInspector] public static GameManager Instance;

	public bool HasRaceStarted;
	public bool StartCountdown;
	public float RaceStartTimer = 3f;
	public int RaceLength = 100;
	public List<Runner> Runners = new List<Runner>();

	private EnviromentAudioController enviromentAudioController;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}

		HasRaceStarted = false;
		StartCountdown = false;
	}

	private void Start()
	{
		enviromentAudioController = FindObjectOfType<EnviromentAudioController>();
	}

	private void Update()
	{
		if (StartCountdown == true)
		{
			if (HasRaceStarted == false)
			{
				RaceStartTimer -= Time.deltaTime;

				if (RaceStartTimer <= 0)
				{
					HasRaceStarted = true;
				}
			}
		}	
	}

	public void RestartGame()
	{
		HasRaceStarted = false;
		StartCountdown = false;
		RaceStartTimer = 3f;

		foreach (Runner runner in Runners)
		{
			runner.RaceTime = 0;
			runner.HasFinishedRacing = false;
			runner.transform.position = new Vector3(0, 0, runner.transform.position.z);
		}

		enviromentAudioController.cannonSoundplayed = false;
		enviromentAudioController.applauseSoundplayed = false;
	}

	public bool HasRaceEnded()
	{
		foreach (Runner runner in Runners)
		{
			if (runner.HasFinishedRacing == false)
			{
				return false;
			}
		}

		return true;
	}
}
