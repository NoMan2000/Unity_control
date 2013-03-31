using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {
	
	public GameObject player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Utilities.currentSeason == Utilities.winter) {
			if (!Utilities.isWaterFrozen) {
				GetComponent<MeshCollider>().isTrigger = true;
			}
			if (Utilities.isWaterFrozen) {
				GetComponent<MeshCollider>().isTrigger = false;
				Utilities.freezeTimer -= Time.deltaTime/2;
				print(Utilities.freezeTimer);
				if (Utilities.freezeTimer < 0) {
					Utilities.isWaterFrozen = false;
				}
			}
		}
		else if (Utilities.currentSeason == Utilities.spring) {
		}
		else if (Utilities.currentSeason == Utilities.summer) {
		}
		else if (Utilities.currentSeason == Utilities.fall) {
		}

	}
	
	IEnumerator OnTriggerEnter(Collider collider) {
		if (collider.gameObject.Equals(player)) {
			Destroy(player);
			yield return new WaitForSeconds(2);
			Application.LoadLevel(0);
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.Equals(player)) {
			print (collision.gameObject.name);
			player.GetComponent<PlayerController>().walkSpeed = 5.0f;
			player.GetComponent<PlayerController>().trotSpeed = 7.0f;
			player.GetComponent<PlayerController>().runSpeed = 8.0f;
		}
	}
	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.Equals(player)) {
			player.GetComponent<PlayerController>().walkSpeed = 3.0f;
			player.GetComponent<PlayerController>().trotSpeed = 5.0f;
			player.GetComponent<PlayerController>().runSpeed = 6.0f;
		}
	}
}
