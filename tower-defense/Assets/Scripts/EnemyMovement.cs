using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class EnemyMovement : MonoBehaviour {

    [SerializeField] float movementPeroid = 0.5f;
    [SerializeField] ParticleSystem goalParticle;

    // Use this for initialization
    void Start ()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(movementPeroid);
        }

        SelfDestruct();
    }

    void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject);
    }
}
