using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // only one instance at time
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // resources for the game
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // references
    public Player player;
    // public Weapon weapon;

    // logic
    public int pesos;
    public int experiance;

    /*
     * INT preferedSkin
     * INT pesos
     * INT experiance
     * INT weaponLevel
     */
    public void SaveState()
    {
        string save = "";

        save += "0" + "|";
        save += pesos.ToString() + "|";
        save += experiance.ToString() + "|";
        save += "0";

        PlayerPrefs.SetString("SaveState", save);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // change player skin
        pesos = int.Parse(data[1]);
        experiance = int.Parse(data[2]);
        // weapon lever

        Debug.Log("LoadState");
    }
}
