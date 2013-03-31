using UnityEngine;
using System.Collections;

public class OffensiveAttack : MonoBehaviour {
	
	public GameObject player;
	public GameObject spell;
	RaycastHit hit;
	GameObject newOffensiveEffect;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Update spell effect based on current season
		
		if (Utilities.currentSeason == Utilities.winter) {
			spell = GameObject.Find("SpellWinterOffensive");
		}
		else if (Utilities.currentSeason == Utilities.spring) {
			spell = GameObject.Find("SpellSpringOffensive");
		}
		else if (Utilities.currentSeason == Utilities.summer) {
			spell = GameObject.Find("SpellSummerOffensive");
		}
		else if (Utilities.currentSeason == Utilities.fall) {
			spell = GameObject.Find("SpellFallOffensive");
		}
		
		// check for input "offensive"
		if (Input.GetButton("offensive")) {
			Vector3 forward = player.transform.TransformDirection(Vector3.forward);
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 500.0f)) {
			//if (Physics.Raycast(transform.position, forward, out hit, 500.0f, 1)) {
				print(hit.collider.name);
				Utilities.offensiveSpell = true;
				GameObject newOffensiveEffect;
				newOffensiveEffect = Instantiate(spell, hit.point,  new Quaternion(0f,0f,0f,0f)) as GameObject;
				newOffensiveEffect.particleSystem.enableEmission = true;
				
				if (hit.collider.CompareTag("shortRangeSoul")) {
					Utilities.offensiveSpell = true;
					GameObject.Find (hit.collider.name).GetComponent<ShortRangeEnemyScript>().isActive = false;
					GameObject.Find (hit.collider.name).renderer.material.color = Color.blue;
				}
				if (hit.collider.CompareTag("longRangeSoul")) {
					Utilities.offensiveSpell = true;
					GameObject.Find (hit.collider.name).GetComponent<LongRangeEnemyScript>().isActive = false;
					GameObject.Find (hit.collider.name).renderer.material.color = Color.blue;
				}
				if (hit.collider.CompareTag("calumitySoul")) {
					print ("calumity");	
				}
				
				if (hit.collider.CompareTag("freeze")) {
					Utilities.isWaterFrozen = true;
					Utilities.freezeTimer = Utilities.maxFreezeTimer;
				}
				newOffensiveEffect.particleSystem.startSize++;
				Destroy(newOffensiveEffect, 1);
				Utilities.offensiveSpell = false;
			}
		}
	}
}
