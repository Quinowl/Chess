using System.Collections;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;
    [SerializeField] private Piece[] piecePrefabs;
    [SerializeField] private float rotateBoardTime = 0.5f;

    private Piece[,] pieces = new Piece[8, 8];
    private Coroutine rotateBoardCoroutine;

    public void GenerateBoard()
    {
        transform.position = new Vector3(3.5f, 0f, 3.5f);
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

    [ContextMenu("Rotate board")]
    public void RotateBoard()
    {
        if (rotateBoardCoroutine != null) StopCoroutine(rotateBoardCoroutine);
        rotateBoardCoroutine = StartCoroutine(RotateBoardCoroutine());
        transform.Rotate(0, 180, 0);
    }

    private void PlacePieces()
    {
        PlacePawns(EPieceColor.White);
        PlacePawns(EPieceColor.Black);
        PlaceKnights();
        PlaceBishops();
        PlaceRooks();
        PlaceQueens();
        PlaceKings();
    }

    private void PlacePiece(Vector2Int position, EPieceType type, EPieceColor color)
    {
        Piece prefab = System.Array.Find(piecePrefabs, p => p.PieceType == type && p.PieceColor == color);
        if (!prefab) return;
        Piece piece = Instantiate(prefab, new Vector3(position.x, 0f, position.y), Quaternion.identity, transform);
        pieces[position.x, position.y] = piece;
    }

    private void PlacePawns(EPieceColor pieceColor)
    {
        for (int i = 0; i < 8; i++)
        {
            PlacePiece(new Vector2Int(i, pieceColor == EPieceColor.White ? 1 : 6), EPieceType.Pawn, pieceColor);
        }
    }

    private void PlaceRooks()
    {
        PlacePiece(Vector2Int.zero, EPieceType.Rook, EPieceColor.White);
        PlacePiece(new Vector2Int(7, 0), EPieceType.Rook, EPieceColor.White);
        PlacePiece(new Vector2Int(7, 7), EPieceType.Rook, EPieceColor.Black);
        PlacePiece(new Vector2Int(0, 7), EPieceType.Rook, EPieceColor.Black);
    }

    private void PlaceKnights()
    {
        PlacePiece(new Vector2Int(1, 0), EPieceType.Knight, EPieceColor.White);
        PlacePiece(new Vector2Int(6, 0), EPieceType.Knight, EPieceColor.White);
        PlacePiece(new Vector2Int(6, 7), EPieceType.Knight, EPieceColor.Black);
        PlacePiece(new Vector2Int(1, 7), EPieceType.Knight, EPieceColor.Black);
    }

    private void PlaceBishops()
    {
        PlacePiece(new Vector2Int(2, 0), EPieceType.Bishop, EPieceColor.White);
        PlacePiece(new Vector2Int(5, 0), EPieceType.Bishop, EPieceColor.White);
        PlacePiece(new Vector2Int(2, 7), EPieceType.Bishop, EPieceColor.Black);
        PlacePiece(new Vector2Int(5, 7), EPieceType.Bishop, EPieceColor.Black);
    }

    private void PlaceKings()
    {
        PlacePiece(new Vector2Int(4, 0), EPieceType.King, EPieceColor.White);
        PlacePiece(new Vector2Int(4, 7), EPieceType.King, EPieceColor.Black);
    }

    private void PlaceQueens()
    {
        PlacePiece(new Vector2Int(3, 0), EPieceType.Queen, EPieceColor.White);
        PlacePiece(new Vector2Int(3, 7), EPieceType.Queen, EPieceColor.Black);
    }

    private IEnumerator RotateBoardCoroutine()
    {
        float timeElapsed = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, 180, 0);

        while (timeElapsed < rotateBoardTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / rotateBoardTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}