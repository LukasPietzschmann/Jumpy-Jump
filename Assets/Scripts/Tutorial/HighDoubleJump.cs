using UnityEngine;
using UnityEngine.UI;

public class HighDoubleJump : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		Tutorial.Instance.showMessage("To jump higher quickly press the spacebar twice.");
	}

	private void OnTriggerExit(Collider other) {
		Tutorial.Instance.unShow();
	}
}
