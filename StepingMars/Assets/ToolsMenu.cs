using System.IO;
using UnityEditor;
using UnityEngine;

using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace StepingMars
{
    public static class ToolsMenu
    {
        [MenuItem(("Tools/Setup/Create Default Folders"))]
        public static void CreateDefaultFolders()
        {
            Dir("_Project", "Scripts", "Art", "Scenes");
            Refresh();
        }

        private static void Dir(string root, params string[] dir)
        {
            var fullpath = Combine(dataPath, root);
            foreach (var newDirectory in dir)
                CreateDirectory(Combine(fullpath, newDirectory));
        }
        
    }
}
