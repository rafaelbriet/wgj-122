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

	[SerializeField] private Camera mainCamera;
	[SerializeField] private Camera menuCamera;

	private Runner player;
	private EnviromentAudioController enviromentAudioController;
	private HighscoreManager highscoreManager;

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
		player = FindObjectOfType<PlayerController>().GetComponent<Runner>();
		enviromentAudioController = FindObjectOfType<EnviromentAudioController>();
		highscoreManager = FindObjectOfType<HighscoreManager>();

		mainCamera.gameObject.SetActive(false);
		menuCamera.gameObject.SetActive(true);
	}

	private void Update()
	{
		if (StartCountdown == true)
		{
			mainCamera.gameObject.SetActive(true);
			menuCamera.gameObject.SetActive(false);

			if (HasRaceStarted == false)
			{
				RaceStartTimer -= Time.deltaTime;

				if (RaceStartTimer <= 0)
				{
					HasRaceStarted = true;
				}
			}
		}
		else
		{
			mainCamera.gameObject.SetActive(false);
			menuCamera.gameObject.SetActive(true);
		}

		if (HasRaceEnded() == true)
		{
			mainCamera.gameObject.SetActive(false);
			menuCamera.gameObject.SetActive(true);
		}
	}

	public void StartGame()
	{
		Cursor.lockState = CursorLockMode.Locked;
		StartCountdown = true;
	}

	public void EndGame()
	{
		Cursor.lockState = CursorLockMode.None;
		StartCountdown = false;
	}

	public void RestartGame()
	{
		highscoreManager.AddHighscore(player.RaceTime);
		highscoreManager.SaveHighscore();

		HasRaceStarted = false;
		StartCountdown = false;
		RaceStartTimer = 3f;

		foreach (Runner runner in Runners)
		{
			runner.RaceTime = 0;
			runner.HasFinishedRacing = false;
			runner.rb.velocity = Vector3.zero;
			runner.rb.angularVelocity = Vector3.zero;
			runner.transform.position = new Vector3(0, 0, runner.transform.position.z);
		}

		enviromentAudioController.cannonSoundplayed = false;
		enviromentAudioController.applauseSoundplayed = false;

		mainCamera.gameObject.SetActive(true);
		menuCamera.gameObject.SetActive(false);
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
