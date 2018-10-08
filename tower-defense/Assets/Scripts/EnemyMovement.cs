﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;

	// Use this for initialization
	void Start ()
    {
        //StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        print("Starting patrol...");
        foreach (Waypoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            print("Visiting: " + wayPoint);
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol");
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
