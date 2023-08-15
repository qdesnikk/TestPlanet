using MAGES.ActionPrototypes;

/// <summary>
/// Example of Insert Action
/// </summary>
public class InsertMetalRodAction : InsertAction
{
    /// <summary>
    /// Initialize method overrides base.Initialize() and sets the prefab user will insert
    /// </summary>
    public override void Initialize()
    {
        //This method sets the interactable prefab (first argument) and the final prefab (second argument)
        SetInsertPrefab("Lesson1/Stage2/Action0/MetalRodInteractable", "Lesson1/Stage2/Action0/MetalRodFinal");

        //This method spawns the corresponding hologram in the scene to aid the user
        SetHoloObject("Lesson1/Stage2/Action0/MetalRodHologram");

        base.Initialize();
    }
}
