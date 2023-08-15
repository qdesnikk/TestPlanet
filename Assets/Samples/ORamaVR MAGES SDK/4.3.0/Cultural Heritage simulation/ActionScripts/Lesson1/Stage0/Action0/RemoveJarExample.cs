using MAGES.ActionPrototypes;
using MAGES.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MAGES.Utilities.VoiceActor;
/// <summary>
/// Example of Remove Action with hand
/// </summary>
public class RemoveJarExample : RemoveAction {

    /// <summary>
    /// Initialize() is the only method from basePrototye that we MUST orerride
    /// This method initializes the Action by setting the paths to the spawned prefabs
    /// </summary>
    public override void Initialize()
    {
        DestroyUtilities.RemoteDestroy(GameObject.Find("MinoanJar"));
        //This method sets the prefab that will be removed
        SetRemovePrefab("Lesson1/Stage0/Action0/MinoanJarRemove");
        //Sets hologram 
        SetHoloObject("Lesson1/Stage0/Action0/Hologram/HologramL1S0A0Hand");

        //Set Voice Actor to play after performing the Action
        SetPerformAction(() => { VoiceActor.PlayVoiceActor("excellent"); });

        base.Initialize();
    }

    /// <summary>
    /// In this Action we need to override Undo to spawn dummy jars cause the have been removed by Initialize()
    /// Instead of overriding Undo we can use SetUndoAction() and give as argument a function that loads the jar
    /// This function will trigger every time we Undo this Action
    /// </summary>
    public override void Undo()
    {
        Spawn("Lesson1/Stage0/Action0/MinoanJar").name = "MinoanJar";

        base.Undo();
    }

    /// <summary>
    /// Here we override the Perform funtion to delete the minoan jars since the next Action will spawn the removable ones.
    /// </summary>
    public override void Perform()
    {
        DestroyUtilities.RemoteDestroy(GameObject.Find("MinoanJar1"));
        DestroyUtilities.RemoteDestroy(GameObject.Find("MinoanJar2"));
        DestroyUtilities.RemoteDestroy(GameObject.Find("MinoanJar3"));
        DestroyUtilities.RemoteDestroy(GameObject.Find("MinoanJar4"));

        base.Perform();
    }
}
