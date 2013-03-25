using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {
	
	public GameObject player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator OnTriggerEnter(Collider collider) {
		if (collider.gameObject.Equals(player)) {
			Destroy(player);
			yield return new WaitForSeconds(2);
			Application.LoadLevel(0);
		}
	}
}
