
//using UnityEngine;
//using System;
//using System.Collections.Generic;
//using System.Reflection;

//namespace ExcelScriptableObject
//{
    

//    public class DynType
//    {
//        private Type _type;

//        public DynType(Type type)
//        {
//            _type = type;
//            var ms = _type.GetMembers();
//            _list = new List<(Attribute, MemberInfo)>();
//            for (int i = 0; i < ms.Length; i++)
//            {
//                var m = ms[i];
//                var attrs = m.GetCustomAttributes();
//                foreach (var item in attrs)
//                {
                    
//                    Debug.Log(item.ToString());
//                }


//            }
//        }

//        private List<(Attribute, MemberInfo)> _list;



//    }
//}
