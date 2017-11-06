using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {
	/** Player */
	public GameObject player;

	/** Prefabs */
	public GameObject tilePrefab;
	public GameObject coinPrefab;
	public GameObject obstaclePrefab;
	public GameObject radarPrefab;

	/** GameElements */
	public List<GameObject> activeTiles;
	public List<GameObject> activeCoins;
	public List<GameObject> activeRadars;
	public List<GameObject> activeObstacles;

	/** Config variables */
	private float spawnMainZ = 0.0f;
	private float tileLength = 24.0f;
	private float safeZone = 40.0f;
	private int amnTileOnScreen = 3;

	// Use this for initialization
	void Start () {
		activeTiles = new List<GameObject>();
		activeCoins = new List<GameObject>();
		activeRadars = new List<GameObject>();
		activeObstacles = new List<GameObject>();
		for (int i = 0; i < amnTileOnScreen; i++){
			spawnElements((int)(i*tileLength) + 4, (int)(i*tileLength) + 23);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((player.transform.position.z - safeZone) > (spawnMainZ - amnTileOnScreen * tileLength)) {
			spawnElements();
			deleteElements ();
		}
	}

	private void spawnElements(int startRange = 4, int endRange = 23){
		GameObject tile;
		tile = Instantiate (tilePrefab) as GameObject;
		tile.transform.position = Vector3.forward * spawnMainZ;
		activeTiles.Add (tile);

		spawnGameRandomElements (startRange, endRange);

		// increment spawnZ
		spawnMainZ += tileLength;
	}


	private void spawnGameRandomElements(int startRange = 4, int endRange = 23) {
		float coinNewZIncr = Random.Range(startRange, endRange);
		float obstacleNewZIncr = Random.Range(startRange, endRange);
		float radarNewZIncr = Random.Range(startRange, endRange);
		while (obstacleNewZIncr == coinNewZIncr) {
			obstacleNewZIncr = Random.Range(startRange, endRange);
		}
		while (radarNewZIncr == coinNewZIncr && radarNewZIncr != obstacleNewZIncr) {
			obstacleNewZIncr = Random.Range(startRange, endRange);
		}

		GameObject coin;
		coin = Instantiate (coinPrefab) as GameObject;
		coin.transform.position = new Vector3 (randomLaneX() , 1, player.transform.position.z + coinNewZIncr);
		activeCoins.Add (coin);

		GameObject obstacle;
		obstacle = Instantiate (obstaclePrefab) as GameObject;
		obstacle.transform.position = new Vector3 (randomLaneX() , 1, player.transform.position.z + obstacleNewZIncr);
		activeObstacles.Add (obstacle);

		GameObject radar;
		radar = Instantiate (radarPrefab) as GameObject;
		radar.transform.position = new Vector3 (0 , 0.02f, player.transform.position.z + radarNewZIncr);
		activeRadars.Add (radar);
	}

	private float randomLaneX(){
		int randomNo = (int)Random.Range (0, 3);
		switch (randomNo) {
		case 0:
			return -3.5f;
		case 1:
			return 0.0f;
		case 2:
			return 3.5f;
		}
		return 0.0f;
	}

	private void deleteElements() {
		Destroy (activeTiles[0]);
		activeTiles.RemoveAt (0);

		Destroy (activeCoins[0]);
		activeCoins.RemoveAt (0);

		Destroy (activeRadars[0]);
		activeRadars.RemoveAt (0);

		Destroy (activeObstacles[0]);
		activeObstacles.RemoveAt (0);
	}
}
