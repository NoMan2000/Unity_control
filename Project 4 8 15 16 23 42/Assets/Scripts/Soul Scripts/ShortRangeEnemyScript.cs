using UnityEngine;
using System.Collections;

public class ShortRangeEnemyScript : MonoBehaviour {
	
	float distance;
	public GameObject target;
	public GameObject self;
	public GameObject attackEffect;
	public float lookAtDistance = 35.0f;
	public float chargeRange = 35.0f;
	public float moveSpeed = 5.0f;
	public float closeRange = 2.0f;
	public float damping = 6.0f;
	private bool isItAttacking = false;
	public bool isActive = true;
	
	// Use this for initialization
	void Start () {
		if (Utilities.state == Utilities.stateMainGame) {
			lookAtDistance = 35.0f;
			chargeRange = 35.0f;
			closeRange = 2.0f;
			moveSpeed = 5.0f;
			damping = 6.0f;
			isItAttacking = false;
			self = GameObject.Find(name);
			isActive = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			if (isActive) {
				distance = Vector3.Distance(target.transform.position, transform.position);
				if (distance < lookAtDistance) {
					isItAttacking = false;
					renderer.material.color = Color.yellow;
					lookAt();
				}
				if (distance > lookAtDistance) {
					renderer.material.color = Color.green;
				}
				if (distance < chargeRange) {
					charge();
				}
				if (distance < closeRange) {
					//attack ();
					//destroySelf();
				}
				if (isItAttacking) {
					renderer.material.color = Color.red;
				}
			}
		}
	}
	
	void lookAt() {
		Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}
	
	void charge() {
		isItAttacking = true;
		renderer.material.color = Color.red;
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}
	
	void destroySelf() {
		DestroyObject(self);
	}
	
	public void attack() {
		Utilities.darkSoulBar -= Utilities.darkSoulBar * 0.7f / 100f * Utilities.shortRangeSoul;
		Utilities.attackTimeShort = Time.time;
		Utilities.isShortRangeAttacking = true;
	}
}

