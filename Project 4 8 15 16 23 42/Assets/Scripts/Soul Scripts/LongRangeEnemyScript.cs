using UnityEngine;
using System.Collections;

public class LongRangeEnemyScript : MonoBehaviour {
	
	float distance;
	public GameObject target;
	public GameObject self;
	public GameObject attackEffect;
	public float lookAtDistance = 55.0f;
	public float attackRange = 30.0f;
	public float damping = 6.0f;
	bool isItAttacking = false;
	public float fireCycle  = 5.0f;
	public float fireDelay = 5.0f;
	public bool isActive = true;
	public int seasonType;
	
	public GameObject invisibleProjectile;
	public float force = 75;
	
	// Use this for initialization
	void Start () {
		if (Utilities.state == Utilities.stateMainGame) {
			self = GameObject.Find(name);
			seasonType = Random.Range(1,5);
			//seasonType = Utilities.winter;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Utilities.state == Utilities.stateMainGame) {
			selectTarget();
			if (isActive) {
				distance = Vector3.Distance(target.transform.position, transform.position);
				if (distance < lookAtDistance) {
					isItAttacking = false;
					//renderer.material.color = Color.yellow;
					lookAt();
				}
				if (distance > lookAtDistance) {
					isItAttacking = false;
					//renderer.material.color = Color.green;
					fireCycle = Time.time;
				}
				if (distance < attackRange) {
					attack ();
				}
				if (isItAttacking) {
					//renderer.material.color = Color.red;
				}
			}
		}
	}	
	
	
	void selectTarget() {
		if (seasonType == Utilities.winter) {
			renderer.material.color = Color.blue;
			if (Utilities.attractWinter) {
				target = GameObject.FindGameObjectWithTag("attractWinter");
			} 
			else {
				target = GameObject.FindGameObjectWithTag("Player");
			}
		}
		if (seasonType == Utilities.summer) {
			renderer.material.color = Color.yellow;
			if (Utilities.attractSummer) {
				target = GameObject.FindGameObjectWithTag("attractSummer");
			}
			else {
				target = GameObject.FindGameObjectWithTag("Player");
			}
		}
		if (seasonType == Utilities.spring) {
			renderer.material.color = Color.green;
			if (Utilities.attractSpring) {
				target = GameObject.FindGameObjectWithTag("attractSpring");
			}
			else {
				target = GameObject.FindGameObjectWithTag("Player");
			}
		}
		if (seasonType == Utilities.fall) {
			renderer.material.color = Color.gray;
			if (Utilities.attractFall) {
				target = GameObject.FindGameObjectWithTag("attractFall");
			}
			else {
				target = GameObject.FindGameObjectWithTag("Player");
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
			//renderer.material.color = Color.red;
			Utilities.attackTimeLong = Time.time;
			Utilities.isLongRangeAttacking = true;
			fireCycle = Time.time + fireDelay;
			tempPos = target.transform.position;
			attackEffect.transform.position = new Vector3(Random.Range(tempPos.x - 2, tempPos.x + 2), tempPos.y, Random.Range(tempPos.z - 2, tempPos.z + 2));	
		}
		
		if (Vector3.Distance(attackEffect.transform.position, target.transform.position) <= 1) {
			
		}
		else if (Vector3.Distance(attackEffect.transform.position, target.transform.position) > 1 ) {
			//print ("Uncheck");
		}
	}
}