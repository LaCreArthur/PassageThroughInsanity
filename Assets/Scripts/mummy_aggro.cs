using UnityEngine;
using System.Collections;

public class mummy_aggro : MonoBehaviour {
	public Transform[] waypoints;
	public GameObject player;
	public float lookAroundDuration, viewDistance, fov;

	bool aggro;
	float timer;
	Animator anim;
	int waypoint, nextWaypoint;
	Vector3 position, target;
	UnityEngine.AI.NavMeshAgent agent;
	int inMovementHash;

	float yStill;

	bool still;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		inMovementHash = Animator.StringToHash ("in_movement");
		still = (waypoints.Length == 1);
		waypoint = 0;
		target = waypoints [0].position;
		aggro = false;

		if (still) {
			// Just drop the mob at the specified point
			GetComponent<Rigidbody> ().position = target;
			anim.SetBool (inMovementHash, false); 
		}
		else {
			anim.SetBool (inMovementHash, true);
			agent.SetDestination (target);
		}

		//yStill = GetComponent.po
		position = GetComponent<Transform> ().position;
		yStill = position.y;

		Debug.Log (gameObject.name +  " ready");
	}
	
	// Update is called once per frame
	void Update () {
		position = GetComponent<Transform> ().position;
		if (still && !aggro) {
			Vector3 v = GetComponent<Transform> ().position;
			v.y = yStill;
			GetComponent<Transform> ().position = v;
		}
		else if (aggro) {
			Debug.Log (gameObject.name +  " player has aggro");
			if (scanPlayer ()) {
				updatePlayerTarget ();
			} else if (!agent.enabled) {
				waitLookAround ();
			}
			// Former player position reached, but player was lost.
			// Look around for a couple seconds and resume patrol.
			else if ((position - waypoints[waypoint].position).magnitude < 1f) {
				Debug.Log (gameObject.name +  " : Player lost...");
				aggro = false;
				switchTargets ();
				beginLookAround ();
			}
		}
		// Else, the mummy is patrolling
		else {
			// First, look for player
			if (scanPlayer ()) {
				// Player found! Set new target, enter aggro mode and wait for next update
				Debug.Log (gameObject.name +  " : Player found! Entering aggro mode.");
				updatePlayerTarget();
				aggro = true;
				return;
			}
			// Switch targets when target reached
			if (!agent.enabled) {
				waitLookAround ();
			}
			// Target reached : start looking around for the specified duration, then move to next waypoint
			else if (!still && (position - target).magnitude < 1f) {
				Debug.Log (gameObject.name +  " : Hit waypoint" + waypoint);
				switchTargets ();
				beginLookAround ();
			} 
		}
	}

	// Test if the player is in view
	bool scanPlayer() {
		Vector3 dir = player.GetComponent<Transform>().position - transform.position;
		RaycastHit hit;
		if (Physics.Raycast (transform.position, dir, out hit, viewDistance)) {
			if (hit.collider.gameObject == player && Vector3.Angle(transform.forward, dir) <= fov) {
				return true;
			}
		}
		return false;
	}

	// Stay in lookaround mode until timer is elapsed
	void beginLookAround() {
		anim.SetBool (inMovementHash, false);
		agent.enabled = false;
		timer = lookAroundDuration;

		yStill = GetComponent<Transform> ().position.y;
	}

	// Decrease the lookaround timer and set the mob back in motion when timer is up
	void waitLookAround() {
		Vector3 v = GetComponent<Transform> ().position;
		v.y = yStill;
		GetComponent<Transform> ().position = v;
		timer -= Time.deltaTime;
		if (timer < 0) {
			anim.SetBool (inMovementHash, true);
			agent.enabled = true;
			agent.SetDestination (target);
		}
	}

	// Update current destination with player position
	void updatePlayerTarget() {
		target = player.GetComponent<Transform>().position;
		agent.SetDestination (target);
		Debug.Log (gameObject.name +  " : Targeting player at " + target.ToString());
	}

	// Set the target to the next patrol waypoint
	void switchTargets() {
		if (!still) {
			++waypoint;
			if (waypoint >= waypoints.Length)
				waypoint = 0;
		}
		Debug.Log (gameObject.name +  " : Going to waypoint " + waypoint);
		target = waypoints [waypoint].position;
	}
}
