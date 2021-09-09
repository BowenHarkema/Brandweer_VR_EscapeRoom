using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))]
public class WorldEditorManager : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("create and join a room", MessageType.Info);
        RoomManager roomManager = (RoomManager)target;
        if (GUILayout.Button("CreateRoom"))
        {
            roomManager.JoinRandomRoom();
        }
    }
    // Start is called before the first frame update

}
