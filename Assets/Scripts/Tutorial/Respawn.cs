using UnityEngine;

public class Respawn : MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		Tutorial.Instance.showMessage("Press <R> to respawn at a Fireplace");
	}

	private void OnTriggerExit(Collider other) {
		Tutorial.Instance.unShow();
	}
}