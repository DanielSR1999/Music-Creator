using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class DeleteData
{
    [MenuItem("Music Creator/Delete Data")]

    static void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}
