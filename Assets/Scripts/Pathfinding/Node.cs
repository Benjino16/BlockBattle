using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector2 worldPosition;

    public int gCost;
    public int hCost;

    public int x;
    public int y;

    public Node parent;

    public int fCost
    {
        get { return gCost + hCost; }
    }
    public Node(bool _walkable, Vector2 _worldPos, int gridX, int gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        x = gridX;
        y = gridY;
    }
}
