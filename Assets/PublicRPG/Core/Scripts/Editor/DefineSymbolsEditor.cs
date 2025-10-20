#if UNITY_EDITOR
using UnityEditor;
using System.Linq;

namespace PublicRPG.Editor
{
    [InitializeOnLoad]
    public class DefineSymbolsEditor
    {
        static DefineSymbolsEditor()
        {
            UpdateScriptingDefines();
        }

       private static void UpdateScriptingDefines()
{
    var target = EditorUserBuildSettings.selectedBuildTargetGroup;
    var namedTarget = UnityEditor.Build.NamedBuildTarget.FromBuildTargetGroup(target);
    var defines = PlayerSettings.GetScriptingDefineSymbols(namedTarget).Split(';').ToList();

    // Check for Quest Machine
    if (TypeExists("PixelCrushers.QuestMachine.Quest"))
    {
        AddDefine(defines, "QUEST_MACHINE_INSTALLED");
    }
    else
    {
        RemoveDefine(defines, "QUEST_MACHINE_INSTALLED");
    }

    // Check for Dialogue System
    if (TypeExists("PixelCrushers.DialogueSystem.DialogueManager"))
    {
        AddDefine(defines, "DIALOGUE_SYSTEM_INSTALLED");
    }
    else
    {
        RemoveDefine(defines, "DIALOGUE_SYSTEM_INSTALLED");
    }

    // Check for Love/Hate
    if (TypeExists("PixelCrushers.LoveHate.FactionManager"))
    {
        AddDefine(defines, "LOVE_HATE_INSTALLED");
    }
    else
    {
        RemoveDefine(defines, "LOVE_HATE_INSTALLED");
    }

    // Check for Inventory Engine
    if (TypeExists("MoreMountains.InventoryEngine.Inventory"))
    {
        AddDefine(defines, "INVENTORY_ENGINE_INSTALLED");
    }
    else
    {
        RemoveDefine(defines, "INVENTORY_ENGINE_INSTALLED");
    }

    // Check for Easy Save
    if (TypeExists("ES3Settings"))
    {
        AddDefine(defines, "EASY_SAVE_INSTALLED");
    }
    else
    {
        RemoveDefine(defines, "EASY_SAVE_INSTALLED");
    }

    // Use the new API
    PlayerSettings.SetScriptingDefineSymbols(namedTarget, string.Join(";", defines.ToArray()));
}

        private static bool TypeExists(string typeName)
        {
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var type = assembly.GetType(typeName);
                if (type != null) return true;
            }
            return false;
        }

        private static void AddDefine(System.Collections.Generic.List<string> defines, string define)
        {
            if (!defines.Contains(define))
            {
                defines.Add(define);
            }
        }

        private static void RemoveDefine(System.Collections.Generic.List<string> defines, string define)
        {
            if (defines.Contains(define))
            {
                defines.Remove(define);
            }
        }
    }
}
#endif