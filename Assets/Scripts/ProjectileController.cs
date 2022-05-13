using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public bool CanPickup;
    public bool IsCopy = false;
    public Vector3 TargetPosition;

    private PlayerController _player;
    private BossController _boss;

    private float speed = 0.1f;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _boss = FindObjectOfType<BossController>();
    }

    private void FixedUpdate()
    {
        if(IsCopy)
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed);
    }

    public ProjectileController Spawn(Vector3 spawnPosition, Vector3 targetPosition)
    {
        GameObject projectileCopy = Instantiate(gameObject);
        ProjectileController projectileObjCopy = projectileCopy.GetComponent<ProjectileController>();

        projectileObjCopy.transform.position = spawnPosition;
        projectileObjCopy.TargetPosition = targetPosition;

        projectileObjCopy.IsCopy = true;
        projectileObjCopy.GetComponent<MeshRenderer>().enabled = true;
        return projectileObjCopy;
    }
}
