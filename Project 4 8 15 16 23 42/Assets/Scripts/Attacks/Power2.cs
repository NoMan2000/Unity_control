using UnityEngine;
using System.Collections;

public class Power2 : MonoBehaviour {
	
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
		if (Input.GetButton("power2")) {
			if (!Utilities.calumitySpell && !Utilities.defensiveSpell && !Utilities.calumitySpell) {
				startTime = Utilities.defensiveSpellTime;
			}
			Utilities.defensiveSpell = true;
			spell.particleSystem.enableEmission = true;
		}
		
		// Counter for spell
		if (Utilities.defensiveSpell) {
			print("defensive : " + startTime);
			startTime -= Time.deltaTime;
			if (startTime < 0) {
				spell.particleSystem.enableEmission = false;
				Utilities.defensiveSpell = false;
			}
		}
	}
}
