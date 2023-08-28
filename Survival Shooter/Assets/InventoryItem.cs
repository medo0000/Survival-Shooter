using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryItem : MonoBehaviour
{
    RectTransform imageRectTransform;
    public Vector2Int size;
    public Vector3[] corners;
    public bool rotated = false;


    public List<InventoryCell> occupyingCells = new List<InventoryCell>();
    public InventoryGrid occupyingGrid = null;


    private void Awake()
    {
        imageRectTransform = GetComponent<RectTransform>();
        corners = new Vector3[4];
        imageRectTransform.GetWorldCorners(corners);


        transform.localScale = Vector2.one * size;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            Rotate();


        }
    }
    public void Resize(Vector2Int newSize)
    {
        size = newSize;
        transform.localScale = Vector2.one * newSize;

        imageRectTransform.GetWorldCorners(corners);

    }
    public void Rotate()
    {
        if (!rotated)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }
        rotated = !rotated;

        //Resize(new Vector2Int(size.y,size.x));
    }

    public void SetOccupyingCells(List<InventoryCell> cells)
    {
        List<InventoryCell> newOccupyingCells = new List<InventoryCell>(cells);
        occupyingCells = newOccupyingCells;

    }
    public void ResetOccupyingCells()
    {
        UnOccupyCells();
        occupyingCells.Clear();
    }
    public void UnOccupyCells()
    {
        occupyingCells.ForEach(obj => obj.isOccupied = false);

    }
    public void OccupyCells()
    {
        occupyingCells.ForEach(obj => obj.isOccupied = true);

    }
    public Vector3[] GetCorners()
    {
        Vector3[] corners2 = new Vector3[4];
        imageRectTransform.GetWorldCorners(corners);
        corners2[1] = corners[0];
        corners2[2] = corners[1];
        corners2[3] = corners[2];
        corners2[0] = corners[3];

        if (rotated)
            return corners2;
        else return corners;

    }
}