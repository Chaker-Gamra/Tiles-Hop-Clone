using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<GameObject> activeTiles;
    public GameObject tilePrefab;

    public float distance;
    public int numberOfTiles = 3;

    private float zSpawn;
    private Transform ballTransform;

    void Start()
    {
        zSpawn = distance;
        activeTiles = new List<GameObject>();
        for (int i = 0; i < numberOfTiles; i++)
                SpawnTile();

        ballTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        if(ballTransform.position.z - 7 > zSpawn - (numberOfTiles * distance))
        {
            DeleteTile();
            SpawnTile();
        }
            
    }

    public void SpawnTile()
    {
        Vector3 tilePos = Vector3.forward * zSpawn + Vector3.right * Random.Range(-1.5f,1.5f);
        GameObject tile = Instantiate(tilePrefab, tilePos, Quaternion.identity);
        activeTiles.Add(tile);
        zSpawn += distance;
    }

    private void DeleteTile()
    {
        activeTiles[0].SetActive(false);
        activeTiles.RemoveAt(0);
    }
}
