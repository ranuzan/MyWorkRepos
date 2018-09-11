using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefeb;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform t in pathPrefeb.transform)
        {
            waveWaypoints.Add(t);
        }

        return waveWaypoints;
    }
    public GameObject GetenemyPrefab()  {return enemyPrefab;}
    public float GettimeBetweenSpawns() {return timeBetweenSpawns;}
    public float GetspawnRandomFactor() {return spawnRandomFactor;}
    public float GetmoveSpeed(){return moveSpeed;}
    public int GetnumberOfEnemies() {return numberOfEnemies;}



}
