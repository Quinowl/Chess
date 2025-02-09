using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private Cell cellPrefab;

    private void Start()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Cell cell = Instantiate(cellPrefab, new Vector3(i, 0, j), Quaternion.identity, transform);
                cell.Initialize((i + j) % 2 == 0);
            }
        }
    }
}