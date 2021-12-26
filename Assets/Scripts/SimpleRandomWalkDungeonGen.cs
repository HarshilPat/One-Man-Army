/*
Name: Harshil Patel
NSID: hap793
Student #11290942
Course: CMPT 306 
Description: The main class that creates the world. Which generates the floors only.
Version:
--------1.0 creation
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGen : AbstractDungeonGen{

    [SerializeField] protected SimpleRandomWalkData parameters;

    protected override void RunProceduralGeneration(){
        HashSet<Vector2Int> floorPos = RunRandomWalk(parameters, startPos);
        tilemapvisualizer.clear();
        tilemapvisualizer.PaintFloor(floorPos);
        WallGen.createWalls(floorPos, tilemapvisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkData para, Vector2Int pos){
        var currentPos = pos;
        HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
        for (int i = 0; i < para.iterations; i++){
            var path = ProceduralGeneration.RandomWalk(currentPos, para.walkLength);
            floorPos.UnionWith(path);
            if (para.startRandomlyEach){
                currentPos = floorPos.ElementAt(Random.Range(0, floorPos.Count));
            }
        }
        return floorPos;
    }


}
