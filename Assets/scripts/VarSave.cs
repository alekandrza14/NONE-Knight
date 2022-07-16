using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VarSave
{
    public static string path = "Data/var";
    public static void DeleteAll()
    {
        Directory.Delete(path, true);

    }
    public static void DeleteKey(string key)
    {
        File.Delete(path + "/" + key);

    }
    public static string GetKeySceneMenager()
    {
       return  SceneManager.GetActiveScene().name;

    }
    public static void SetInt(string key, int var)
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, var.ToString());
    }
    public static int GetInt(string key)
    {
        int varout = 0;
        if (File.Exists(path + "/" + key))
        {
            varout = int.Parse(File.ReadAllText(path + "/" + key));
        }
        return varout;
    }
    public static void SetBool(string key, bool var)
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, var.ToString());
    }
    public static bool GetBool(string key)
    {
        bool varout = false;
        if (File.Exists(path + "/" + key))
        {
            varout = bool.Parse(File.ReadAllText(path + "/" + key));
        }
        return varout;
    }
    public static void SetString(string key, string var)
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, var.ToString());
    }
    public static string GetString(string key)
    {
        string varout = "";
        if (File.Exists(path + "/" + key))
        {
            varout = File.ReadAllText(path + "/" + key);
        }
        return varout;
    }

    public static void SetFloat(string key, float var)
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, var.ToString());
    }
    public static float GetFloat(string key)
    {
        float varout = 0.0f;

        if (File.Exists(path + "/" + key))
        {
            varout = float.Parse(File.ReadAllText(path + "/" + key));
        }
        return varout;
    }
    public static bool EnterFloat(string key)
    {
        bool a = false;
        if (File.Exists(path + "/" + key))
        {
            a = true;
        }
        return a;
    }
    
}
