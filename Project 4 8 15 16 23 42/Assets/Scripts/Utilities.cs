using UnityEngine;
using System.Collections;

public class Utilities : MonoBehaviour {
	
	// season variables. 
	// each object in the environment will have their own script. 
	// And how that object behaves will depend on the season. 
	// So each script will make a reference to these variables
	// and check for the currentSeason's value.
	
	// Add all the variables in this utilities.cs file so that everyone can refer to them easily
	// NOTE: Don't forget to make them "public" and "static".
	
	public static int none = 0;
	
	public static int summer = 1;
	public static int fall = 2;
	public static int winter = 3;
	public static int spring = 4;
	public static int currentSeason = fall;
	public static int changedSeason;
	public static bool seasonChanged = false;
	public static float seasonCounter = 0.0f;
	public static float seasonCounterMax = 20.0f;
	
	
	// please in every script you write for the main game
	// first check if the state is equal to stateMainGame
	// because we want the scripts to work only when  we are 
	// stateMainGame state.
	//
	// if (utilities.state == Utilities.stateMainGame) {
			// do all your processing in this block
	// }
	public static int state; 
	public static int stateStartGame = 1; 	// for the main screen/ welcome screen
	public static int stateMainGame = 2; 	// for the main game
	public static int stateEndGame = 3;		// for the end game screen
	
	
	// what is attcking
	public static int shortRangeSoul = 1;
	public static int longRangeSoul = 2;
	public static int calumitySoul = 3;
	public static float attackTimeShort;
	public static float attackTimeLong;
	public static float attackTimeCalumity;
	public static bool isShortRangeAttacking = false;
	public static bool isLongRangeAttacking = false;
	public static bool isCalumityAttacking = false;
	
	
	// player attack variables
	public static bool defensiveSpell = false;
	public static bool offensiveSpell = false;
	public static bool calumitySpell = false;
	public static float defensiveSpellTime = 3;
	public static float offensiveSpellTime = 1;
	public static float calumitySpellTime = 6;
	public static float defensiveAttackDistance = 5;
	public static float calamityAttackRadius = 30;
	
	// player attributes
	public static float saludBar = 100;
	public static float magiaBar = 100;
	
	// world attributes
	public static bool isWaterFrozen = false;
	public static float freezeTimer = 0.0f;
	public static float maxFreezeTimer = seasonCounterMax;
	
	// attributes for power1 attraction
	public static bool attractWinter = false;
	public static bool attractSpring = false;
	public static bool attractSummer = false;
	public static bool attractFall = false;
	

	
	// Use this for initialization
	void Start () {
		state = stateMainGame;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find("SaludBarValue").GetComponent<TextMesh>().text = saludBar.ToString();
		GameObject.Find("MagiaBarValue").GetComponent<TextMesh>().text = magiaBar.ToString();
		
		// for short range souls
		GameObject[] array = GameObject.FindGameObjectsWithTag("shortSummer");
		foreach (GameObject g in array) {
			g.GetComponent<ShortRangeEnemyScript>().seasonType = Utilities.summer;
		}
		array = GameObject.FindGameObjectsWithTag("shortWinter");
		foreach (GameObject g in array) {
			g.GetComponent<ShortRangeEnemyScript>().seasonType = Utilities.winter;
		}
		array = GameObject.FindGameObjectsWithTag("shortFall");
		foreach (GameObject g in array) {
			g.GetComponent<ShortRangeEnemyScript>().seasonType = Utilities.fall;
		}
		array = GameObject.FindGameObjectsWithTag("shortSpring");
		foreach (GameObject g in array) {
			g.GetComponent<ShortRangeEnemyScript>().seasonType = Utilities.spring;
		}
		
		// for long range souls
		array = GameObject.FindGameObjectsWithTag("longSummer");
		foreach (GameObject g in array) {
			g.GetComponent<LongRangeEnemyScript>().seasonType = Utilities.summer;
		}
		array = GameObject.FindGameObjectsWithTag("longWinter");
		foreach (GameObject g in array) {
			g.GetComponent<LongRangeEnemyScript>().seasonType = Utilities.winter;
		}
		array = GameObject.FindGameObjectsWithTag("longFall");
		foreach (GameObject g in array) {
			g.GetComponent<LongRangeEnemyScript>().seasonType = Utilities.fall;
		}
		array = GameObject.FindGameObjectsWithTag("longSpring");
		foreach (GameObject g in array) {
			g.GetComponent<LongRangeEnemyScript>().seasonType = Utilities.spring;
		}
		
		// for calumity souls
		array = GameObject.FindGameObjectsWithTag("calumitySummer");
		foreach (GameObject g in array) {
			g.GetComponent<CalamitySoulScript>().seasonType = Utilities.summer;
		}
		array = GameObject.FindGameObjectsWithTag("calumityWinter");
		foreach (GameObject g in array) {
			g.GetComponent<CalamitySoulScript>().seasonType = Utilities.winter;
		}
		array = GameObject.FindGameObjectsWithTag("calumityFall");
		foreach (GameObject g in array) {
			g.GetComponent<CalamitySoulScript>().seasonType = Utilities.fall;
		}
		array = GameObject.FindGameObjectsWithTag("calumitySpring");
		foreach (GameObject g in array) {
			g.GetComponent<CalamitySoulScript>().seasonType = Utilities.spring;
		}
	}
}
