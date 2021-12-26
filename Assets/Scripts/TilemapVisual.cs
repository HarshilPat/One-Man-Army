/*
Name: Harshil Patel
NSID: hap793
Student #11290942
Course: CMPT 306 
Description: Class that visualizes the tilemap and path created by the simple random walk dungeon generator, by placing the floor and wall tiles.
Version:
--------1.0 creation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisual : MonoBehaviour
{
    [SerializeField] private Tilemap floorTilemap,wallTilemap;

    [SerializeField] private TileBase floorTile,wall;

    public void PaintFloor(IEnumerable<Vector2Int> floorPos){
        PaintTiles(floorPos, floorTilemap, floorTile);
    }

    internal void PaintSingleBasicWall(Vector2Int position){
        PaintSingleTile(wallTilemap, wall, position);
    }

    private void PaintTiles(IEnumerable<Vector2Int> pos, Tilemap tileMap, TileBase tile){
        foreach (var position in pos)
        {
            PaintSingleTile(tileMap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position){
        var tilePos = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePos, tile);
    }


    public void clear(){
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }
}
