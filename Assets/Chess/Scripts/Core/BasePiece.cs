using UnityEngine;
using System.Collections.Generic;

public abstract class BasePiece : MonoBehaviour
{
    public int Row;
    public int Column;
    public bool IsWhite;

    private void Start()
    {
        var tile = ChessBoardPlacementHandler.Instance.GetTile(Row, Column);
        if (tile != null)
        {
            transform.position = tile.transform.position;
        }
        else
        {
            Debug.LogError($"Invalid tile at Row {Row}, Column {Column}");
        }
    }

    public abstract List<Vector2Int> GetLegalMoves(BasePiece[,] board);
}
