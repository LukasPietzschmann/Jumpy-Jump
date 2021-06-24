using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
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
   
   
}
