using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ProjectileController : MonoBehaviour
{
    public bool CanPickup = false;
    public bool IsCopy = false;
    private Vector3 _targetPosition;

    private PlayerController _player;
    private BossController _boss;

    private float speed = 0.25f;

    private int life = 0;
    private int lifetime = 300;

    private int chancePickup = 5;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _boss = FindObjectOfType<BossController>();
    }

    private void FixedUpdate()
    {
        if (IsCopy)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed);
            if (transform.position == _targetPosition)
                Destroy(gameObject);

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

        // Variation for projectile targeting
        float randX = Random.Range(-5f, 5f);
        float randZ = Random.Range(-5f, 5f);

        projectileObjCopy._targetPosition = targetPosition + new Vector3(randX,0,randZ);

        projectileObjCopy.IsCopy = true;
        projectileObjCopy.GetComponent<MeshRenderer>().enabled = true;

        // Logic for controlling if the projectile can be picked up or not
        int randNum = Random.Range(1, chancePickup+1);
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
            FindObjectOfType<BossHealth>().ReduceHealth();
            Destroy(gameObject);
        }

        else
        {
            FindObjectOfType<PlayerHealth>().ReduceHealth();
            Destroy(gameObject);
        }
    }
}
