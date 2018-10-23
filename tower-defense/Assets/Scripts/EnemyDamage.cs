using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] Collider collusionMesh;
    [SerializeField] int hitPoints = 10;

    // Use this for initialization
    void Start () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        Debug.Log("Current Hit Points: " + hitPoints);
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }
}
