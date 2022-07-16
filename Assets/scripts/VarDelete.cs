using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarDelete : MonoBehaviour
{
    public string startvar;
    public bool inv;
    void Start()
    {
        if (!VarSave.EnterFloat(startvar) && inv)
        {
            Destroy(gameObject);
        }
        if (VarSave.EnterFloat(startvar) && !inv)
        {
            Destroy(gameObject);
        }
    }
}
