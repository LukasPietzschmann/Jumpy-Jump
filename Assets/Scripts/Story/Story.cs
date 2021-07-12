using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour {
	[SerializeField] private GameObject storytext;
	[SerializeField] private Animator animator;
	private static Story instance;
	private static readonly int Show = Animator.StringToHash("show");

	public static Story Instance { get { return instance; } }


	private void Awake() {
		animator.gameObject.SetActive(false);
		if (instance != null && instance != this)
			Destroy(this.gameObject);
		else
			instance = this;
	}

	public void unShow() {
		animator.SetBool(Show, false);
		//storytext.GetComponent<RectTransform>().localScale = Vector3.zero;
	}

	public void showMessage(string msg) {
		animator.gameObject.SetActive(true);
		storytext.GetComponent<Text>().text = msg;
		animator.SetBool(Show, true);
	}
}
