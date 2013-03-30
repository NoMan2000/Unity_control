using UnityEngine;
using System.Collections;

public class Collider1WeatherScript : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.Equals(player)) {
			Utilities.currentSeason = Utilities.fall;
		}
	}
}
