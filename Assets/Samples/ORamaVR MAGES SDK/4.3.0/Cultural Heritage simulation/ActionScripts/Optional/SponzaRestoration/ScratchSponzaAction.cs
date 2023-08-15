using MAGES.ActionPrototypes;
using MAGES.ToolManager.tool;
using MAGES.Utilities;
using UnityEngine;

/// <summary>
/// ToolAction Example
/// </summary>
public class ScratchSponzaAction : ToolAction
{
    GameObject physicalCollider;

    /// <summary>
    /// Initialize() method overrides base.Initialize and sets the Action
    /// </summary>
    public override void Initialize()
    {
        //Set the colliders that will trigger the perform when all touched by the tool
        //The second argument is the tooll needed to complete the Action
        SetToolActionPrefab("Optional/SponzaRestoration/Action1/RoofDirt_Tool_Collider_Prefab", ToolsEnum.Scalpel);
        //Error colliders are trigger colliders that will count an error when touched by a tool
        SetErrorColliders("Optional/SponzaRestoration/Action1/Colliders/ErrorColliders");
        //Physical collider for the Action
        physicalCollider = Spawn("Optional/SponzaRestoration/Action1/Colliders/PhysicalCollider");
        //Action's hologram
        SetHoloObject("Optional/SponzaRestoration/Action1/Hologram/hologram_scalpel");

        base.Initialize();
    }

    public override void Perform()
    {
        DestroyUtilities.RemoteDestroy(physicalCollider);
        base.Perform();
    }

    public override void Undo()
    {
        DestroyUtilities.RemoteDestroy(physicalCollider);
        base.Undo();
    }
}
