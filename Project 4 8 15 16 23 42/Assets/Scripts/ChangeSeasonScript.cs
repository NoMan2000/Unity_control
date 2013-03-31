using UnityEngine;
using System.Collections;

public class ChangeSeasonScript : MonoBehaviour {
	
	public Material skyboxWinter;
	public Material skyboxSpring;
	public Material skyboxSummer;
	public Material skyboxFall;
	public GameObject sun;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.state == Utilities.stateMainGame) {
			if (!Utilities.defensiveSpell && !Utilities.offensiveSpell && !Utilities.calumitySpell) {
				if (Input.GetButton("winter")) {
					if (Utilities.currentSeason != Utilities.winter) {
						Utilities.changedSeason = Utilities.currentSeason;
						Utilities.currentSeason = Utilities.winter;
						Utilities.seasonCounter = Utilities.seasonCounterMax;
						Utilities.seasonChanged = true;
					}
					
				}
				if (Input.GetButton("summer")) {
					if (Utilities.currentSeason != Utilities.summer) {
						Utilities.changedSeason = Utilities.currentSeason;
						Utilities.currentSeason = Utilities.summer;
						Utilities.seasonCounter = Utilities.seasonCounterMax;
						Utilities.seasonChanged = true;
					}
				}
				if (Input.GetButton("spring")) {
					if (Utilities.currentSeason != Utilities.spring) {
						Utilities.changedSeason = Utilities.currentSeason;
						Utilities.currentSeason = Utilities.spring;
						Utilities.seasonCounter = Utilities.seasonCounterMax;
						Utilities.seasonChanged = true;
					}
				}
				if (Input.GetButton("fall")) {
					if (Utilities.currentSeason != Utilities.fall) {
						Utilities.changedSeason = Utilities.currentSeason;
						Utilities.currentSeason = Utilities.fall;
						Utilities.seasonCounter = Utilities.seasonCounterMax;
						Utilities.seasonChanged = true;
					}
				}
			}			
			
			
			if (Utilities.seasonChanged) {
				Utilities.seasonCounter -= Time.deltaTime;
				if (Utilities.seasonCounter < 0) {
					Utilities.seasonChanged = false;
					Utilities.currentSeason = Utilities.changedSeason;
				}
			}
			
			
			
			
			if (Utilities.currentSeason == Utilities.winter) {
			enableWinter();
			}
			else if (Utilities.currentSeason == Utilities.spring) {
				enableSpring();
			}
			else if (Utilities.currentSeason == Utilities.summer) {
				enableSummer();
			}
			else if (Utilities.currentSeason == Utilities.fall) {
				enableFall();
			}
				
				
		}		
	}
	
	// enable seasons
	public void enableWinter() {
		RenderSettings.skybox = skyboxWinter;
		setFog();
		RenderSettings.ambientLight = new Color32(44,44,44,255);
		sun.light.intensity = 0.53f;
		
	}
	
	public void enableSpring() {
		RenderSettings.skybox = skyboxSpring;
		resetFog();
		RenderSettings.ambientLight = new Color32(147, 145, 126, 255);
		sun.light.intensity = 0.65f;
		
	}
	
	public void enableSummer() {
		RenderSettings.skybox = skyboxSummer;
		resetFog();
		RenderSettings.ambientLight = new Color32(211, 211, 211, 255);
		sun.light.intensity = 0.80f;
		
	}
	
	public void enableFall() {
		RenderSettings.skybox = skyboxFall;
		resetFog();
		RenderSettings.ambientLight = new Color32(42, 26, 0, 255);
		sun.light.intensity = 0.71f;
		
	}
	
	// setter and resetter fog functions
	void setFog() {
		RenderSettings.fog = true;
	}
	
	void resetFog() {
		RenderSettings.fog = false;
	}
}
