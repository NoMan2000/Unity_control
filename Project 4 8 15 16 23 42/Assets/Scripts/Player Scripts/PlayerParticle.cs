using UnityEngine;
using System.Collections;

public class PlayerParticle : MonoBehaviour {
	
	public GameObject shortRangeParticleSystem;
	public GameObject longRangeParticleSystem;
	public GameObject calumityParticleSystem;
	public GameObject player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate() {
		shortRangeParticleSystem.transform.position = player.transform.position;
		if (Utilities.isShortRangeAttacking == true) {
			shortRangeParticleSystem.particleSystem.enableEmission = true;
			if ((int)Time.time - (int)Utilities.attackTimeShort > 3) {
				Utilities.isShortRangeAttacking = false;
				shortRangeParticleSystem.particleSystem.enableEmission = false;
			}
		}
		
		if (Utilities.isLongRangeAttacking == true) {
			longRangeParticleSystem.particleSystem.enableEmission = true;
			if ((int)Time.time - (int)Utilities.attackTimeLong > 1) {
				Utilities.isLongRangeAttacking = false;
				longRangeParticleSystem.particleSystem.enableEmission = false;
			}
		}
	}
}
