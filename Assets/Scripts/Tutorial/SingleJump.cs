using UnityEngine;

public class SingleJump : MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		Tutorial.Instance.showMessage("Press <Space> to jump");
	}

	private void OnTriggerExit(Collider other) {
		Tutorial.Instance.unShow();
	}
}
