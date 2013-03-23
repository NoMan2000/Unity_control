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
		if (Utilities.isShortRangeAttacking == true) {
			shortRangeParticleSystem.transform.position = player.transform.position;
			shortRangeParticleSystem.particleSystem.enableEmission = true;
			if ((int)Time.time - (int)Utilities.attackTime > 3) {
				Utilities.isShortRangeAttacking = false;
				shortRangeParticleSystem.particleSystem.enableEmission = false;
			}
		}
	}
}
