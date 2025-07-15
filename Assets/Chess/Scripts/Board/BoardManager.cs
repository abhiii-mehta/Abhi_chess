using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;

    public BasePiece[,] Board = new BasePiece[8, 8];

    private void Awake()
    {
        Instance = this;

        BasePiece[] allPieces = FindObjectsOfType<BasePiece>();
        foreach (var piece in allPieces)
        {
            Board[piece.Row, piece.Column] = piece;
        }
    }

    public bool IsInsideBoard(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    public BasePiece GetPieceAt(int row, int col)
    {
        if (!IsInsideBoard(row, col)) return null;
        return Board[row, col];
    }
}
