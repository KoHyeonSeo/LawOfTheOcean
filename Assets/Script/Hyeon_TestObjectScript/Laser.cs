using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private RaycastHit raycast;
    private Vector3 dir;
    private PlayerShooter playerShooter;
    private LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.SetColors(Color.red, Color.red);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        playerShooter = gameObject.GetComponent<PlayerShooter>();
    }
    void Update()
    {
        dir = playerShooter.BulletMaxDirection;
        if (Physics.Linecast(transform.position, dir,out raycast)) ;

        transform.LookAt(dir.normalized);
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1, dir);

    }
}
