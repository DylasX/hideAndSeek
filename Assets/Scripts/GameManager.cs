using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //can access game manager instance everywhere
    public static GameManager instance;

    private void Awake() 
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);


    }

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    public Player player;
    public FloatingTextManager floatingTextManager;
    public int coins;
    public int experience;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Save state
    /*
     * INT preferedSkin 
     * INT coins
     * INT experience
     * INT weapons
     * 
     */
    public void SaveState()
    {
        string data = "";
        data += "0" + "|";
        data += coins.ToString() + "|";
        data += experience.ToString() + "|";
        data += "0";
        PlayerPrefs.SetString("SaveState", data);
        Debug.Log("Saving game");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        coins = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        experience = int.Parse(data[3]);
        Debug.Log("Loading game");
    }

}
