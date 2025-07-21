using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTrigger : MonoBehaviour
{
    public float freezeDuration; // �󸮴� �ð� (��)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerState playerState = other.GetComponent<PlayerState>();
            
            StartCoroutine(FreezeForSeconds(playerState, freezeDuration));
            
        }
    }

    private IEnumerator FreezeForSeconds(PlayerState playerState, float duration)
    {
        playerState.isFreeze = true;
        yield return new WaitForSeconds(duration);
        playerState.isFreeze = false;
    }
}
