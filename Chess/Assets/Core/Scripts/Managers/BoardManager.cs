using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private Piece[] piecePrefabs;

    private Cell[,] board = new Cell[8, 8];
    private Piece[,] pieces = new Piece[8, 8];

    public void GenerateBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Cell cell = Instantiate(cellPrefab, new Vector3(i, 0, j), Quaternion.identity, transform);
                cell.Initialize((i + j) % 2 == 0);
            }
        }
        PlacePieces();
    }

    public bool IsCellOccupied(Vector2Int position) => pieces[position.x, position.y] != null;

    private void PlacePieces()
    {
        PlacePiece(Vector2Int.zero, EPieceType.Rook, EPieceColor.White);
        PlacePiece(new Vector2Int(7, 0), EPieceType.Rook, EPieceColor.White);
    }

    private void PlacePiece(Vector2Int position, EPieceType type, EPieceColor color)
    {
        Piece prefab = System.Array.Find(piecePrefabs, p => p.PieceType == type && p.PieceColor == color);
        if (!prefab) return;
        Piece piece = Instantiate(prefab, new Vector3(position.x, 0f, position.y), Quaternion.identity);
        pieces[position.x, position.y] = piece;
    }

    public void MovePiece(Vector2Int startPosition, Vector2Int targetPosition)
    {
        if (!pieces[startPosition.x, startPosition.y]) return;
        Piece piece = pieces[startPosition.x, startPosition.y];
        if (piece.IsValidMove(startPosition, targetPosition, pieces))
        {
            pieces[targetPosition.x, targetPosition.y] = piece;
            pieces[startPosition.x, startPosition.y] = null;

            piece.transform.position = new Vector3(targetPosition.x, 0f, targetPosition.y);
        }
    }
}