using UnityEngine;

public class DoubleJump : MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		Tutorial.Instance.showMessage("Press <Space> twice to double-jump");
	}

	private void OnTriggerExit(Collider other) {
		Tutorial.Instance.unShow();
	}
}
