using UnityEngine;
using System.Collections;

public class ChangeSeasonScript : MonoBehaviour {
	
	public Material skyboxWinter;
	public Material skyboxSpring;
	public Material skyboxSummer;
	public Material skyboxFall;
	public GameObject snow;
	public GameObject sun;
	public GameObject player;
	
	
	// Use this for initialization
	void Start () {
		snow = GameObject.Find("FX_Snow");
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
				if (Utilities.seasonCounter < 10) {
					if (Utilities.currentSeason == Utilities.winter) {
						snow.particleEmitter.emit = false;
					}
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
		snow.transform.position = player.transform.position;
		snow.particleEmitter.emit = true;
		snow.particleEmitter.maxSize = Random.Range(0.5f, 2.0f);
		snow.particleEmitter.worldVelocity = new Vector3(0.0f ,Random.Range(-1.0f, -2.5f), 0.0f);
	}
	
	public void enableSpring() {
		RenderSettings.skybox = skyboxSpring;
		resetFog();
		RenderSettings.ambientLight = new Color32(147, 145, 126, 255);
		sun.light.intensity = 0.65f;
		snow.particleEmitter.emit = false;
		
	}
	
	public void enableSummer() {
		RenderSettings.skybox = skyboxSummer;
		resetFog();
		RenderSettings.ambientLight = new Color32(211, 211, 211, 255);
		sun.light.intensity = 0.80f;
		snow.particleEmitter.emit = false;
		
	}
	
	public void enableFall() {
		RenderSettings.skybox = skyboxFall;
		resetFog();
		RenderSettings.ambientLight = new Color32(42, 26, 0, 255);
		sun.light.intensity = 0.71f;
		snow.particleEmitter.emit = false;
		
	}
	
	// setter and resetter fog functions
	void setFog() {
		RenderSettings.fog = true;
	}
	
	void resetFog() {
		RenderSettings.fog = false;
	}
}
