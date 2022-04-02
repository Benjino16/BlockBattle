using UnityEngine;
using System.Collections.Generic;

public class PathfindingGrid : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    Node[,] grid;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                bool walkable = Physics2D.OverlapCircle(worldPoint, nodeRadius, unwalkableMask) == null;
                grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if(x == 0 && y == 0)
                {
                    continue;
                }
                int checkX = node.x + x;
                int checkY = node.y + y;

                if(checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }

    public Node NodeFromWorldPoint(Vector2 worldPosition)
    {
        float percentX = (worldPosition.x - transform.position.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.y - transform.position.y + gridWorldSize.y / 2) / gridWorldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return grid[x, y];
    }


    public List<Node> path;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, gridWorldSize);

        if (grid != null)
        {
            foreach (Node node in grid)
            {
                if (node.walkable)
                {
                    Gizmos.color = Color.white;
                }
                else
                {
                    Gizmos.color = Color.red;
                }
                if(path != null)
                {
                    if(path.Contains(node))
                    {
                        Gizmos.color = Color.green;
                    }
                }

                Gizmos.DrawWireCube(node.worldPosition, Vector2.one * (nodeDiameter - .1f));
            }
        }
    }
}
