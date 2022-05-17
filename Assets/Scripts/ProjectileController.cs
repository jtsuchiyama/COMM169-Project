using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ProjectileController : MonoBehaviour
{
    public bool CanPickup = false;
    public bool IsCopy = false;
    public Vector3 TargetPosition;

    private PlayerController _player;
    private BossController _boss;

    private float speed = 0.07f;

    private int life = 0;
    private int lifetime = 300;

    private int chancePickup = 4;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _boss = FindObjectOfType<BossController>();
    }

    private void FixedUpdate()
    {
        if (IsCopy)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed);
            life++;
            if (life == lifetime)
                Destroy(gameObject);
        }      
    }

    public ProjectileController Spawn(Vector3 spawnPosition, Vector3 targetPosition)
    {
        GameObject projectileCopy = Instantiate(gameObject);
        ProjectileController projectileObjCopy = projectileCopy.GetComponent<ProjectileController>();

        projectileObjCopy.transform.position = spawnPosition;
        projectileObjCopy.TargetPosition = targetPosition;

        projectileObjCopy.IsCopy = true;
        projectileObjCopy.GetComponent<MeshRenderer>().enabled = true;

        // Logic for controlling if the projectile can be picked up or not
        int randNum = Random.Range(1, chancePickup+1);
        Debug.Log(randNum);
        if (randNum == chancePickup)
        {
            projectileObjCopy.CanPickup = true;
            projectileObjCopy.GetComponent<Renderer>().material.color = Color.green;
        }
             

        return projectileObjCopy;
    }

    public void OnSelectEnter()
    {
        if (CanPickup == true)
        {
            Destroy(gameObject);
        }

        else
        {
            FindObjectOfType<PlayerHealth>().ReduceHealth();
            Destroy(gameObject);
        }
    }
}
