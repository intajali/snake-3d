
public class GameConstants 
{
    public class Tags
    {
        public const string WALL = "WALL";
        public const string FOOD = "FOOD";
        public const string TAIL = "TAIL";
    }

    public enum Direction
    {
        LEFT = 0,
        RIGHT = 1,
        UP = 2,
        DOWN = 3,
        COUNT = 4,
    }

    public enum FoodType
    {
        TYPE_1 = 1,
        TYPE_2 = 2
    }

    public const string TOP_SCORE_KEY = "TopScore";

    public const string GAME_SCENE = "GamePlay";
    public const string MENU_SCENE = "MainMenu";
}
