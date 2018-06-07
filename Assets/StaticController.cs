using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticController : MonoBehaviour {


    void Start()
    {
        Cursor.SetCursor(cursorDefault, new Vector2(8, 32), CursorMode.Auto);  
    }

    public enum GameObjectType
    {
        FIRENDLY,
        ENEMY,
        BOTH
    };

    [Header("Cursor")]
    public Texture2D cursorDefault;
    public Texture2D cursorClicked;

    [Header("Box")]
    public Sprite boxLight;
    public  Sprite boxDark;

    [Header("IronBox")]
    public Sprite ironBoxLight;
    public Sprite ironBoxDark;


    [Header("Rock")]
    public Sprite rockLight;
    public Sprite rockDark;
    [Header("Crossbow")]
    public Sprite crossbowLight;
    public Sprite crossbowDark;

    [Header("Player Healths")]
    public int PLAYER_LIGHT_HEALTH = 5;
    public int PLAYER_DARK_HEALTH = 5;

    [Header("Player Damage")]
    public int PLAYER_DAMAGE = 5;

    [Header("Enemy Healths")]
    public int ENEMY_GREEN_HEALTH = 1;
    public int ENEMY_PURPLE_HEALTH = 1;

    [Header("Crossbow - Arrow Damage")]
    public int CROSSBOW_ARROW_DAMAGE = 2;

    [Header("Environment")]
    public int BOX_HEALTH = 1;
    public int IRON_BOX_HEALTH = 4;
    public int ROCK_HEALTH = 3;
    public int CROSSBOW_HEALTH = 100;


    [Header("Prefabs")]
    public GameObject SmokePrefab;


    private static StaticController s_Instance;

    public static StaticController instance
    {
        get {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(StaticController)) as StaticController;
            }

            if (s_Instance == null)
            {
                GameObject obj = new GameObject("StaticController");
                s_Instance = obj.AddComponent(typeof(StaticController)) as StaticController;
            }

            return s_Instance;
        }
    }

    void OnApplicationQuit()
    {
        s_Instance = null;
    }


    public class GameObjectMapItem
    {
        public int value;
        public string tag;

        public GameObjectMapItem(string tag, int value)
        {
            this.tag = tag;
            this.value = value;
        }
    }
}
