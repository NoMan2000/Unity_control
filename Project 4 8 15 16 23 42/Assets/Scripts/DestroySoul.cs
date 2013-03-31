using UnityEngine;
using System.Collections;

public class DestroySoul : MonoBehaviour {

	public GameObject player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider) {
		GameObject soulTemp = GameObject.Find(collider.gameObject.name);
		/*
		if (soulTemp.CompareTag("shortRangeSoul") && soulTemp.GetComponent<ShortRangeEnemyScript>()) {
			if (!collider.gameObject.Equals(player)) {
				if (soulTemp.GetComponent<ShortRangeEnemyScript>().isActive) {
					soulTemp.GetComponent<ShortRangeEnemyScript>().attack();
					print(collider.gameObject.name);
					Destroy(collider.gameObject);
				}
			}
		}
		*/
		if (collider.gameObject.Equals(player)) {
			GameObject.Find(name).GetComponent<ShortRangeEnemyScript>().attack();
			Destroy(GameObject.Find(name));
		}
	}
}
