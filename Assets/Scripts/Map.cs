using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : Singleton<Map>
{
    public int TotalBotNumber = 20;
    public int AliveBotNumber = 20;
    public int ActiveBotNumber;
    public int MaximumBot = 5;

    public Bounds MapBound;
    public GameObject Floor;
    private Vector3 RandomSpawnLocation;

    void Start()
    {
        MapBound = Floor.GetComponent<Renderer>().bounds;
        LevelManager.Ins.ChangeActiveBot(TotalBotNumber);
        CSpawnBot();
    }
    private void Update()
    {
        Debug.Log("active bots: " + ActiveBotNumber);
    }
    public void CSpawnBot()
    {
        while(ActiveBotNumber < MaximumBot) 
        {
            StartCoroutine(SpawnBot());
            Debug.Log("spawned");
        }        
    }

    public void GetRandomPosition()
    {
        RandomSpawnLocation.x = UnityEngine.Random.Range(MapBound.min.x, MapBound.max.x);
        RandomSpawnLocation.y = MapBound.max.y + 1f;
        RandomSpawnLocation.z = UnityEngine.Random.Range(MapBound.min.z, MapBound.max.z);
    }

    public IEnumerator SpawnBot()
    {
        ActiveBotNumber++;
        yield return Cache.GetWFS(5);
        GetRandomPosition();
        Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot, RandomSpawnLocation, Quaternion.identity);
       
        //TotalBotNumber--;     
    }




}
