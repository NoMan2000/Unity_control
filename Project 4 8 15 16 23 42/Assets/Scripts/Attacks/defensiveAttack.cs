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
		// Update spell effect based on current season
		if (Utilities.currentSeason == Utilities.winter) {
			spell = GameObject.Find("SpellWinterDefensive");
		}
		else if (Utilities.currentSeason == Utilities.spring) {
			spell = GameObject.Find("SpellSpringDefensive");
		}
		else if (Utilities.currentSeason == Utilities.summer) {
			spell = GameObject.Find("SpellSummerDefensive");
		}
		else if (Utilities.currentSeason == Utilities.fall) {
			spell = GameObject.Find("SpellFallDefensive");
		}
		
		
		// check for input "defensive"
		if (Input.GetButton("defensive")) {
			if (Utilities.defensiveSpell == false) {
				startTime = Time.time;
			}
			Utilities.defensiveSpell = true;
			spell.particleSystem.enableEmission = true;
		}
		
		// Counter for spell
		if ((int)Time.time - (int)startTime > 1) {
				spell.particleSystem.enableEmission = false;
				Utilities.defensiveSpell = false;
		}
	}
}
