/*
Name: Harshil Patel
NSID: hap793
Student #11290942
Course: CMPT 306 
Description: Custom Editor for the Game Floor Creation without the game play.
Version:
--------1.0 creation
--------1.1 found an error where buttion doesnt show which was fixed in this version.    
*/
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbstractDungeonGen), true)]
public class RandomDungeonGenEditor : Editor
{
    AbstractDungeonGen gen;

    private void Awake(){
        gen = (AbstractDungeonGen)target;
    }

    public override void OnInspectorGUI(){
        base.OnInspectorGUI();
        if (GUILayout.Button("Create Dungeon"))
        {
            gen.GenerateDungeon();
        }
    }
}
