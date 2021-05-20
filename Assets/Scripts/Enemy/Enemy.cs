using System;
using DefaultNamespace;
using UnityEngine;

public class Enemy : MonoBehaviour {
	enum State {
		Searching, Attack
	}

	[SerializeField] private Collider fov;
	[SerializeField] private float speed = 2f;
	[SerializeField] [Range(2, 7)] private float maxMotivation;
	private State state;
	private Transform player;

	void Start() {
		state = State.Searching;
	}

	void Update() {
		if(state == State.Attack) {
			var myPos = transform.position;
			var targetPos = player.position;
			float motivation = Vector3.Distance(myPos, targetPos).Map(1, 4, maxMotivation, 1);
			transform.position = Vector3.MoveTowards(myPos, targetPos, speed * Time.deltaTime * motivation);
		}else {
			
		}
	}

	private void OnTriggerEnter(Collider collider) {
		if (!collider.CompareTag("Player"))
			return;
		player = collider.gameObject.transform;
		state = State.Attack;
	}

	private void OnTriggerExit(Collider collider) {
		if (!collider.CompareTag("Player"))
			return;
		state = State.Searching;
		player = null;
	}
}