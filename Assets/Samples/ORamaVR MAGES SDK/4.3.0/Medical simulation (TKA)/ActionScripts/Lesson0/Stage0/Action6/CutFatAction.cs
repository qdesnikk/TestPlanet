using MAGES.ToolManager.tool;
using MAGES.ActionPrototypes;

/// <summary>
/// This is an example of Tool Action
/// In this Action users are tasked with touching a prefab with a pre-defined tool
/// The developer can set their own prefab and tool or use an existing one.
/// </summary>
public class CutFatAction : ToolAction
{
    /// <summary>
    /// Initialize() method overrides base.Initialize and sets the tool action prefab 
    /// </summary>
    public override void Initialize()
    {
        //This method sets the prefab on which the tool will be used (first argument) and the tool id which will be used (second argument)
        SetToolActionPrefab("Lesson0/Stage0/Action6/CutFatColliders", ToolsEnum.Scalpel);

        //This method spawns the corresponding hologram in the scene to aid the user
        SetHoloObject("Lesson0/Stage0/Action6/Hologram/HologramScalpelFat");

        //This method sets an action (or event) to be executed when the action is completed. In this case, the skin open animation is played
        SetPerformAction(MAGES.CharacterController.CharacterControllerTKA.instance.PlayOpenSkinFull);

        base.Initialize();
    }

}
