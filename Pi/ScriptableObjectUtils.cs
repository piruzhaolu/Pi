using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Pi
{
    public class ScriptableObjectUtils
    {
        public static ScriptableObject CreatAsset(string name, Object tar)
        {
            ScriptableObject v = null;
            try
            {
                v = ScriptableObject.CreateInstance(name);
            }
            catch (System.Exception)
            {
                throw;
            }
            v.name = name;
            AssetDatabase.AddObjectToAsset(v, tar);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(tar));
            return v;
        }
    }
}