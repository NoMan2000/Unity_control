using UnityEngine;
using System.Collections;

public class Power1 : MonoBehaviour {
	
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
		if (!Utilities.offensiveSpell) {
			// check for input "offensive"
			if (Input.GetButton("power1")) {
				if (!Utilities.calumitySpell && !Utilities.defensiveSpell && !Utilities.calumitySpell) {
					Vector3 forward = player.transform.TransformDirection(Vector3.forward);
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					if (Physics.Raycast(ray, out hit, 500.0f)) {
					//if (Physics.Raycast(transform.position, forward, out hit, 500.0f, 1)) {
						Utilities.offensiveSpell = true;
						GameObject newOffensiveEffect;
						newOffensiveEffect = Instantiate(spell, hit.point,  new Quaternion(0f,0f,0f,0f)) as GameObject;
						newOffensiveEffect.particleSystem.enableEmission = true;
						
						if (hit.collider.CompareTag("shortRangeSoul")) {
							if (Utilities.currentSeason == Utilities.winter) {
								Utilities.offensiveSpell = true;
								GameObject.Find (hit.collider.name).GetComponent<ShortRangeEnemyScript>().isActive = false;
								GameObject.Find (hit.collider.name).renderer.material.color = Color.blue;
							}
							else if (Utilities.currentSeason == Utilities.spring) {
							}
							else if (Utilities.currentSeason == Utilities.summer) {
							}
							else if (Utilities.currentSeason == Utilities.fall) {
							}
						}
						
						
						if (hit.collider.CompareTag("longRangeSoul")) {
							if (Utilities.currentSeason == Utilities.winter) {
								Utilities.offensiveSpell = true;
								GameObject.Find (hit.collider.name).GetComponent<LongRangeEnemyScript>().isActive = false;
								GameObject.Find (hit.collider.name).renderer.material.color = Color.blue;
							}
							else if (Utilities.currentSeason == Utilities.spring) {
							}
							else if (Utilities.currentSeason == Utilities.summer) {
							}
							else if (Utilities.currentSeason == Utilities.fall) {
							}
		
						}
						
						
						if (hit.collider.CompareTag("calumitySoul")) {
							if (Utilities.currentSeason == Utilities.winter) {
								Utilities.offensiveSpell = true;
								GameObject.Find(hit.collider.name).GetComponent<CalamitySoulScript>().isActive = false;
								GameObject.Find(hit.collider.name).renderer.material.color = Color.blue;
							}
							else if (Utilities.currentSeason == Utilities.spring) {
							}
							else if (Utilities.currentSeason == Utilities.summer) {
							}
							else if (Utilities.currentSeason == Utilities.fall) {
							}
		
						}
						
						/*
						if (hit.collider.CompareTag("freeze")) {
							if (Utilities.currentSeason == Utilities.winter) {
								Utilities.isWaterFrozen = true;
								Utilities.freezeTimer = Utilities.maxFreezeTimer;
							}
							else if (Utilities.currentSeason == Utilities.spring) {
							}
							else if (Utilities.currentSeason == Utilities.summer) {
							}
							else if (Utilities.currentSeason == Utilities.fall) {
							}
						}
						*/
						
						newOffensiveEffect.particleSystem.startSize++;
						Destroy(newOffensiveEffect, Utilities.offensiveSpellTime);
						Utilities.offensiveSpell = false;
					}
				}
			}
		}
	}
}
