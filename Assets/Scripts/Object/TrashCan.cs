using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public GameObject Player;
    private PlayerState state;
    // Start is called before the first frame update
    void Start()
    {
        state = Player.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                
                if (hit.transform == transform)
                {
                    Debug.Log("Clicked: " + hit.transform.name);
                    Debug.Log("Trash Can clicked!");
                    if (!state.canclicked)
                    {
                        state.RealPos = Player.transform.position;
                        state.isFreeze = true;
                        Player.transform.position = new Vector3(100, 0, 100);
                        state.canclicked = true;
                    }

                    
                }
            }
        }
    }
}
