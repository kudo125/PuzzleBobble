public class Enums
{
    public enum GameStatusEnum
    {
        None,
        ShotReady,
        ShotExecuted,
        SetBubble,
        Destroy,
        GameOver,
        Clear
    }

    public enum SceneStatusEnum
    {
        Title,
        Menu,
        Game
    }

    public enum InputStateEnum
    {
        Right,
        Left,
        Shot,
        Exit
    }
}
