/*
Name: Harshil Patel
NSID: hap793
Student #11290942
Course: CMPT 306 
Description: Abstract class for creating the world by running the generating methods.
Version:
--------1.0 creation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDungeonGen : MonoBehaviour
{
    [SerializeField] protected TilemapVisual tilemapvisualizer = null;
    [SerializeField] protected Vector2Int startPos = Vector2Int.zero;
    public void GenerateDungeon(){
        tilemapvisualizer.clear();
        RunProceduralGeneration();

    }

    protected abstract void RunProceduralGeneration();
}
