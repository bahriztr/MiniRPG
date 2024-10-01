using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Info")]
    [SerializeField] private Transform spawnPos;

    private void Start()
    {
        SetPlayerPosition();
    }

    //Sets player' s position when player collide with gates
    private void SetPlayerPosition()
    {
        if (Player.instance != null)
        {
            Player.instance.transform.position = spawnPos.position;
        }
        else
        {
            Debug.LogError("Player instance not found");
        }
    }
}
