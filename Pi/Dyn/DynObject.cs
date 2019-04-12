using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

namespace ExcelScriptableObject
{


    public class DynObject
    {
        private object _inst;


        public DynObject(object inst)
        {
            _inst = inst;
        }

        public object this[string name]
        {
            get {
                return Q(name)?.GetValue();
            }
            set {

                Q(name)?.SetValue(value);
            }
        }



        public DynMember Q(string name)
        {
            var field = _inst.GetType().GetField(name);
            if (field == null)
            {
                var property = _inst.GetType().GetProperty(name);
                if (property == null) return null;
                return new DynMember(property, _inst);
            }
            return new DynMember(field, _inst);
        }




        public DynMember Q<T>(Func<T, bool> fun) where T:Attribute
        {
            var ms = _inst.GetType().GetMembers();
            for (int i = 0; i < ms.Length; i++)
            {
                var m = ms[i];
                var attrs = m.GetCustomAttributes();
                foreach (var item in attrs)
                {
                    if (item.GetType() == typeof(T) && fun((T) item))
                    {
                        if (m.MemberType == MemberTypes.Field)
                        {
                            return new DynMember((FieldInfo)m, _inst);
                        }else if(m.MemberType == MemberTypes.Property)
                        {
                            return new DynMember((PropertyInfo)m, _inst);
                        }
                    }
                }
            }
            return null;
        }

    }

}
