using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private ProjectileController _projectile;
    private PlayerController _player;

    private float _xMaxSpawn = 10;
    private float _yMaxSpawn = 5;
    private float _zMaxSpawn = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        _projectile = FindObjectOfType<ProjectileController>();
        _player = FindObjectOfType<PlayerController>();
    }

    void update()
    {
        transform.LookAt(_player.transform);
    }

    public void SpawnProjectile(int numSpawn)
    {
        for (int i = 0; i < numSpawn; i++)
        {
            float x_spawn = Random.Range(-_xMaxSpawn, _xMaxSpawn);
            float y_spawn = Random.Range(0, _yMaxSpawn);
            float z_spawn = Random.Range(-_zMaxSpawn, _zMaxSpawn);
            Vector3 spawnPosition = transform.position + new Vector3(x_spawn, y_spawn, z_spawn);
            Vector3 targetPosition = _player.transform.position;
            _projectile.Spawn(spawnPosition, targetPosition);
        }
        
    }

}
