using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : Singleton<Map>
{

    public List<Bot> bots = new List<Bot>();
    public int totalBotNumber = 20;
    public int aliveBotNumber = 20;
    public int activeBotNumber;
    public int maximumBot = 5;

    public Bounds mapBound;
    public GameObject floor;
    private Vector3 randomSpawnLocation;

    public GameObject giftBox;
    public float giftBoxCountDown = 10f;
    void Start()
    {
        mapBound = floor.GetComponent<Renderer>().bounds;
        LevelManager.Ins.ChangeActiveBot(totalBotNumber);
        CSpawnBot();
    }
    private void Update()
    {
        Debug.Log("active bots: " + activeBotNumber);
        SpawnGiftBox();
    }
    public void CSpawnBot()
    {
        while(activeBotNumber < maximumBot) 
        {
            StartCoroutine(SpawnBot());
            Debug.Log("spawned");
        }        
    }
    public void DespawnBots()
    {
        for (int i = 0; i < bots.Count; i++)
        {
            bots[i].gameObject.SetActive(false);
        }
    }
    public void GetRandomPosition()
    {
        randomSpawnLocation.x = UnityEngine.Random.Range(mapBound.min.x, mapBound.max.x);
        randomSpawnLocation.y = 0;
        randomSpawnLocation.z = UnityEngine.Random.Range(mapBound.min.z, mapBound.max.z);
    }

    public IEnumerator SpawnBot()
    {
        if (activeBotNumber < maximumBot)
        {
            activeBotNumber++;
            yield return Cache.GetWFS(5);
            GetRandomPosition();
            Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot, randomSpawnLocation, Quaternion.identity);
            bots.Add(bot);
            //bot.OnInit();
            //TotalBotNumber--; 
        }

    }

    public void SpawnGiftBox()
    {
        giftBoxCountDown -= Time.deltaTime;
        if (giftBoxCountDown <= 0.1f) 
        {
            GetRandomPosition();
            Instantiate(giftBox, randomSpawnLocation, Quaternion.identity, transform);
            giftBoxCountDown = 10f;
        }
    }




}
