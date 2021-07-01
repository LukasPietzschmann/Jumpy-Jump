using System;
using UnityEngine;

public class Finish : MonoBehaviour {
	[SerializeField] private GameObject finishDialog;
	private void OnTriggerEnter(Collider other) {
		finishDialog.SetActive(true);
		GameManager.pause();
	}
}