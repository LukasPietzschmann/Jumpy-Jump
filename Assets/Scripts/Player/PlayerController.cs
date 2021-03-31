using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float jumpForce = 400f;
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
	[SerializeField] private bool airControl = true;
	[SerializeField] private bool doubleJump = true;

	private Rigidbody rigidbody;
	private Vector3 velocity = Vector3.zero;
	private bool isGrounded = false;
	private int jumpCount = 0;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	public void Move(float move, bool jump)
	{
		if(isGrounded || airControl)
		{
			Vector3 targetVelocity = new Vector3(move * 10f, rigidbody.velocity.y, 0);
			rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref velocity, movementSmoothing);
		}
		if(jump && ((doubleJump && jumpCount < 2) || isGrounded))
		{
			jumpCount++;
			isGrounded = false;
			rigidbody.AddForce(new Vector3(0f, jumpForce, 0f));
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		jumpCount = 0;
		isGrounded = true;
	}
}