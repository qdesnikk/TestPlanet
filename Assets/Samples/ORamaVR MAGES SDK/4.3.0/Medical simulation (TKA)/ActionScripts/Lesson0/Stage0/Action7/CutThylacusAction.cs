using MAGES.ActionPrototypes;
using MAGES.ToolManager.tool;

/// <summary>
/// This is an example of Tool Action
/// In this Action users are tasked with touching a prefab with a pre-defined tool
/// The developer can set their own prefab and tool or use an existing one.
/// </summary>
public class CutThylacusAction : ToolAction
{
    /// <summary>
    /// Initialize() method overrides base.Initialize and sets the tool action prefab 
    /// </summary>
    public override void Initialize()
    {
        //This method sets the prefab on which the tool will be used (first argument) and the tool id which will be used (second argument)
        SetToolActionPrefab("Lesson0/Stage0/Action7/CutThylacusColliders", ToolsEnum.Scalpel);

        //This method spawns the corresponding hologram in the scene to aid the user
        SetHoloObject("Lesson0/Stage0/Action7/Hologram/HologramThylacus");

        base.Initialize();
    }

    /// <summary>
    /// Perform() method overrides base.Perform and sets the actions that will take place once the action is completed
    /// </summary>
    public override void Perform()
    {
        //This method plays the move pattela animation
        MAGES.CharacterController.CharacterControllerTKA.instance.PlayMovePattela();

        //This method plays the raise leg animation
        MAGES.CharacterController.CharacterControllerTKA.instance.PlayRiseLeg();

        base.Perform();
    }

    /// <summary>
    /// Undo() method overrides base.Undo and sets the actions that will take place if the flow returns to the previous action
    /// </summary>
    public override void Undo()
    {
        //This method resets the open skin animation
        MAGES.CharacterController.CharacterControllerTKA.instance.ResetOpenSkinFull();

        base.Undo();
    }
}
