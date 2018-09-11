using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int difficulty = 0;
    [SerializeField] bool looping = false;

    int startingWave = 0;

	// Use this for initialization
	IEnumerator Start () {

        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
	}

    private IEnumerator SpawnAllWaves()
    {
        for(int i = startingWave; i<waveConfigs.Count;i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemysInWave(currentWave));

        }
    }

    private IEnumerator SpawnAllEnemysInWave(WaveConfig wave)
    {
        for (int enemyCount = 0; enemyCount < wave.GetnumberOfEnemies()+difficulty; enemyCount++)
        {
            var newEnemy = Instantiate(wave.GetenemyPrefab(), wave.GetWaypoints()[0].transform.position, Quaternion.identity);

            if(newEnemy.tag == "BOSS")
                newEnemy.GetComponent<BossPathing>().SetWaveConfig(wave);
            else
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(wave);


            yield return new WaitForSeconds(wave.GettimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
