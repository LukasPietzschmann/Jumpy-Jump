using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEggMap2 : MonoBehaviour
{
	[SerializeField] private GameObject eastereggText;

	private void OnTriggerEnter(Collider other) {
		eastereggText.GetComponent<Text>().text = "Danke fürs finden Sascha. :D";
	}

	private void OnTriggerExit(Collider other) {
		eastereggText.GetComponent<Text>().text = "";
	}


}