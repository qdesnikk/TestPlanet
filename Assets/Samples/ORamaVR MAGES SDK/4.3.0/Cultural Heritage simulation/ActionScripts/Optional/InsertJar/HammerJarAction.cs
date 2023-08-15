using MAGES.ActionPrototypes;


public class HammerJarAction : ToolAction
{

    public override void Initialize()
    {
        SetToolActionPrefab("Optional/InsertJar/Action1/JarHitMallet", MAGES.ToolManager.tool.ToolsEnum.Mallet);
        
        SetHoloObject("Optional/InsertJar/Action1/JarMalletHologram");

        base.Initialize();
    }
}
