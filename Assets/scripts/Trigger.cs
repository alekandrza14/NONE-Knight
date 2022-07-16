using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public string var;
    public void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "Player")
        {
            VarSave.SetInt(var,1);
        }
    }
}
