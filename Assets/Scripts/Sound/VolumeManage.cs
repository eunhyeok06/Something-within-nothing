using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VolumeManage : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform Player;
    private AudioSource audioSource;
    private float maxDistance = 8f;
    void Start()
    {
        GameObject target = GameObject.FindWithTag("Player");
        if (target != null)
        {
            Player = target.transform;
        }
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            enabled = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Y축 제거한 평면 위치
        Vector3 playerFlat = new Vector3(Player.position.x, 0f, Player.position.z);
        Vector3 sourceFlat = new Vector3(transform.position.x, 0f, transform.position.z);

        // 수평 거리
        float distance = Vector3.Distance(playerFlat, sourceFlat);
        float basevolume = Mathf.Clamp01(1f - Mathf.Pow((distance / maxDistance), 0.75f));

        // 시야 방향 계산 (수평 기준)
        Vector3 playerForward = new Vector3(Player.forward.x, 0f, Player.forward.z).normalized;
        Vector3 directionToSource = (sourceFlat - playerFlat).normalized;

        float dot = Vector3.Dot(playerForward, directionToSource);
        float viewFactor = Mathf.Lerp(0.1f, 1f, Mathf.Pow(Mathf.Clamp01((dot + 1f) / 2f), 20f));

        // 최종 볼륨
        float volume = basevolume * viewFactor;
        audioSource.volume = volume;
    }
}
