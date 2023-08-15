using MAGES.ActionPrototypes;
using MAGES.Utilities;
using UnityEngine;

/// <summary>
/// This is an example of Combined Action
/// In this Action users are tasked with performing different smaller sub-actions, which are parts of a larger action 
/// The developer can set their own number of sub-actions (all action types supported by MAGES SDK can be used as sub-actions)
/// </summary>
public class AnaesthesiaInjectionAction : CombinedAction
{
    /// <summary>
    /// Initialize() method overrides base.Initialize and sets the sub-Actions 
    /// </summary>
    public override void Initialize()
    {
        //You will see below the Actions have the same functionality as if they were written in a unique file each one
        //The only difference is the syntax of the Actions, functionality remains the same

        // (Insert Action) Attach syringe to position
        InsertAction attachSyringe = gameObject.AddComponent<InsertAction>();
        {
            attachSyringe.SetInsertPrefab("Lesson0/Stage0/Action2/SyringeInteractable", "Lesson0/Stage0/Action2/SyringeFinal");
            attachSyringe.SetHoloObject("Lesson0/Stage0/Action2/Holograms/SyringeHolo");
        }
        //--------------------------------------------------------------------------------------------
        // (Pump Action) Use the syringe to apply anaesthesia to the patient
        //The Pump Action is used in situation we want to press/squeeze a 3D model to perform the Action
        //In this case the user needs to press the syringe to apply anaesthesia to the patient
        //To perform the Action hover the syringe with your controller and press the trigger button
        PumpAction applyAnaesthesia = gameObject.AddComponent<PumpAction>();
        {
            //Sets the pump prefabs
            //To set your own Pump prefab you can take this one as a template
            applyAnaesthesia.SetPumpPrefab("Lesson0/Stage0/Action2/SyringePump");

            //Pump Actions support multiple pumps within the same Action
            //The developer can set multiple pumps to be completed
            //In case that multiple pump prefabs are set the Action will perform when all of the pump prefabs are pressed (sequence does not matter)
        }
        //--------------------------------------------------------------------------------------------
        // (Remove Action) Remove syringe
        RemoveAction removeSyringe = gameObject.AddComponent<RemoveAction>();
        {
            removeSyringe.SetRemovePrefab("Lesson0/Stage0/Action2/SyringeRemove");
        }


        //This function is mandatory for the Combined Actions to set the sequence of the sub-Action
        //In this way se set the order of the sub-Actions
        InsertIActions(attachSyringe, applyAnaesthesia, removeSyringe);

        base.Initialize();
    }

}
