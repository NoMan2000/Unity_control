using UnityEngine;
using System.Collections;

public class CalamityAttack : MonoBehaviour {

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
		/*
		if (Input.GetButton("calumity")) {
			if (!Utilities.calumitySpell && !Utilities.defensiveSpell && !Utilities.calumitySpell) {
				Utilities.calumitySpell = true;
				startTime = Utilities.calumitySpellTime;
				spell.particleEmitter.emit = true;
			}
		}
		*/
		if (Input.GetButtonDown("calumity")) {
			if (!isButtonPressed) {
				isButtonPressed = true;
				buttonPressTime = maxButtonPressTime;
			}
		}
		
		// takes 4 seconds to fire calumity spell
		if (isButtonPressed) {
			buttonPressTime -= Time.deltaTime;
			print(buttonPressTime);
			if (buttonPressTime < 0) {
				if (!Utilities.calumitySpell && !Utilities.defensiveSpell && !Utilities.calumitySpell) {
					Utilities.calumitySpell = true;
					startTime = Utilities.calumitySpellTime;
					spell.particleEmitter.emit = true;
					print ("boom");
				}
			}
		}
		
		// counter
		if (Utilities.calumitySpell) {
			print("calumity : " + startTime);
			spell.transform.position = player.transform.position;
			startTime -= Time.deltaTime;
			if (startTime < 0) {
				Utilities.calumitySpell = false;
				spell.particleEmitter.emit = false;
				isButtonPressed = false;
			}
		}
	}
}
