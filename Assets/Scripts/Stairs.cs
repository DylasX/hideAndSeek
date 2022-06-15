using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : Collidable
{
    // Start is called before the first frame update
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "mainPlayer")
        {
            //next scene
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            //when have more than one UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            UnityEngine.SceneManagement.SceneManager.LoadScene("dungeon1");
        }
    }
}
