using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointindex = 0;

    void Start()
    {
        target = WayPoints.points[0];
         
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointindex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
        }
        wavepointindex++;
        target = WayPoints.points[wavepointindex];
    }
}
