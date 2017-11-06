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
	private float spawnMainZ = -12.0f;
	private float tileLength = 12.0f;
	private float safeZone = 50.0f;
	private int amnTileOnScreen = 10;

	// Use this for initialization
	void Start () {
		activeTiles = new List<GameObject>();
		activeCoins = new List<GameObject>();
		activeRadars = new List<GameObject>();
		activeObstacles = new List<GameObject>();
		for (int i = 0; i < amnTileOnScreen; i++){
			spawnElements();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ((player.transform.position.z - safeZone) > (spawnMainZ - amnTileOnScreen * tileLength)) {
			spawnElements();
			deleteElements ();
		}
	}

	private void spawnElements(int prefabIndex = -1){
		float coinNewZIncr = Random.Range(1, 10);
		float obstacleNewZIncr = Random.Range(1, 10);
		float radarNewZIncr = Random.Range(1, 10);
		while (obstacleNewZIncr != coinNewZIncr) {
			obstacleNewZIncr = Random.Range(1, 10);
		}
		while (radarNewZIncr != coinNewZIncr && radarNewZIncr != obstacleNewZIncr) {
			obstacleNewZIncr = Random.Range(1, 10);
		}


		GameObject tile;
		tile = Instantiate (tilePrefab) as GameObject;
		tile.transform.position = Vector3.forward * spawnMainZ;
		activeTiles.Add (tile);

		GameObject coin;
		coin = Instantiate (coinPrefab) as GameObject;
		coin.transform.position = new Vector3 (0 , 1, player.transform.position.z + 5);
		activeCoins.Add (coin);

		GameObject obstacle;
		obstacle = Instantiate (obstaclePrefab) as GameObject;
		obstacle.transform.position = new Vector3 (-3.5f , 1, player.transform.position.z + 8);
		activeObstacles.Add (obstacle);

		GameObject radar;
		radar = Instantiate (radarPrefab) as GameObject;
		radar.transform.position = new Vector3 (0 , 0.02f, player.transform.position.z + 10);
		activeRadars.Add (radar);

		// increment spawnZ
		spawnMainZ += tileLength;
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
