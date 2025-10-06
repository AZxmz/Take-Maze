using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// PlayerPrefsデータ管理: データの保存と読み取りの統合管理
/// </summary>
public class PlayerPrefsDataManager
{
    private static PlayerPrefsDataManager instance = new PlayerPrefsDataManager();

    public static PlayerPrefsDataManager Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerPrefsDataManager()
    {

    }

  
    public void SaveData(object data, string keyName)
    {
        // Type を使用して渡されたデータオブジェクトのすべてのフィールドを取得します
        // 次に PlayerPrefs と組み合わせて保存します

        Type dataType = data.GetType();
        FieldInfo[] fieldInfos = dataType.GetFields();



        string saveKeyName = "";
        FieldInfo fieldInfo;
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            fieldInfo = fieldInfos[i];
            // ルールを定義する
            // keyName_data type_field type_field name
            saveKeyName = keyName + "_" + dataType.Name +
                "_" + fieldInfo.FieldType.Name + "_" + fieldInfo.Name;

            SaveValue(fieldInfo.GetValue(data), saveKeyName);
        }

        PlayerPrefs.Save();

    }


    private void SaveValue(object value, string keyName)
    {
        Type fieldType = value.GetType();

        
        if (fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (fieldType == typeof(string))
        {
            PlayerPrefs.SetString(keyName, value.ToString());
        }
        else if (fieldType == typeof(bool))
        {

            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }

        //リストの親クラスで判断する
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {

            IList list = value as IList;
            PlayerPrefs.SetInt(keyName, list.Count);
            int index = 0;
            foreach (object obj in list)
            {

                SaveValue(obj, keyName + index);
                ++index;
            }
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {

            IDictionary dic = value as IDictionary;

            PlayerPrefs.SetInt(keyName, dic.Count);

            int index = 0;
            foreach (object key in dic.Keys)
            {
                SaveValue(key, keyName + "_key_" + index);
                SaveValue(dic[key], keyName + "_value_" + index);
                ++index;
            }
        }
        // カスタムタイプ
        else
        {
            SaveData(value, keyName);
        }
    }

  
    public object LoadData( Type type, string keyName )
    {


        
        object data = Activator.CreateInstance(type);
        FieldInfo[] fieldInfos = type.GetFields();

        string loadKeyName = "";
        FieldInfo fieldInfo;
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            fieldInfo = fieldInfos[i];
            
            loadKeyName = keyName + "_" + type.Name +
                "_" + fieldInfo.FieldType.Name + "_" + fieldInfo.Name;


            fieldInfo.SetValue(data, LoadValue(fieldInfo.FieldType, loadKeyName));
        }
        return data;
    }

        private object LoadValue(Type fieldType, string keyName)
    {
        
        if (fieldType == typeof(int))
        {

            return PlayerPrefs.GetInt(keyName, 0);
        }
        else if (fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName, 0);
        }
        else if (fieldType == typeof(string))
        {
            return PlayerPrefs.GetString(keyName, "");
        }
        else if (fieldType == typeof(bool))
        {
            
            return PlayerPrefs.GetInt(keyName, 0) == 1 ? true : false;
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            
            int count = PlayerPrefs.GetInt(keyName, 0);

            IList list = Activator.CreateInstance(fieldType) as IList;
            for (int i = 0; i < count; i++)
            {

                list.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {

            int count = PlayerPrefs.GetInt(keyName, 0);

            IDictionary dic = Activator.CreateInstance(fieldType) as IDictionary;
            Type[] kvType = fieldType.GetGenericArguments();
            for (int i = 0; i < count; i++)
            {
                dic.Add(LoadValue(kvType[0], keyName + "_key_" + i),
                         LoadValue(kvType[1], keyName + "_value_" + i));
            }
            return dic;
        }
        else
        {
            return LoadData(fieldType, keyName);
        }

    }
}
