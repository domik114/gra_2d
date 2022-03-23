using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    [SerializeField] private string sceneName;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            GameManager.instance.SaveState();
            // teleport the player
            SceneManager.LoadScene(sceneName);
        }
    }
}
