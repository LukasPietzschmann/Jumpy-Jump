using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private PlayerController controller;
	[SerializeField] private float runSpeed = 40f;
	[SerializeField] private Animator animator;
	[SerializeField] private bool enableAnim = true;
	[SerializeField] private float dashCooldownInSec = 2f;

	private float horizontalMove = 0f;
	private float dash = 1f;
	private float nextDash = 0f;
	private bool jump = false;

	void Update() {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (Input.GetButtonDown("Jump"))
			jump = true;
		if (nextDash <= Time.time && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))) {
			dash = 5f;
			nextDash = Time.time + dashCooldownInSec;
		}
		if (enableAnim) {
			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
			animator.SetBool("Jump", jump);
		}

		float newDash = dash - dash * .05f;
		if (newDash >= 1f) {
			dash = newDash;
			horizontalMove = runSpeed;
		}
	}

	private void FixedUpdate() {
		controller.Move(horizontalMove * Time.fixedDeltaTime, dash, jump);
		jump = false;
	}
}