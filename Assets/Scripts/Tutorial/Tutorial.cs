using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
	[SerializeField] private GameObject tutorialtext;
	[SerializeField] private Animator animator;
	private static Tutorial instance;
	private static readonly int Show = Animator.StringToHash("show");

	public static Tutorial Instance { get { return instance; } }


	private void Awake() {
		if (instance != null && instance != this)
			Destroy(this.gameObject);
		else
			instance = this;
	}

	public void unShow() {
		animator.SetBool(Show, false);
		//tutorialtext.GetComponent<RectTransform>().localScale = Vector3.zero;
	}

	public void showMessage(string msg) {
		tutorialtext.GetComponent<Text>().text = msg;
		animator.SetBool(Show, true);
	}
}
