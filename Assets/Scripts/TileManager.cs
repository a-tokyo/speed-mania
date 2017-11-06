using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
	public GameObject player;


	public GameObject tilePrefab;
	public GameObject coinPrefab;
	public GameObject obstaclePrefab;
	public GameObject radarPrefab;


	private float spawnMainZ = -12.0f;
	private float tileLength = 12.0f;
	private int amnTileOnScreen = 7;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < amnTileOnScreen; i++){
			spawnTile();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void spawnTile(int prefabIndex = -1){
		GameObject tile;
		tile = Instantiate (tilePrefab) as GameObject;
		tile.transform.position = Vector3.forward * spawnMainZ;

		GameObject coin;
		coin = Instantiate (coinPrefab) as GameObject;
		coin.transform.position = new Vector3 (0 , 1, player.transform.position.z + 5);

		GameObject obstacle;
		obstacle = Instantiate (obstaclePrefab) as GameObject;
		obstacle.transform.position = new Vector3 (-3.5f , 1, player.transform.position.z + 8);

		GameObject radar;
		radar = Instantiate (radarPrefab) as GameObject;
		radar.transform.position = new Vector3 (0 , 0.02f, player.transform.position.z + 10);

		// increment spawnZ
		spawnMainZ += tileLength;
	}
}
