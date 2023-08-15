using MAGES.ActionPrototypes;
using MAGES.UIManagement;
using MAGES.Utilities;
using UnityEngine;

/// <summary>
/// This is an example of Use Action
/// In this Action users are tasked with touching a prefab on a specified collider for a certain amount of time 
/// The developer can set their own prefab, use collider and specified amount of time.
/// </summary>
public class IncisionAreaDisinfectionActionExample : UseAction
{
    //Variable containing the UI, which explains the user what to do.
    GameObject ExplanationUI;

    /// <summary>
    /// Initialize() method overrides base.Initialize and sets the use prefab 
    /// </summary>
    public override void Initialize()
    {
        //This method spawns the explanation UI.
        ExplanationUI = InterfaceManagement.Get.SpawnCustomExtraExplanationNotification("LessonPrefabs/Lesson0/Stage0/Action3/IodineExplanationUI", null, false);

        //This method sets the use prefab (first argument) to be used on the use collider (second argument)
        SetUsePrefab("Lesson0/Stage0/Action3/PliersCotton", "Lesson0/Stage0/Action3/DisinfectionCollider");
        
        //This method spawns the corresponding hologram in the scene to aid the user
        SetHoloObject("Lesson0/Stage0/Action3/Holograms/PliersCottonHolo");

        base.Initialize();
    }

    /// <summary>
    /// Perform() method overrides base.Perform and sets the actions that will take place once the action is completed
    /// </summary>
    public override void Perform()
    {
        //This method destroys the explanation UI
        DestroyUtilities.RemoteDestroy(ExplanationUI);
        base.Perform();
    }

    /// <summary>
    /// Undo() method overrides base.Undo and sets the actions that will take place if the flow returns to the previous action
    /// </summary>
    public override void Undo()
    {
        //This method destroys the explanation UI
        DestroyUtilities.RemoteDestroy(ExplanationUI);
        base.Undo();
    }
}
