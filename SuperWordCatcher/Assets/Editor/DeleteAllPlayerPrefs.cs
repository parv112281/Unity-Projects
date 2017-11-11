using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// This is a script that enhances the Unity Editor (aka, Editor script)
public class DeleteAllPlayerPrefs : ScriptableObject {

    // Delete the player prefs after a confirmation dialog
    [MenuItem("Editor/Delete Player Prefs")]
    static void DeletePrefs()
    {
        if (EditorUtility.DisplayDialog("Delete all player preferences?", 
            "Are you sure you want to delete all the player preferences, this action cannot be undone?", 
            "Yes", "No"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
