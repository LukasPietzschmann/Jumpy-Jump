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

	void Start() {
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
			if (Time.time < nextCharge)
				return;
			nextCharge += 2;
			rigidbody.AddForce(new Vector3(Random.Range(-800, 800) + myPos.x - targetPos.x,0,0), ForceMode.Acceleration);
		}else if (state == State.Found) {
			float motivation = Vector3.Distance(myPos, targetPos).Map(1, 6, maxMotivation, 1);
			transform.position = Vector3.MoveTowards(myPos, targetPos, speed * Time.deltaTime * motivation);
		}else if (state == State.Attack) {
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