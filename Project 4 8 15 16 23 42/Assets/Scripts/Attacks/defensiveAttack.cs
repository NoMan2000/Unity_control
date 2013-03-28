using UnityEngine;
using System.Collections;

public class DefensiveAttack : MonoBehaviour {
	
	public GameObject player;
	public GameObject spell;
	private float startTime;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftControl)) {
			if (Utilities.defensiveSpell == false) {
				startTime = Time.time;
			}
			Utilities.defensiveSpell = true;
			spell.particleSystem.enableEmission = true;
		}
		if ((int)Time.time - (int)startTime > 1) {
				spell.particleSystem.enableEmission = false;
				Utilities.defensiveSpell = false;
		}
	}
}
