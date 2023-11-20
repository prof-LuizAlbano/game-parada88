using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class CreateFolders : EditorWindow {
    //private static string projectName = "PROJECT_NAME";

    [MenuItem("Assets/Create Default Folders")]
    private static void SetUpFolders()
    {
        CreateAllFolders();
    }

    private static void CreateAllFolders()
    {
        List<string> folders = new List<string> {
            "Animations",
            "Audio",
            "Editor",
            "Materials",
            "Meshes",
            "Prefabs",
            "Scripts",
            "Scenes",
            "Shaders",
            "Textures",
            "ThirdParty",
            "UI"
        };

        foreach ( string folder in folders ) {
            if (!Directory.Exists( "Assets/" + folder ) ) {
                Directory.CreateDirectory( "Assets/" + folder );
                using ( FileStream fs = File.Create( "Assets/" + folder + "/.keep" ) );
            } 
        }

        List<string> uiFolders = new List<string> {
            "Assets",
            "Fonts",
            "Icon"
        };
        
        foreach ( string subfolder in uiFolders ) {
            if ( !Directory.Exists( "Assets/UI/" + subfolder ) ) {
                Directory.CreateDirectory( "Assets/UI/" + subfolder );
                using ( FileStream fs = File.Create( "Assets/UI/" + subfolder + "/.keep" ) );
            }
        }

        AssetDatabase.Refresh();
    }

}