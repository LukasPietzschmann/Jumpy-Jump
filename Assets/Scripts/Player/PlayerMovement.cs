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
	private int lastDirection = 1;

	void Update() {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (horizontalMove != 0)
			lastDirection = horizontalMove < 0 ? -1 : 1;
		if (Input.GetButtonDown("Jump"))
			jump = true;
		if (nextDash <= Time.time && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))) {
			dash = 3f;
			nextDash = Time.time + dashCooldownInSec;
		}
		if (enableAnim) {
			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
			animator.SetBool("Jump", jump);
		}

		float newDash = dash - dash * .05f;
		if (newDash >= 1f) {
			dash = newDash;
			horizontalMove = runSpeed * lastDirection;
		}
	}

	private void FixedUpdate() {
		controller.Move(horizontalMove * Time.fixedDeltaTime, dash, jump);
		jump = false;
	}
}