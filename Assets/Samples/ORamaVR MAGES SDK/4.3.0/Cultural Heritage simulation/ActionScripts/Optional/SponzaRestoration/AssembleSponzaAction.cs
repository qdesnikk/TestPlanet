using MAGES.ActionPrototypes;
using MAGES.sceneGraphSpace;
using UnityEngine;

/// <summary>
/// This is an Optiona Action that is used to branch for scenario branching
/// In our case this Action is spawned along with the AssembleKnossosAction
/// If the user decides to perform this Action instead of the Knossos one, the lesson "Sponza Restoration" will replace the lesson "Knossos Lesson"
/// In this way we can change the scenegraph realtime.
/// </summary>
public class AssembleSponzaAction : InsertAction
{
    public override void Initialize()
    {
        SetInsertPrefab("Lesson0/Stage1/Action0/SponzaInteractable", "Lesson0/Stage1/Action0/SponzaFinal");
        SetHoloObject("Lesson0/Stage1/Action0/Hologram/HologramSponzaFinal");

        //It is important to add this line if your perform method changes the scengergraph runtime (eg uses the ReplaceNoreRuntime)
        GetComponent<ActionProperties>().actionType = ActionType.OptionalConvertedToNormal;

        base.Initialize();
    }

    //If user Perfroms the Alt Path (this Action) then the other one is Destroyed
    public override void Perform()
    {
        //The lesson "Sponza Restoration" will replace the lesson "Knossos Lesson" if the user performs this Action
        ScenegraphTraverse.ReplaceNodeRuntime("Knossos Lesson", "Sponza Restoration");

        //Alternatevely you can use: DeleteNodeRuntime or AddNodeRuntime
        //Alternative implementations (with different results)

        //Adds the "Sponza Restoration" Lesson after the current lesson
        //ScenegraphTraverse.AddNodeRuntime("Sponza Restoration");

        //Deletes the "Knossos Lesson" lesson
        //ScenegraphTraverse.DeleteNodeRuntime("Knossos Lesson");

        base.Perform();       
    }

}
