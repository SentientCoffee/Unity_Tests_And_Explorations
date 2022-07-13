using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour {
	public AudioMixer masterMixer;

	float sfxLvl = 0f;
	float musicLvl = 0f;

	public void SetSfxLvl(float sfxLvl) {
		masterMixer.SetFloat ("sfxVol", sfxLvl);
	}

	public void SetMusicLvl(float musicLvl) {
		masterMixer.SetFloat ("musicVol", musicLvl);
	}

	public void SetAudioToggle(bool test) {
		if (test == true) {
			SetSfxLvl (sfxLvl);
			SetMusicLvl (musicLvl);
		}
		else {
			SetSfxLvl (-80f);
			SetMusicLvl (-80f);
		}
	}
}
