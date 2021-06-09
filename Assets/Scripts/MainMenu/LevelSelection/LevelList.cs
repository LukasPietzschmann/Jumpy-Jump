using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelList : MonoBehaviour {
    [SerializeField] private GameObject itemPrefab;
    void Start() {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++) {
            String name = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            GameObject container = Instantiate(itemPrefab, transform, false);
            container.name = name;
            container.GetComponentInChildren<Text>().text = name;
            var i1 = i;
            container.GetComponentInChildren<Button>().onClick.AddListener(() => SceneManager.LoadScene(i1));
        }
    }
}
