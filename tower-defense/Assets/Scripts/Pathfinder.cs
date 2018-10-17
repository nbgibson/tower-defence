using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    [SerializeField] Waypoint startWayPoint, stopWayPoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;
    private List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

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
        if (!isRunning) { return; }

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(neighborCoordinates))
            {
                QueueNewNeighbors(neighborCoordinates);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighor = grid[neighborCoordinates];
        if (neighor.isExplored || queue.Contains(neighor))
        {
            //foo
        }
        else
        {
            queue.Enqueue(neighor);
            neighor.exploredFrom = searchCenter;
        }
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWayPoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbors();
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == stopWayPoint)
        {
            isRunning = false;
        }
    }

    private void CreatePath()
    {
        path.Add(stopWayPoint);
        Waypoint previous = stopWayPoint.exploredFrom;
        while(previous != startWayPoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWayPoint);
        path.Reverse();
    }

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }
}
