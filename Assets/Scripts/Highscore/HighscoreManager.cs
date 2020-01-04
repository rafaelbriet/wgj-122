using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
	public List<HighscoreEntry> Highscores { get; private set; } = new List<HighscoreEntry>();

	private void Awake()
	{
		LoadHighscore();

		if (Highscores.Count == 0)
		{
			Highscores.Add(new HighscoreEntry(13f));
			Highscores.Add(new HighscoreEntry(15f));
			Highscores.Add(new HighscoreEntry(15f));
			Highscores.Add(new HighscoreEntry(10f));
			Highscores.Add(new HighscoreEntry(11f));
			Highscores.Add(new HighscoreEntry(14f));

			SaveHighscore();
		}
	}

	public void AddHighscore(float time)
	{
		Highscores.Add(new HighscoreEntry(time));
	}

	public void LoadHighscore() {
		string json = PlayerPrefs.GetString("Highscores");
		HighscoreList highscoreList = JsonUtility.FromJson<HighscoreList>(json);

		if (highscoreList == null)
		{
			return;
		}

		foreach (HighscoreEntry entry in highscoreList.Highscores)
		{
			Highscores.Add(entry);
		}
	}

	public void SaveHighscore() {

		Highscores.Sort();
		Highscores.RemoveAt(5);

		HighscoreList highscoreList = new HighscoreList { Highscores = Highscores };
		string json = JsonUtility.ToJson(highscoreList);

		PlayerPrefs.SetString("Highscores", json);
		PlayerPrefs.Save();
	}
}
