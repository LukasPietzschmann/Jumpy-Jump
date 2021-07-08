using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

   [SerializeField] private AudioMixer audioMixerVolume;
   [SerializeField] private Slider volSlider;

   private float oldVol;

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
