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

	[SerializeField] private GameObject raceScreen;
	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject endMenu;
	[SerializeField] private GameObject highscoreScreen;
	[SerializeField] private GameObject highscoreTextParent;
	[SerializeField] private GameObject highscoreTextPrefab;
	[SerializeField] private GameObject newHighscoreText;
	[SerializeField] private Camera menuCamera;

	private Runner player;
	private HighscoreManager highscoreManager;

	private void Start()
	{
		player = FindObjectOfType<PlayerController>().GetComponent<Runner>();
		highscoreManager = FindObjectOfType<HighscoreManager>();

		UpdateHighscoreDisplay();
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
	}

	public void UIStartRace()
	{
		GameManager.Instance.StartGame();

		mainMenu.SetActive(false);
		raceScreen.SetActive(true);
	}

	public void UIEndrace()
	{
		GameManager.Instance.EndGame();

		if (player.RaceTime < highscoreManager.Highscores[0].Time)
		{
			newHighscoreText.SetActive(true);
		}
		else
		{
			newHighscoreText.SetActive(false);
		}

		raceScreen.SetActive(false);
		countdownText.CrossFadeAlpha(1f, 0, true);
		endMenu.SetActive(true);
		raceTimeFinalText.text = player.RaceTime.ToString("F3", CultureInfo.InvariantCulture);
	}

	public void UIHighscoreScreen()
	{
		UpdateHighscoreDisplay();
		highscoreScreen.SetActive(true);
		mainMenu.SetActive(false);
		menuCamera.orthographicSize = 0.45f;
	}

	public void UIBackHighscore()
	{
		mainMenu.SetActive(true);
		highscoreScreen.SetActive(false);
		menuCamera.orthographicSize = 1.5f;
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

	private void UpdateHighscoreDisplay()
	{
		foreach (Transform t in highscoreTextParent.transform)
		{
			Destroy(t.gameObject);
		}

		foreach (HighscoreEntry highscore in highscoreManager.Highscores)
		{
			GameObject go = Instantiate(highscoreTextPrefab, highscoreTextParent.transform);
			TextMeshProUGUI text = go.GetComponentInChildren<TextMeshProUGUI>();
			text.text = highscore.Time.ToString("F3", CultureInfo.InvariantCulture);
		}
	}
}
