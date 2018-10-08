using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Waypoint startWayPoint, stopWayPoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

	// Use this for initialization
	void Start () {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbors();
	}

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWayPoint.SetTopColor(Color.green);
        stopWayPoint.SetTopColor(Color.red);
    }

    private void ExploreNeighbors()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWayPoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {
                //foo
            }
        }
    }
}
