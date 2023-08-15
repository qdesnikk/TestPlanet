using MAGES.ActionPrototypes;

public class InsertJarAction : InsertAction
{
    public override void Initialize()
    {
        SetInsertPrefab("Optional/InsertJar/Action0/JarInteractable", "Optional/InsertJar/Action0/JarFinal");
        SetHoloObject("Optional/InsertJar/Action0/JarHologram");

        base.Initialize();
    }
}
