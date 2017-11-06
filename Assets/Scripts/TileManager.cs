using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;
	public GameObject player;

	private float spawnMainZ = 0.0f;
	private float tileLength = 12.0f;
	private int amnTileOnScreen = 7;

	// Use this for initialization
	void Start () {
		spawnTile ();
		spawnTile ();
		spawnTile ();
		spawnTile ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void spawnTile(int prefabIndex = -1){
		GameObject go;
//		go = Instantiate (tilePrefabs[0]) as GameObject;
//		go.transform.SetParent (player.transform);
//		go.transform.position = Vector3.forward * spawnMainZ;
//		spawnMainZ += tileLength;
	}
}
