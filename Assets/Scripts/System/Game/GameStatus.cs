public class GameStatus 
{
    /// <summary>
    /// シーンステータスプロパティ
    /// </summary>
    public static SceneStatusReactiveProperty SceneStatusReactivePropety
    {
        get;  set;
    } = new SceneStatusReactiveProperty(SceneStatusEnum.Title);

    /// <summary>
    /// ゲームステータスプロパティ
    /// </summary>
    public static GameStatusReactiveProperty GameStatusReactivePropety
    {
        get;  set;
    } = new GameStatusReactiveProperty(GameStatusEnum.None);

    /// <summary>
    /// プレイヤーステータスプロパティ
    /// </summary>
    public static PlayerStatusReactiveProperty PlayerStatusReactiveProperty
    {
        get;  set;
    } = new PlayerStatusReactiveProperty(PlayerStatusEnum.None);
}
