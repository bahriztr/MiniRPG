using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entry : MonoBehaviour
{
    [Header("Scene Info")]
    [SerializeField] private string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When player collides this gate, scene gonna change
        if(collision.name == "Player")
            SceneManager.LoadScene(sceneName);
    }
}
