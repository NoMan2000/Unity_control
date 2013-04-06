using UnityEngine;
using System.Collections;

public class Power3 : MonoBehaviour {

	public GameObject player;
	public GameObject spell;
	private float startTime;
	private float buttonPressTime;
	private float maxButtonPressTime = 4.0f;
	private bool isButtonPressed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.currentSeason == Utilities.winter) {
			spell = GameObject.Find("SpellWinterCalamity");
		}
		if (Utilities.currentSeason == Utilities.spring) {
			spell = GameObject.Find("SpellSpringCalamity");
		}
		if (Utilities.currentSeason == Utilities.summer) {
			spell = GameObject.Find("SpellSummerCalamity");
		}
		if (Utilities.currentSeason == Utilities.fall) {
			spell = GameObject.Find("SpellFallCalamity");
		}
		
		// check input
		if (Input.GetButtonDown("power3")) {
			if (!Utilities.calumitySpell && !Utilities.defensiveSpell && !Utilities.calumitySpell) {
				Utilities.calumitySpell = true;
				startTime = Utilities.calumitySpellTime;
				spell.particleEmitter.emit = true;
			}
		}
		
		// counter
		if (Utilities.calumitySpell) {
			spell.transform.position = player.transform.position;
			startTime -= Time.deltaTime;
			if (startTime < 0) {
				Utilities.calumitySpell = false;
				spell.particleEmitter.emit = false;
				isButtonPressed = false;
			}
		}
		
		// here goes what this spell would effect to the environment
		// in winter, water freezes
		// this power effects the whole environment
		if (Utilities.calumitySpell) {
			if (Utilities.currentSeason == Utilities.winter) {
				Utilities.isWaterFrozen = true;
				Utilities.freezeTimer = Utilities.maxFreezeTimer;
			}
			if (Utilities.currentSeason == Utilities.summer) {
				// water evaporate?
			}
			if (Utilities.currentSeason == Utilities.spring) {
				// birdy birdy?
			}
			if (Utilities.currentSeason == Utilities.fall) {
				// leaf carpet?
			}
		}
	}
}
