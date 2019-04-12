using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

namespace ExcelScriptableObject
{


    public class DynMember 
    {
        private MemberInfo _memberInfo;
        private FieldInfo _fieldInfo;
        private PropertyInfo _propertyInfo;

        private object _inst;

        public DynMember(MemberInfo info, object inst)
        {
            _memberInfo = info;
            _inst = inst;
        }

        public DynMember(FieldInfo info, object inst)
        {
            _fieldInfo = info;
            _inst = inst;
        }

        public DynMember(PropertyInfo info, object inst)
        {
            _propertyInfo = info;
            _inst = inst;
        }

        public DynMember Q(string name)
        {
            return new DynObject(GetValue()).Q(name);
        }

        public DynMember Q<T>(Func<T, bool> fun) where T : Attribute
        {
            return new DynObject(GetValue()).Q<T>(fun);
        }


        public void SetValue(object value)
        {
            if (_fieldInfo != null) _setValue(value, _fieldInfo);
            else if (_propertyInfo != null) _setValue( value, _fieldInfo);
        }

        private void _setValue(object value, FieldInfo info)
        {
            var vType = value.GetType();
            var infoType = info.FieldType;
            if (infoType.IsAssignableFrom(vType))
            {
                info.SetValue(_inst, value);
            } else
            {
                if (infoType.IsValueType)
                {
                    if (vType.IsValueType)
                    {
                        info.SetValue(_inst, Convert.ChangeType(value, infoType));
                    }
                    else
                    {
                        info.SetValue(_inst, Activator.CreateInstance(infoType));
                    }
                    
                } else
                {
                    info.SetValue(_inst, null);
                }
            }
        }



        public object GetValue()
        {
            if (_fieldInfo != null) return _fieldInfo.GetValue(_inst);
            else if (_propertyInfo != null) return  _propertyInfo.GetValue(_inst);
            return null;
        }

        





    }

}
