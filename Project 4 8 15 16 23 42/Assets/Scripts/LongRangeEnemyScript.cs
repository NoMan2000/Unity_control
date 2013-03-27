using UnityEngine;
using System.Collections;

public class LongRangeEnemyScript : MonoBehaviour {
	
	float distance;
	public GameObject target;
	public GameObject self;
	public GameObject attackEffect;
	public float lookAtDistance;
	public float attackRange;
	public float damping;
	bool isItAttacking;
	public float fireCycle;
	public float fireDelay;
	
	// Use this for initialization
	void Start () {
		if (Utilities.state == Utilities.stateMainGame) {
			lookAtDistance = 55.0f;
			attackRange = 55.0f;
			damping = 6.0f;
			fireCycle = fireDelay = 5.0f;
			isItAttacking = false;
			self = GameObject.Find(name);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Utilities.state == Utilities.stateMainGame) {
			distance = Vector3.Distance(target.transform.position, transform.position);
			if (distance < lookAtDistance) {
				isItAttacking = false;
				renderer.material.color = Color.yellow;
				lookAt();
			}
			if (distance > lookAtDistance) {
				renderer.material.color = Color.green;
				fireCycle = Time.time;
			}
			if (distance < attackRange) {
				attack ();
			}
			if (isItAttacking) {
				renderer.material.color = Color.red;
			}
			
			// this is what will kill them if player casts spell
			if (distance < Utilities.defensiveAttackDistance) {
				if (Utilities.defensiveSpell == true) {
					Destroy(self);
				}
			}
		}
	}
	
	void lookAt() {
		Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}
	
	
	void attack() {
		attackEffect.transform.position = target.transform.position;
		
		if (Time.time > fireCycle + fireDelay) {
			isItAttacking = true;
			renderer.material.color = Color.red;
			Utilities.attackTimeLong = Time.time;
			Utilities.isLongRangeAttacking = true;
			fireCycle = Time.time + fireDelay;
		}
	}
	
}