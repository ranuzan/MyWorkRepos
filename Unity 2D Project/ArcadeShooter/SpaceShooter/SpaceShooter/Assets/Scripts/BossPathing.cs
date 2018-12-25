using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPathing : MonoBehaviour
{

    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    // Use this for initialization
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void SetWaveConfig(WaveConfig wc)
    {
        this.waveConfig = wc;
    }
    private void Move()
    {

        if (waypointIndex <= waypoints.Count - 1)
        {

            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetmoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
                waypointIndex = waypointIndex % 2;
            }
        }
    }
}
