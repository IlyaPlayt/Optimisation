using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAIBenchmark : MonoBehaviour
{
    TankBehaviour[] tanks;
    public int numberOfTanks;
    public GameObject tankPrefab;
    private Transform player;
    [SerializeField] private UpdateManager _updateManager;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tanks = new TankBehaviour[numberOfTanks];
        for (int i = 0; i < numberOfTanks; i++)
        {
           
            tanks[i]= Instantiate(tankPrefab).GetComponent<TankBehaviour>() ;
            tanks[i].SetPlayer(player);
            tanks[i].transform.position = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
           _updateManager.AddUpdatable(tanks[i]);
           
        }
    }
    

    private void DestroyAllTanks()
    {
        foreach (var tank in tanks)
        {
            _updateManager.RemoveUpdatable(tank);
        }
    }
}