using UniRx;

public enum GameStatusEnum
{
    None,
    LoadedStage,
    GameStart,
    Idle,
    ConnectionCheck,
    Destroy,
    Hanging,
    GameOver,
    Clear
}

public enum SceneStatusEnum
{
    Title,
    Menu,
    Game
}

public enum PlayerStatusEnum
{
    None,
    SetBubble,
    ShotReady,
    ShotExecuted

}

public class GameStatusReactiveProperty : ReactiveProperty<GameStatusEnum>
{
    public GameStatusReactiveProperty() { }
    public GameStatusReactiveProperty(GameStatusEnum initialValue) : base(initialValue) { }
}

public class SceneStatusReactiveProperty : ReactiveProperty<SceneStatusEnum>
{
    public SceneStatusReactiveProperty() { }
    public SceneStatusReactiveProperty(SceneStatusEnum initialValue) : base(initialValue) { }
}

public class PlayerStatusReactiveProperty : ReactiveProperty<PlayerStatusEnum>
{
    public PlayerStatusReactiveProperty() { }
    public PlayerStatusReactiveProperty(PlayerStatusEnum initialValue) : base(initialValue) { }
}
