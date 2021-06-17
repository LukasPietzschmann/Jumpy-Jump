using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float jumpForce = 700f;
	[SerializeField] private float speed = 10f;
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
	[SerializeField] private bool airControl = true;
	[SerializeField] private bool doubleJump = true;
	[SerializeField] private KeyCode respawnKey = KeyCode.R;

	private Transform lastCheckpoint;

	private Rigidbody rigidbody;
	private Vector3 velocity = Vector3.zero;
	private bool isGrounded = false;
	private int jumpCount = 0;

	private void Awake() {
		rigidbody = GetComponent<Rigidbody>();
	}

	private void Update() {
		if (Input.GetKeyDown(respawnKey) && lastCheckpoint != null)
			transform.position = lastCheckpoint.position;
	}

	public void Move(float move, float dash, bool jump) {
		if(move > 0)
			gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
		else if(move < 0)
			gameObject.transform.eulerAngles = Vector3.zero;
		if(isGrounded || airControl) {
			rigidbody.constraints = dash <= 0.01 ? RigidbodyConstraints.FreezePositionY | rigidbody.constraints : RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
			Vector3 rigidbodyVel = rigidbody.velocity;
			Vector3 targetVelocity = new Vector3(move * speed * dash, rigidbodyVel.y, 0);
			rigidbody.velocity = Vector3.SmoothDamp(rigidbodyVel, targetVelocity, ref velocity, movementSmoothing);
		}
		if(jump && ((doubleJump && jumpCount < 2) || isGrounded)) {
			jumpCount++;
			isGrounded = false;
			rigidbody.AddForce(new Vector3(0f, jumpForce, 0f));
		}
	}

	private void OnCollisionEnter(Collision other) {
		jumpCount = 0;
		isGrounded = true;
		if (other.gameObject.CompareTag("Enemy")) {
			Debug.Log("Dead");
		}
	}

	private void OnTriggerEnter(Collider collider) {
		if(collider.CompareTag("Checkpoint")) {
			for (int i = 0; i < collider.gameObject.transform.childCount; i++) {
				Transform child = collider.gameObject.transform.GetChild(i);
				if (child.CompareTag("Checkpoint")) {
					lastCheckpoint = child;
					Debug.Log("Checkpoint set to " + lastCheckpoint);
					break;
				}
			}
		}else if (collider.CompareTag("Finish")) {
			Debug.Log("Finish");
		}
	}
}