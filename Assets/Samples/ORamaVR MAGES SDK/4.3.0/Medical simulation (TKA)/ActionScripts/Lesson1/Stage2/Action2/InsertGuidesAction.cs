using MAGES.ActionPrototypes;
using UnityEngine;
using static MAGES.ActionPrototypes.InsertAction;

/// <summary>
/// This is an example of Combined Action
/// In this Action users are tasked with performing different smaller sub-actions, which are parts of a larger action 
/// The developer can set their own number of sub-actions (all action types supported by MAGES SDK can be used as sub-actions)
/// </summary>
public class InsertGuidesAction : CombinedAction
{
    //These variables are used to keep the results returned from the initialization of the insert actions
    private InsertGroup alingment, cuttingBlock;

    /// <summary>
    /// Initialize() method overrides base.Initialize and sets the sub-Actions 
    /// </summary>
    public override void Initialize()
    {
        //InsertAction sub-Action
        InsertAction insertAllignmentGuide = gameObject.AddComponent<InsertAction>();
        {
            alingment = insertAllignmentGuide.SetInsertPrefab("Lesson1/Stage2/Action2/FemoralGuideInteractable", "Lesson1/Stage2/Action2/FemoralGuideFinal");
            insertAllignmentGuide.SetHoloObject("Lesson1/Stage2/Action2/FemoralGuideHologram");
            insertAllignmentGuide.SetPerformAction(() => alingment.finalPrefab.GetComponent<Animation>().Play("AlignmentAnimation"));
        }
        //--------------------------------------------------------------------------------------------
        //InsertAction sub - Action
        InsertAction insertCuttingBlock = gameObject.AddComponent<InsertAction>();
        {
            cuttingBlock = insertCuttingBlock.SetInsertPrefab("Lesson1/Stage2/Action2/CuttingBlockInteractable", "Lesson1/Stage2/Action2/CuttingBlockFinal");
            insertCuttingBlock.SetHoloObject("Lesson1/Stage2/Action2/CuttingBlockHologram");
            insertCuttingBlock.SetPerformAction(() => cuttingBlock.finalPrefab.GetComponent<Animation>().Play("CuttingBlockAnimation"));
        }

        //This function is mandatory for the Combined Actions to set the sequence of the sub-Action
        //In this way se set the order of the sub-Actions
        InsertIActions(insertAllignmentGuide, insertCuttingBlock);

        base.Initialize();
    }
}
