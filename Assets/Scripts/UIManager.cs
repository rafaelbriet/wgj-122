using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class UIManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI countdownText;
	[SerializeField] private TextMeshProUGUI raceTimeText;
	[SerializeField] private TextMeshProUGUI raceTimeFinalText;
	[SerializeField] private TextMeshProUGUI newRecordText;

	[SerializeField] private GameObject raceScreen;
	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject endMenu;

	private Runner player;

	private void Start()
	{
		player = FindObjectOfType<PlayerController>().GetComponent<Runner>();
	}

	private void Update()
	{
		if (GameManager.Instance.RaceStartTimer > 0f)
		{
			countdownText.text = GameManager.Instance.RaceStartTimer.ToString("F1");
		}
		else
		{
			countdownText.text = "GO!";
			countdownText.CrossFadeAlpha(0, 0.2f, false);
		}

		raceTimeText.text = player.RaceTime.ToString("F3", CultureInfo.InvariantCulture);

		if (GameManager.Instance.HasRaceEnded() == true)
		{
			UIEndrace();
		}

		newRecordText.CrossFadeAlpha(0, 0.1f, false);
		newRecordText.CrossFadeAlpha(1, 0.1f, false);
	}

	public void UIStartRace()
	{
		GameManager.Instance.StartCountdown = true;

		mainMenu.SetActive(false);
		raceScreen.SetActive(true);
	}

	public void UIEndrace()
	{
		GameManager.Instance.StartCountdown = false;

		raceScreen.SetActive(false);
		countdownText.CrossFadeAlpha(1f, 0, true);
		endMenu.SetActive(true);
		raceTimeFinalText.text = player.RaceTime.ToString("F3", CultureInfo.InvariantCulture);
	}

	public void MainMenu()
	{
		GameManager.Instance.RestartGame();

		mainMenu.SetActive(true);
		raceScreen.SetActive(false);
		endMenu.SetActive(false);
	}

	public void UIRestartGame()
	{
		GameManager.Instance.RestartGame();
		GameManager.Instance.StartCountdown = true;

		raceScreen.SetActive(true);
		endMenu.SetActive(false);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
