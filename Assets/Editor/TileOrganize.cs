using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class TileOrganize
{
    // Start is called before the first frame update
    static TileOrganize()
    {
        EditorApplication.hierarchyChanged += () =>
        {
            GameObject parent = GameObject.Find("Tile_folder");
            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tiles");

            foreach (GameObject tile in tiles)
            {
                if (tile.transform.parent == null)
                {
                    if (parent != null)
                    {
                        tile.transform.SetParent(parent.transform);
                    }
                }
                Vector3 localPos = tile.transform.position;
                if (Mathf.Abs(localPos.y) > 0.00001f)
                {
                    tile.transform.position = new Vector3(localPos.x, 0f, localPos.z);
                }
            }
        };
    }
}
