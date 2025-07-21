using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class WallOrganize
{
    // Start is called before the first frame update
    static WallOrganize()
    {
        EditorApplication.hierarchyChanged += () =>
        {
            GameObject parent = GameObject.Find("WallFolder");
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Walls");

            foreach (GameObject wall in walls)
            {
                if (wall.transform.parent == null)
                {
                    if (parent != null)
                    {
                        wall.transform.SetParent(parent.transform);
                    }
                }
                Vector3 localPos = wall.transform.position;
                if (Mathf.Abs(localPos.y) > 0.00001f)
                {
                    wall.transform.position = new Vector3(localPos.x, 4f, localPos.z);
                }
            }
        };
    }
}