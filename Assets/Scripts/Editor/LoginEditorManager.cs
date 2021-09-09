using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(LoginManager))]
public class LoginEditorManager : Editor
{
    public GameObject roomManager;
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("connect to photon servers",MessageType.Info);
        LoginManager loginManager = (LoginManager)target;
        if (GUILayout.Button("connect"))
        {
            loginManager.connectToPhotonServer();
        }
    }
}
