using UnityEngine;
using UnityEngine.UI;

public class EnemyZone : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		Tutorial.Instance.showMessage("Avoid Enemies by jumping over them");
	}

	private void OnTriggerExit(Collider other) {
		Tutorial.Instance.unShow();
	}
}
