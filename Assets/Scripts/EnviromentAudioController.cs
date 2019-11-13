using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentAudioController : MonoBehaviour
{
	[SerializeField] private AudioSource applauseAudioSource;
	[SerializeField] private AudioSource cannonAudioSource;

	[SerializeField] private AudioClip applauseClip;
	[SerializeField] private AudioClip cannonClip;

	[HideInInspector] public bool cannonSoundplayed = false;
	[HideInInspector] public bool applauseSoundplayed = false;

	// Update is called once per frame
	void Update()
    {
		if (GameManager.Instance.RaceStartTimer <= 0f && cannonAudioSource.isPlaying == false && cannonSoundplayed == false)
		{
			cannonAudioSource.PlayOneShot(cannonClip, 1f);
			cannonSoundplayed = true;
		}

		if (GameManager.Instance.StartCountdown == true && cannonAudioSource.isPlaying == false && applauseSoundplayed == false)
		{
			applauseAudioSource.PlayOneShot(applauseClip, 1f);
			applauseSoundplayed = true;
		}
	}
}
