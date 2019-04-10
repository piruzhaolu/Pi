using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Pi
{
    public static class StringHash
    {
        private static Dictionary<int, string> hashDic = new Dictionary<int, string>();

        /// <summary>
        /// HashKeyToString 仅在编辑器中可用
        /// </summary>
        public static string ToString(int key)
        {
            string v = string.Empty;
#if UNITY_EDITOR
            hashDic.TryGetValue(key, out v);
#endif
            return v;
        }


        /// <summary>
        /// 字符串hash函数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int ToHash(string name)
        {
            ////==========BKDRHash============

            int seed = 131;
            int hash = 0;

            for (int i = 0; i < name.Length; i++)
            {
                var a = name[i];
                hash = hash * seed + (int)a;
            }
            int returnHash = hash & 0x7FFFFFFF;
#if UNITY_EDITOR
            string mName;

            if (hashDic.TryGetValue(returnHash, out mName))
            {
                if (mName != name)
                {
                    Debug.LogError(name + "-HASH 冲突-" + mName);
                }
            }
            hashDic[returnHash] = name;
#endif
            return (hash & 0x7FFFFFFF);
        }


        public static long ToHash64(string name)
        {
            ////==========BKDRHash============

            int seed = 131;
            long hash = 0;

            for (int i = 0; i < name.Length; i++)
            {
                var a = name[i];
                hash = hash * seed + a;
            }
            long returnHash = hash & long.MaxValue;

            return returnHash;
        }
    }
}
