using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerTeleport : MonoBehaviour
{
    public Transform destination;


    private void OnTriggerEnter2D(Collider2D item)
    {
        
        if (item.CompareTag("Player"))
        {
            Teleport(item);
        }
    }

    private void Teleport(Collider2D player){
        player.transform.position = destination.position;
    }
}
