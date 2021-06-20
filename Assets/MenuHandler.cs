using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MenuHandler : MonoBehaviour
{
    public const int NONE = 0;
    public const int SCYTHE = 1;
    public const int WHEATSEADS = 2;
    public const int WHEAT = 2;

    public Tilemap tilemap;
    public Texture2D[] cursors;
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;
    public TileManager tileManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePos = tilemap.WorldToCell(worldPos);
        Debug.Log("Menu");
        Debug.Log(tilePos);
        if (tilePos.x == 7 && tilePos.y == 3)
        {
            Cursor.SetCursor(cursors[SCYTHE], new Vector2(2, 5), cursorMode);
            tileManager.SetCursor(SCYTHE);
        } else if (tilePos.x == 7 && tilePos.y == 2)
        {
            Cursor.SetCursor(cursors[WHEATSEADS], hotSpot, cursorMode);
            tileManager.SetCursor(WHEATSEADS);
        }
    }
}
