using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public const int NONE = 0;
    public const int SCYTHE = 1;
    public const int WHEATSEEDS = 2;
    public const int WHEAT = 3;

    const int SPRING = 0;
    const int SUMMER = 1;
    const int AUTUMN = 2;
    const int WINTER = 3;

    public Tilemap tilemap;
    public TileBase[] bases;

    int cursor;
    int [,]field;
    const int fieldX = 14;
    const int fieldY = 8;
    const int xOffset = 7;
    const int yOffset = 4;

    int season;
    // Start is called before the first frame update
    void Start()
    {
        season = SPRING;
        cursor = NONE;
        field = new int[fieldX, fieldY];
        for (int x = 0; x < fieldX; x++)
        {
            for (int y = 0; y < fieldY; y++)
            {
                field[x, y] = NONE;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePos = tilemap.WorldToCell(worldPos);
        Debug.Log("World");
        Debug.Log(Input.mousePosition);
        Debug.Log(worldPos);
        Debug.Log(tilePos);
        if (cursor != NONE && IsInField(tilePos))
        {
            if (field[tilePos.x + xOffset, tilePos.y + yOffset] != NONE && cursor == SCYTHE)
            {
                tilemap.SetTile(tilePos, bases[NONE]);
                field[tilePos.x + xOffset, tilePos.y + yOffset] = NONE;
            }
            else
            {
                tilemap.SetTile(tilePos, bases[cursor]);
                if (field[tilePos.x + xOffset, tilePos.y + yOffset] == NONE)
                {
                    field[tilePos.x + xOffset, tilePos.y + yOffset] = cursor;
                }
            }
        }
    }

    public bool IsInField(Vector3Int coord)
    {
        return coord.x + xOffset >= 0 && coord.x + xOffset < fieldX && coord.y + yOffset >= 0 && coord.y + yOffset < fieldY;
    }

    public void SetCursor(int newCursor)
    {
        cursor = newCursor;
    }

    public void UpdateSeason()
    {
        season++;
        season %= 4;
        for (int x = 0; x < fieldX; x++)
        {
            for (int y = 0; y < fieldY; y++)
            {
                if (field[x, y] == WHEATSEEDS) {
                    field[x, y] = WHEAT;
                    tilemap.SetTile(new Vector3Int(x - xOffset, y - yOffset, 0), bases[WHEAT]);
                }
            }
        }
    }
}
