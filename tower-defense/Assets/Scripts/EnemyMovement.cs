using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class EnemyMovement : MonoBehaviour {

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
            yield return new WaitForSeconds(2f);
        }
    }
}
