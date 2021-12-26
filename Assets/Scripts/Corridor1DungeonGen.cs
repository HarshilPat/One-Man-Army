/*
Name: Harshil Patel
NSID: hap793
Student #11290942
Course: CMPT 306 
Description: Class for creating multiple islands with walkways connecting them specified by the langth.
Version:
--------1.0 creation
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Corridor1DungeonGen : SimpleRandomWalkDungeonGen
{
    [SerializeField]
    private int corridorLength = 14, corridorCount = 5;
    [SerializeField]
    [Range(0.1f,1)]
    private float roomPercent = 0.8f;

    protected override void RunProceduralGeneration(){
        Corridor1Generation();
    }

    private void Corridor1Generation(){
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> roomPotentialPositions = new HashSet<Vector2Int>();

        createCorridors(floorPositions, roomPotentialPositions);

        HashSet<Vector2Int> np = roomCreation(roomPotentialPositions);

        List<Vector2Int> deadEnds = FindDeadEnds(floorPositions);

        createRoomsAtDeadEnd(deadEnds, np);


        floorPositions.UnionWith(np);

        tilemapvisualizer.PaintFloor(floorPositions);
        WallGen.createWalls(floorPositions, tilemapvisualizer);

    }

    private void createRoomsAtDeadEnd(List<Vector2Int> deadEnds, HashSet<Vector2Int> rpos){
        foreach (var p in deadEnds)
        {
            if (rpos.Contains(p) == false)
            {
                var room = RunRandomWalk(parameters, p);
                rpos.UnionWith(room);
            }
        }
    }

    private List<Vector2Int> FindDeadEnds(HashSet<Vector2Int> floorPositions){
        List<Vector2Int> deadends = new List<Vector2Int>();
        foreach (var item in floorPositions)
        {
            int neighbourCount = 0;
            foreach (var dir in Direction2D.cardinalDirectionL)
            {
                if(floorPositions.Contains(item + dir)){
                    neighbourCount++;
                }
            }
            if (neighbourCount == 1){
                deadends.Add(item);
            }
        }
        return deadends;
    }

    private HashSet<Vector2Int> roomCreation(HashSet<Vector2Int> roomPotentialPositions){
        HashSet<Vector2Int> PosRooms = new HashSet<Vector2Int>();
        int room2CreateCount = Mathf.RoundToInt(roomPotentialPositions.Count * roomPercent);

        List<Vector2Int> roomToCreate = roomPotentialPositions.OrderBy(x => Guid.NewGuid()).Take(room2CreateCount).ToList();

        foreach (var roomPosition in roomToCreate)
        {
            var roomFloor = RunRandomWalk(parameters, roomPosition);
            PosRooms.UnionWith(roomFloor);
        }
        return PosRooms;
    }

    private void createCorridors(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> roomPotentialPositions){
        var currentPos = startPos;
        roomPotentialPositions.Add(currentPos);

        for (int i = 0; i < corridorCount; i++)
        {
            var corridor = ProceduralGeneration.RandomCorridors(currentPos, corridorLength);
            currentPos = corridor[corridor.Count - 1];
            roomPotentialPositions.Add(currentPos);
            floorPositions.UnionWith(corridor);
        }
    }
}
