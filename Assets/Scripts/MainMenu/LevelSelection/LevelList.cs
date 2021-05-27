using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Scene = UnityEngine.SceneManagement.Scene;

public class LevelList : MonoBehaviour {
    [SerializeField] private GameObject sceneList;
    void Start() {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
            Scene scene = SceneManager.GetSceneByBuildIndex(i);
            GameObject text = new GameObject();
            text.transform.position = Vector3.zero;
            text.AddComponent<TextMeshPro>().text = scene.name ?? "undef";
            text.transform.SetParent(sceneList.transform, false);
        }
    }
}
