using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startTime;
    public Transform[] wayPoints;
    private int randomWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        randomWayPoint = Random.Range(0, wayPoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            wayPoints[randomWayPoint].position, 
            speed * Time.deltaTime
            );

        if (Vector2.Distance(transform.position, wayPoints[randomWayPoint].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomWayPoint = Random.Range(0, wayPoints.Length);
                waitTime = startTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
}
