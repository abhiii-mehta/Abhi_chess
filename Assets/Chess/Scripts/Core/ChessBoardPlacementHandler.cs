using System;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public sealed class ChessBoardPlacementHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _rowsArray;

    [Header("Highlight Prefabs (not used in this version but kept for reference)")]
    [SerializeField] private GameObject _highlightGreenPrefab;
    [SerializeField] private GameObject _highlightRedPrefab;

    private GameObject[,] _chessBoard;
    private GameObject[,] _highlightGrid = new GameObject[8, 8];
    internal static ChessBoardPlacementHandler Instance;

    private void Awake()
    {
        Instance = this;
        GenerateArray();
        InitializeHighlights();
    }
    private void GenerateArray()
    {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }
    private void InitializeHighlights()
    {
        Transform highlightRoot = GameObject.Find("HighlightGrid")?.transform;
        if (highlightRoot == null)
        {
            Debug.LogError("HighlightGrid object not found in the scene.");
            return;
        }

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                string name = $"Highlight_{row}_{col}";
                Transform highlight = highlightRoot.Find(name);
                if (highlight != null)
                {
                    _highlightGrid[row, col] = highlight.gameObject;
                    highlight.gameObject.SetActive(false);
                }
                else
                {
                    Debug.LogWarning($"Highlight object not found: {name}");
                }
            }
        }
    }
    internal GameObject GetTile(int i, int j)
    {
        try
        {
            return _chessBoard[i, j];
        }
        catch (Exception)
        {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }
    internal void Highlight(int row, int col, bool isEnemy = false)
    {
        if (!BoardManager.Instance.IsInsideBoard(row, col)) return;

        GameObject highlight = _highlightGrid[row, col];
        if (highlight == null) return;

        SpriteRenderer renderer = highlight.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            if (isEnemy)
                renderer.color = new Color(1f, 0f, 0f, 0.7f);
            else
                renderer.color = new Color(0f, 1f, 0f, 1f);
        }

        highlight.SetActive(true);
    }

    internal void ClearHighlights()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (_highlightGrid[row, col] != null)
                    _highlightGrid[row, col].SetActive(false);
            }
        }
    }
}
