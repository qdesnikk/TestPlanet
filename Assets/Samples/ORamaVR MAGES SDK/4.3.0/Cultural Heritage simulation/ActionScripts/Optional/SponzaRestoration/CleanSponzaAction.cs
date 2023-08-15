using MAGES.ActionPrototypes;
using MAGES.Utilities;
using UnityEngine;

/// <summary>
/// Use Action Example
/// </summary>
public class CleanSponzaAction : UseAction {

    GameObject sponzaHandLock, physicalCollider;

    /// <summary>
    /// Initialize method overrides base.Initialize() and sets the use Action
    /// </summary>
    public override void Initialize()
    {
        //Set the interactable prefab which user will take and use it (touch collider) to perform the Action (1st argument)
        //Sets the collider which triggers the use Prefab. For more customization (CollisionStay time toperform) see prefab constructor(Unity editor) (2nd argument)
        SetUsePrefab("Optional/SponzaRestoration/Action0/cloth", "Optional/SponzaRestoration/Action0/Dust");
        //Sets physical colliders that will spawn on initialize
        //For this Action we need extra non triggered colliders since the model of Sponza dont have by default
        //These collider will be destroyed after perform/ Undo
        physicalCollider = Spawn("Optional/SponzaRestoration/Action0/PhysicalCollider");
        //Sets the hologram for current Action
        SetHoloObject("Optional/SponzaRestoration/Action0/Hologram/hologram_clotha");

        if (sponzaHandLock)
            DestroyUtilities.RemoteDestroy(sponzaHandLock);

        sponzaHandLock = Spawn("Optional/SponzaRestoration/Action0/SponzaHandLock");

        base.Initialize();
    }

    public override void Perform()
    {
        DestroyUtilities.RemoteDestroy(sponzaHandLock);
        DestroyUtilities.RemoteDestroy(physicalCollider);

        base.Perform();
    }

    public override void Undo()
    {
        DestroyUtilities.RemoteDestroy(sponzaHandLock);
        DestroyUtilities.RemoteDestroy(physicalCollider);

        base.Undo();
    }
}
