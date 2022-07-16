using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave
{
    public float[] timeeffect;
    public string[] nameeffect;
    public float[] timepeffect;
    public string[] namepeffect;
    public int hp;
    public int damage;
    public Vector3 pos;
    public Quaternion rot; 
    public int rot2;
    public static float[] ListSwapfloat(float[] s, useeffect[] s1)
    {
        for (int i = 0; i < s.Length; i++)
        {
            s[i] = s1[i].time;
        }
        return s;
    }
    public static string[] ListSwapstring(string[] s, useeffect[] s1)
    {
        for (int i = 0; i < s.Length; i++)
        {
            s[i] = s1[i].effect;
        }
        return s;
    }
    public static float[] ListSwapfloat2(float[] s, useeffect[] s1)
    {
        for (int i = 0; i < s.Length; i++)
        {
            s1[i].time = s[i];
        }
        return s;
    }
    public static string[] ListSwapstring2(string[] s, useeffect[] s1)
    {
        for (int i = 0; i < s.Length; i++)
        {
            s1[i].effect = s[i];
        }
        return s;
    }
    public static PlayerSave Save(PlayerSave slot)
    {
        PlayerSave save = slot;
        save.hp = playerdata.hp;
        save.pos = Player.Getplayer().transform.position;
        save.rot = Player.Getplayer().transform.rotation;
        save.rot2 = Player.Getplayer().rot;
        save.damage = playerdata.damage;
        save.timeeffect = new float[3];
        save.nameeffect = new string[3];
        save.timepeffect = new float[1];
        save.namepeffect = new string[1];
        PlayerSave.ListSwapfloat(save.timeeffect, playerdata.effects);
        PlayerSave.ListSwapstring(save.nameeffect, playerdata.effects);
        VarSave.SetString(VarSave.GetKeySceneMenager(), JsonUtility.ToJson(save));
        return save;
    }
    public static PlayerSave Load(PlayerSave slot)
    {
        PlayerSave save = slot;
        if (VarSave.EnterFloat(VarSave.GetKeySceneMenager()))
        {
            save = JsonUtility.FromJson<PlayerSave>(VarSave.GetString(VarSave.GetKeySceneMenager()));
            playerdata.hp = save.hp;
            playerdata.damage = save.damage;
            save.damage = playerdata.damage;
            Player.Getplayer().transform.position = save.pos;
            Player.Getplayer().transform.rotation = save.rot; 
            Player.Getplayer().rot = save.rot2;
            save.timeeffect = new float[3];
            save.nameeffect = new string[3];
            save.timepeffect = new float[1];
            save.namepeffect = new string[1];
            PlayerSave.ListSwapfloat2(save.timeeffect, playerdata.effects);
            PlayerSave.ListSwapstring2(save.nameeffect, playerdata.effects);
        }
        return save;
    }
}
