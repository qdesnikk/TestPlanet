using MAGES.ActionPrototypes;

/// <summary>
/// Example of Remove Action with hand
/// </summary>
public class RemoveHandleAction : RemoveAction
{
    /// <summary>
    /// Initialize method overrides base.Initialize() and sets the prefab user will remove
    /// </summary>
    public override void Initialize()
    {
        //This method sets the prefab that will be removed
        SetRemovePrefab("Lesson1/Stage2/Action1/HandleRemove");

        base.Initialize();
    }
}
