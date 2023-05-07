using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    int BotNumber = 5;
    public Bounds MapBound;
    public GameObject Floor;
    private Vector3 RandomSpawnLocation;
    void Start()
    {
        MapBound = Floor.GetComponent<Renderer>().bounds;

        SpawnBot(BotNumber);
    }

    private void SpawnBot(int BotNumber)
    {
        for (int i = 0; i < BotNumber; i++)
        {
        GetRandomPosition();

            Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot, RandomSpawnLocation, Quaternion.identity);
        }
    }

    public void GetRandomPosition()
    {
        RandomSpawnLocation.x = Random.Range(MapBound.min.x, MapBound.max.x);
        RandomSpawnLocation.y = MapBound.max.y + 1f;
        RandomSpawnLocation.z = Random.Range(MapBound.min.z, MapBound.max.z);
    }


}
