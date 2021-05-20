using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private PlayerController controller;
	[SerializeField] private float runSpeed = 40f;
	[SerializeField] private Animator animator;

	private float horizontalMove = 0f;
	private bool jump = false;

	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (Input.GetButtonDown("Jump"))
			jump = true;
		
		//animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		//animator.SetBool("Jump", jump);
	}

	private void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}