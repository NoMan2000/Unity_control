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
	public int seasonType;
	
	// Use this for initialization
	void Start () {
		if (Utilities.state == Utilities.stateMainGame) {
			lookAtDistance = 35.0f;
			chargeRange = 35.0f;
			closeRange = 2.0f;
			moveSpeed = 5.0f;
			damping = 6.0f;
			isItAttacking = false;
			self = GameObject.Find(name)as GameObject;
			print(self.name);
			isActive = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
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
				}
				if (distance < chargeRange) {
					charge();
				}
				if (distance < closeRange) {
					attack ();
					destroySelf();
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
	
	void charge() {
		isItAttacking = true;
		//renderer.material.color = Color.red;
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}
	
	void destroySelf() {
		if (!Utilities.attractWinter && !Utilities.attractSummer && !Utilities.attractSpring && !Utilities.attractFall) {
			DestroyObject(GameObject.Find(name));
		}
	}
	
	public void attack() {
		Utilities.saludBar -= Utilities.saludBar * 5.0f / 100f * Utilities.shortRangeSoul;
		Utilities.attackTimeShort = Time.time;
		Utilities.isShortRangeAttacking = true;
	}
}

