using MAGES.ActionPrototypes;
using UnityEngine;

/// <summary>
/// This is an example of Tool Action
/// In this Action users are tasked with touching a prefab with a pre-defined tool
/// The developer can set their own prefab and tool or use an existing one.
/// </summary>
public class DrillKneeAction : ToolAction
{
    public override void Initialize()
    {
        //Turn on xray
        XRayController.instance.SetXray(true);

        //Enable drill hole texture in case they are not active (from Undo) 
        GameObject.Find("Bone_drilled_cylinder").GetComponent<BoneDrillSmallPiece>().ToggleRenderer(true);

        //This method sets the prefab on which the tool will be used (first argument) and the tool id which will be used (second argument)
        SetToolActionPrefab("Lesson1/Stage0/Action0/DrillCollider", MAGES.ToolManager.tool.ToolsEnum.Drill);

        //This method spawns the corresponding hologram in the scene to aid the user
        SetHoloObject("Lesson1/Stage0/Action0/Hologram/DrillHolo");

        base.Initialize();
    }

    /// <summary>
    /// Perform() method overrides base.Perform and sets the actions that will take place once the action is completed
    /// </summary>
    public override void Perform()
    {
        //Turn off Xray
        XRayController.instance.SetXray(false);

        //Disable femur bone pieces
        GameObject.Find("Bone_drilled_cylinder").GetComponent<BoneDrillSmallPiece>().ToggleRenderer(false);
        base.Perform();
    }

    /// <summary>
    /// Undo() method overrides base.Undo and sets the actions that will take place if the flow returns to the previous action
    /// </summary>
    public override void Undo()
    {
        //Turn off Xray
        XRayController.instance.SetXray(false);

        //Reset leg animations
        MAGES.CharacterController.CharacterControllerTKA.instance.ResetRiseLeg();
        MAGES.CharacterController.CharacterControllerTKA.instance.ResetMovePattela();
        base.Undo();
    }
}

