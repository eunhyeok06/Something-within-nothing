using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;


[InitializeOnLoad]
public static class AutoComponent
{
    static AutoComponent()
    {
        EditorApplication.hierarchyChanged += () =>
        {
            foreach (GameObject obj in Object.FindObjectsOfType<GameObject>())
            {
                if (obj.CompareTag("Object"))
                {

                    


                    if (obj.GetComponent<VolumeManage>() == null)
                    {
                        Undo.AddComponent<VolumeManage>(obj);
                    }
                    if (obj.GetComponent<AudioSource>() == null)
                    {
                        Undo.AddComponent<AudioSource>(obj);
                    }
                    if (obj.GetComponent<Rigidbody>() == null)
                    {
                        Undo.AddComponent<Rigidbody>(obj);
                    }
                }
            }
        };
    }
}