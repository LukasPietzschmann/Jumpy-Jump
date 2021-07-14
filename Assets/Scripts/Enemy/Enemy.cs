using System;
using System.Data.SqlTypes;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {

	enum State {
		Searching, Found, Attack
	}

	[SerializeField] private float lookRadius = 6f;
	[SerializeField] private float attackRadius = 5.5f;
	[SerializeField] private float speed = 2f;
	[SerializeField] [Range(2, 7)] private float maxMotivation;
	private State state;
	private Transform player;
	private Rigidbody rigidbody;
	private bool grounded;
	private float nextCharge = 0;
	private Animator animator;

	void Start() {
		animator = gameObject.GetComponent<Animator>();
		state = State.Searching;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update() {
		float distance = Vector3.Distance(transform.position, player.position);
		if (distance <= lookRadius && distance > attackRadius)
			state = State.Found;
		else if (distance <= attackRadius)
			state = State.Attack;
		else
			state = State.Searching;
	}

	private void FixedUpdate() {
		Vector3 myPos = transform.position;
		Vector3 targetPos = player.position;

		if (state == State.Searching) {
			if (Time.time < nextCharge){
				if(animator != null)
					animator.SetBool("walk", false);
				return;
			}
			nextCharge += 2;
			float direction = Random.Range(-600, 600) + myPos.x - targetPos.x;
			if (direction > 0) gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
			else if (direction < 0) gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
			rigidbody.AddForce(new Vector3(direction,0,0), ForceMode.Acceleration);
			if(animator != null)
				animator.SetBool("walk", true);
		}else if (state == State.Found) {
			float motivation = Vector3.Distance(myPos, targetPos).Map(1, 6, maxMotivation, 1);
			if (motivation > 0) gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
			else if (motivation < 0) gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
			transform.position = Vector3.MoveTowards(myPos, targetPos, speed * Time.deltaTime * motivation);
			if(animator != null)
				animator.SetBool("walk", true);
		}else if (state == State.Attack) {
			if(animator != null)
				animator.SetBool("walk", false);
			if(grounded) {
				//rigidbody.AddForce(new Vector3(0, 600f, 0));
				//grounded = false;
			}
		}
	}

	private void OnCollisionEnter(Collision other) {
		grounded = true;
	}

	private void OnCollisionExit(Collision other) {
		grounded = false;
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRadius);
	}
}