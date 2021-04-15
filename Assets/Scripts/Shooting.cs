using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float speed;
    public float recoilDistance;
    public float stoppingDistance;
    public Transform player;

    private float timeBtwShoots;
    public float startTimeBtwShoots;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectsWithTag("Player");
        timeBtwShoots = startTimeBtwShoots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > recoilDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < recoilDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBtwShoots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShoots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }
    }
}
