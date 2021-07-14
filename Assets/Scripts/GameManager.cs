using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] private AudioMixer audioMixerVolume;
	[SerializeField] private Slider volSlider;
	[SerializeField] private GameObject pauseMenu;

	private float oldVol;
	private bool paused = false;

	private static Vector3[] originalPosition;
	public static GameObject[] enemies;

	void Start(){
		float val;
		bool result = audioMixerVolume.GetFloat("MasterVolume", out val);
		if(result)
			volSlider.value = val;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if(enemies != null){
			originalPosition = new Vector3[enemies.Length];
			for(int i = 0; i < enemies.Length; i++)
				originalPosition[i] = enemies[i].transform.position;
		}
	}


	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (paused) {
				pauseMenu.SetActive(false);
				unPause();
			}
			else {
				pauseMenu.SetActive(true);
				pause();
			}

			paused = !paused;
		}
	}

	public static void respawnEnemies(){
		for(int i = 0; i < originalPosition.Length; i++)
			enemies[i].transform.position = originalPosition[i];
	}

	public static void pause() {
		Time.timeScale = 0;
	}

	public static void unPause() {
		Time.timeScale = 1;
	}

	public static void loadMainMenu() {
		loadScene(0);
	}

	public static void loadScene(int index) {
		SceneManager.LoadScene(index);
	}

	public void setVolume(float input) {
		audioMixerVolume.SetFloat("MasterVolume", volSlider.value);
	}

	public void mute(Toggle muteToggle){
		if(muteToggle.isOn){
			oldVol = volSlider.value;
			volSlider.value = volSlider.minValue;
			volSlider.interactable = false;
		}
		else{
			volSlider.value = oldVol;
			volSlider.interactable = true;
		}
		setVolume(0);
	}
}
