using UnityEngine;
using System.Collections;

public class attackOnLongRangeSouls : MonoBehaviour {

	float distance;
	public GameObject target;
	public GameObject self;
	
	// Use this for initialization
	void Start () {
		self = GameObject.Find(name);
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			if (Utilities.defensiveSpell == true) {
				distance = Vector3.Distance(target.transform.position, transform.position);
				// this is what will kill them if player casts spell
				// will depend on the season and the soul effected also the spell casted
				if (distance < Utilities.defensiveAttackDistance) {
					Destroy(self);
				}
			}
		}
	}
}