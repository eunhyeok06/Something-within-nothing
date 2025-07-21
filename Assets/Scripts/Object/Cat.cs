using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip catsound;
    public AudioClip finish;

    private bool hasfinished = false;
    private bool Wait = false;

    public GameObject Player;
    public GameObject freezetile;
    private int touchcount = 0;
    private int maxtouch = 10;

    private PlayerState state;
    private OnlyFreeze freezing;

    void Start()
    {
        state = Player.GetComponent<PlayerState>();
        freezing = freezetile.GetComponent<OnlyFreeze>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform && !Wait)
                {
                    if (!hasfinished) touchcount++;
                    Debug.Log(touchcount);

                    if (touchcount < maxtouch)
                    {
                      
                        sfxSource.pitch = Mathf.Min(1f + (touchcount * 0.015f), 1.5f);
                        sfxSource.PlayOneShot(catsound);
                        Wait = true;
                        StartCoroutine(Waiting(catsound.length/3, 1));

                    }

                    if (touchcount == maxtouch && !hasfinished)
                    {
                        sfxSource.pitch = 1f; 
                        sfxSource.PlayOneShot(finish);
                        hasfinished = true;
                        touchcount = 0;
                        StartCoroutine(Waiting(finish.length, 0));
                        freezing.hasTriggered = true;
                    }
                }
            }
        }
    }

    private IEnumerator Waiting(float waittime, int command)
    {
        yield return new WaitForSeconds(waittime);
        if (command == 0)
        {
            state.isFreeze = false;

        }
        if(command == 1)
        {
            Wait = false;
        }
    }
}