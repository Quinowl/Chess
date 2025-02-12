using UnityEngine;

public class Knight : Piece
{
    private readonly (int x, int y)[] moves =
    {
        (2, 1), (2, -1), (-2, 1), (-2, -1), (1, 2), (1, -2), (-1, 2), (-1, -2)
    };

    public override bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        foreach (var move in moves)
        {
            Debug.Log(move);
            if (targetPosition.x == startPosition.x + move.x && targetPosition.y == startPosition.y + move.y)
            {
                return true;
            }
        }
        return false;
    }
}