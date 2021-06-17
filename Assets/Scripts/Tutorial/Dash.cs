using UnityEngine;

public class Dash : MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		Tutorial.Instance.showMessage("Press <Shift> to dashd");
	}

	private void OnTriggerExit(Collider other) {
		Tutorial.Instance.unShow();
	}
}