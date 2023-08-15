using MAGES.ActionPrototypes;
using MAGES.ToolManager.tool;
using MAGES.UIManagement;
using MAGES.Utilities;
using UnityEngine;

/// <summary>
/// This is an example of Tool Action
/// In this Action users are tasked with touching a prefab with a pre-defined tool
/// The developer can set their own prefab and tool or use an existing one.
/// </summary>
public class CauteriseBloodspotsAction : ToolAction
{
    //Variable containing the UI, which explains the user what to do.
    private GameObject notification;

    //Variable containing a collider, which spawns on the leg.
    private GameObject fasciaPhysicalCollider;

    /// <summary>
    /// Initialize() method overrides base.Initialize and sets the tool action prefab 
    /// </summary>
    public override void Initialize()
    {
        //This method sets the prefab on which the tool will be used (first argument) and the tool id which will be used (second argument)
        SetToolActionPrefab("Lesson0/Stage0/Action5/BloodSpotsColliders", ToolsEnum.Cauterizer);

        //This method spawns the collider.
        fasciaPhysicalCollider = Spawn("Lesson0/Stage0/Action5/FasciaPhysicalCollider");

        if (!notification)
            //This method spawns the explanation UI.
            notification = InterfaceManagement.Get.SpawnCustomExtraExplanationNotification("LessonPrefabs/Lesson0/Stage0/Action5/CauteryExplanationUI", null, false);

        base.Initialize();
    }

    /// <summary>
    /// Perform() method overrides base.Perform and sets the actions that will take place once the action is completed
    /// </summary>
    public override void Perform()
    {
        //This method destroys the explanation UI
        DestroyUtilities.RemoteDestroy(notification);

        base.Perform();
    }

    /// <summary>
    /// Undo() method overrides base.Undo and sets the actions that will take place if the flow returns to the previous action
    /// </summary>
    public override void Undo()
    {
        //This method resets the cut animation for the leg
        MAGES.CharacterController.CharacterControllerTKA.instance.ResetCutAnimation();

        //This method destroys the explanation UI
        DestroyUtilities.RemoteDestroy(notification);

        //This method destroys the collider that was spawned during the action initialization
        DestroyUtilities.RemoteDestroy(fasciaPhysicalCollider);

        base.Undo();
    }

}

