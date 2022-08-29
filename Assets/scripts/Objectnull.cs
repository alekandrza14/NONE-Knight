using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectnull : MonoBehaviour
{
    public MonoBehaviour mb1;
    public string objectdest;
    void Update()
    {
        if (GameObject.FindObjectsOfType(mb1.GetType()).Length == 1)
        {
            VarSave.SetBool(objectdest,true);
        }
      
    }
}
