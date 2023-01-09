using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CraftEditor : EditorWindow
{
    private string name;
    private string description;
    private Item craftableItem;
    
    private ressourceCraft[] EditorRessourceCraft = new ressourceCraft[9];

    [MenuItem("Tools/Craft")]
    public static void WindowEditor()
    {
        EditorWindow window = GetWindow<CraftEditor>();
        window.titleContent = new GUIContent("Craft Editor");
    }
    void OnGUI ()
    {
        GUILayout.Label ("Name Item", EditorStyles.boldLabel);
        EditorGUILayout.TextArea("");
        
        GUILayout.Space(20f);
        
        GUILayout.Label ("Description Item", EditorStyles.boldLabel);
        EditorGUILayout.TextArea("");
        
        GUILayout.Space(20f);

        for (int i = 0; i < EditorRessourceCraft.Length; i++)
        {
            EditorRessourceCraft[i].positionCraft = (ItemPositionCraft)EditorGUILayout.EnumPopup("position Item " + i,EditorRessourceCraft[i].positionCraft);
            EditorRessourceCraft[i].item =
                (Item)EditorGUILayout.ObjectField( EditorRessourceCraft[i].item, typeof(Item)) as Item;
        }
        
        GUILayout.Space(20f);
        
        GUILayout.Label ("Crafting", EditorStyles.boldLabel);
        
        craftableItem = (Item)EditorGUILayout.ObjectField( craftableItem, typeof(Item)) as Item;
        
        GUILayout.Space(20f);
        
        GUILayout.Label ("Crafting Object", EditorStyles.boldLabel);
        GUILayout.Space(2f);
        if( GUILayout.Button("Create SD Object"))
            Debug.Log("Create Objct");
    }
}
