namespace Maze.Enums
{
    public enum SceneIndex : int
    {
        Main = 0,
        Gameplay = 1
    }

    public enum InputActions
    {
        Movement,
        Look,
        LBM,
        RBM,
    }

    public enum EnemyStates
    {
        Idle,
        Patrol,
        Chase,
        Reset,
    }

    public enum GameStates
    {
        Running,
        GameOver,
        WinGame,
    }
}