using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public Transform target;
    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;


    public Path path;

    public float speed = 300f;

    public float maxSpeed = 3f;


    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3;

    private int currentWayPoint = 0;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if(target == null)
        {
            
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    private void Update()
    {
        if(rb.velocity.x < -0.2f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if(rb.velocity.x > 0.2f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        if(path == null)
        {
            return;
        }

        if(currentWayPoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -1 * maxSpeed / 2f, maxSpeed / 2f), Mathf.Clamp(rb.velocity.y, -1 * maxSpeed, maxSpeed));

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);
        if(dist < nextWaypointDistance)
        {
            currentWayPoint++;
            return;
        }


    }

}
