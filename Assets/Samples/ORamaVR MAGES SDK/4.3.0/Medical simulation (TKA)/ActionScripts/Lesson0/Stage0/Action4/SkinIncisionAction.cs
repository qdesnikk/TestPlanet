using MAGES.ActionPrototypes;

/// <summary>
/// This is an example of Tool Action
/// In this Action users are tasked with touching a prefab with a pre-defined tool
/// The developer can set their own prefab and tool or use an existing one.
/// </summary>
public class SkinIncisionAction : ToolAction
{
    /// <summary>
    /// Initialize() method overrides base.Initialize and sets the tool action prefab 
    /// </summary>
    public override void Initialize()
    {
        //This method sets the prefab on which the tool will be used (first argument) and the tool id which will be used (second argument)
        SetToolActionPrefab("Lesson0/Stage0/Action4/CutCollider", MAGES.ToolManager.tool.ToolsEnum.Scalpel);

        //This method spawns the corresponding hologram in the scene to aid the user
        SetHoloObject("Lesson0/Stage0/Action4/Hologram/HologramScalpel");

        //The following methods set an action (or event) to be executed when the action is completed. In this case, the leg cut animations are played
        SetPerformAction(MAGES.CharacterController.CharacterControllerTKA.instance.PlayCut1Animation, 1);
        SetPerformAction(MAGES.CharacterController.CharacterControllerTKA.instance.PlayCut2Animation, 2);
        SetPerformAction(MAGES.CharacterController.CharacterControllerTKA.instance.PlayCut3Animation, 3);
        SetPerformAction(MAGES.CharacterController.CharacterControllerTKA.instance.PlayCut4Animation, 4);

        base.Initialize();
    }

}
