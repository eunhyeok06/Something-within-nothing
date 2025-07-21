using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyMelt : MonoBehaviour
{
    private bool hasTriggered = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        if (other.CompareTag("Player"))
        {
            PlayerState playerState = other.GetComponent<PlayerState>();
            hasTriggered = true;
            playerState.isFreeze = false;

        }
    }
}