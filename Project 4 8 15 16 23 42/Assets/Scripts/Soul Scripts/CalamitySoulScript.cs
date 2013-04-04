using UnityEngine;
using System.Collections;

public class CalamitySoulScript : MonoBehaviour {
	
	float distance;
	public GameObject target;
	public GameObject self;
	public GameObject attackEffect;
	public float lookAtDistance = 60.0f;
	public float attackRange = 40.0f;
	public float damping = 4.0f;
	public bool isActive = true;
	private bool isItAttacking = false;
	public float startTime = 0.0f;
	public float maxTimer = 10.0f;
	
	// Use this for initialization
	void Start () {
			if (Utilities.state == Utilities.stateMainGame) {
			self = GameObject.Find(name);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.stateMainGame == Utilities.stateMainGame) {
			if (isActive) {
				distance = Vector3.Distance(target.transform.position, transform.position);
				if (distance < lookAtDistance) {
					//isItAttacking = false;
					renderer.material.color = Color.yellow;
					lookAt();
				}
				if (distance > lookAtDistance) {
					isItAttacking = false;
					renderer.material.color = Color.green;
				}
				if (distance < attackRange) {
					if (!isItAttacking) {
						startTime = maxTimer;
					}
					attack ();
				}
				if (isItAttacking) {
					//renderer.material.color = Color.red;
				}
			}
		}
	}
	
	void lookAt() {
		Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}
	
	void attack() {
		isItAttacking = true;
		startTime -= Time.deltaTime;
		if (startTime < 0) {
			attackEffect.particleSystem.enableEmission = true;
			renderer.material.color = Color.red;
			Utilities.isCalumityAttacking = true;
			Utilities.attackTimeCalumity = Time.time;
			if (startTime < -2) {
				attackEffect.particleSystem.enableEmission = false;
				isItAttacking = false;
				Destroy(attackEffect, 1.0f);
				Destroy(GameObject.Find(name), 1.0f);
				Utilities.saludBar -= Utilities.saludBar / 2;
			}
		}
		
	}
}
