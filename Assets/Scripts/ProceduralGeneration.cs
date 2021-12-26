/*
Name: Harshil Patel
NSID: hap793
Student #11290942
Course: CMPT 306 
Description: Class for generating game worlds by procedural generation. which uses HashSet for no duplication due to random creation.
Version:
--------1.0 creation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGeneration
{
    public static HashSet<Vector2Int> RandomWalk(Vector2Int startPos, int walkLength){
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPos);
        var prevPos = startPos;
        
        for(int i = 0; i < walkLength; i++){
            var newPos = prevPos + Direction2D.GetRandomcardinalDirection();
            path.Add(newPos);
            prevPos = newPos;
        }   
        return path;
    }

    public static List<Vector2Int> RandomCorridors(Vector2Int startPos, int corridorLength){
        List<Vector2Int> corridor = new List<Vector2Int>();
        var dir = Direction2D.GetRandomcardinalDirection();
        var currentPos = startPos;
        corridor.Add(currentPos);

        for (int i = 0; i < corridorLength; i++)
        {
            currentPos += dir;
            corridor.Add(currentPos);
        }
        return corridor;
    }
}

public static class Direction2D{
    public static List<Vector2Int> cardinalDirectionL = new List<Vector2Int>{
        new Vector2Int(0,1),// ^
        new Vector2Int(1,0),// >
        new Vector2Int(0,-1),// \/
        new Vector2Int(-1,0)// <
    };

    public static Vector2Int GetRandomcardinalDirection(){
        return cardinalDirectionL[Random.Range(0, cardinalDirectionL.Count)];
    }
}