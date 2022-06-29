using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using UnityEngine;

public static class FileManager<T>
{
    static string _fileName;
    private static string _saveFolder;


    public static void Save(List <T> list)
    {
        string serialized = JsonConvert.SerializeObject(list);
        File.WriteAllText(FindPath(typeof(T).ToString()),serialized);
    }

    public static List<T> Load()
    {
        string serialized = File.ReadAllText(FindPath(typeof(T).ToString()));
        List<T> list = JsonConvert.DeserializeObject<List<T>>(serialized);
        return list; 
    }

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