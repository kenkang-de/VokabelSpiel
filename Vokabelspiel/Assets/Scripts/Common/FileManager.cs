using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileManager<T>
{
    static string _fileName;
    private static string _saveFolder;


    public static void Save(List <T> list)
    {
        string serialized = JsonHelper.ToJson(list.ToArray());
        File.WriteAllText(FindPath(typeof(T).ToString()),serialized);
    }

    /*public static Dictionary<Tkey,TValue> Load()
    {
        string serialized = File.ReadAllText(FindPath(typeof(TValue).ToString()));
        Dictionary<Tkey,TValue> dictionary=SerializabeDictionary<Tkey,TValue>.Deserialize(serialized);
        return dictionary; 
    }*/

    static string FindPath(string fileName)
    {
        _saveFolder= Path.Combine(Application.dataPath, "Save");
        _fileName = fileName;
        if (!Directory.Exists(_saveFolder))
            Directory.CreateDirectory(_saveFolder);
        string path = Path.Combine(_saveFolder, _fileName);
        return path;

    }
    
}