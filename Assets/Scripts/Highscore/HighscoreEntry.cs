using System;

[Serializable]
public class HighscoreEntry : IComparable<HighscoreEntry>
{
	public float Time;

	public HighscoreEntry(float time)
	{
		this.Time = time;
	}

	public int CompareTo(HighscoreEntry other)
	{
		return Time.CompareTo(other.Time);
	}
}
