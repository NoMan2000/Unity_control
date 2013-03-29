using UnityEngine;
using System.Collections;

public class LongRangeEnemyScript : MonoBehaviour {
	
	float distance;
	public GameObject target;
	public GameObject self;
	public GameObject attackEffect;
	public float lookAtDistance = 55.0f;
	public float attackRange = 55.0f;
	public float damping = 6.0f;
	bool isItAttacking = false;
	public float fireCycle  = 5.0f;
	public float fireDelay = 5.0f;
	public bool isActive = true;
	
	public GameObject invisibleProjectile;
	public float force = 75;
	
	// Use this for initialization
	void Start () {
		if (Utilities.state == Utilities.stateMainGame) {
			lookAtDistance = 55.0f;
			attackRange = 55.0f;
			damping = 6.0f;
			fireCycle = fireDelay = 5.0f;
			isItAttacking = false;
			self = GameObject.Find(name);
			isActive = true;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
					fireCycle = Time.time;
				}
				if (distance < attackRange) {
					attack ();
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
	
	
	void attack() {
		Vector3 tempPos ;
		//GameObject proj = Instantiate( invisibleProjectile, transform.position, transform.rotation ) as GameObject;
		//proj.rigidbody.AddRelativeForce( Vector3.down * force, ForceMode.Impulse );
		
		if (Time.time > fireCycle + fireDelay) {
			isItAttacking = true;
			renderer.material.color = Color.red;
			Utilities.attackTimeLong = Time.time;
			Utilities.isLongRangeAttacking = true;
			fireCycle = Time.time + fireDelay;
			tempPos = target.transform.position;
			attackEffect.transform.position = new Vector3(Random.Range(tempPos.x - 2, tempPos.x + 2), tempPos.y, Random.Range(tempPos.z - 2, tempPos.z + 2));	
		}
		
		if (Vector3.Distance(attackEffect.transform.position, target.transform.position) <= 1) {
			//print ("check");
			
		}
		else if (Vector3.Distance(attackEffect.transform.position, target.transform.position) > 1 ) {
			//print ("Uncheck");
		}
	}
}