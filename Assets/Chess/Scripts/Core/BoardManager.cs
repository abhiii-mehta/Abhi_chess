using UnityEngine;
public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public BasePiece[,] Board { get; private set; } = new BasePiece[8, 8];
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        InitializeBoard();
    }
    private void InitializeBoard()
    {
        Board = new BasePiece[8, 8];
        BasePiece[] allPieces = FindObjectsOfType<BasePiece>();
        foreach (BasePiece piece in allPieces)
        {
            if (IsInsideBoard(piece.Row, piece.Column))
                Board[piece.Row, piece.Column] = piece;
        }
    } 
    public BasePiece GetPieceAt(int row, int col)
    {
        if (!IsInsideBoard(row, col)) return null;
        return Board[row, col];
    }
    public bool IsInsideBoard(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }
}

