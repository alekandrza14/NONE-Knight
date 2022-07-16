using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class amuletoverload: MonoBehaviour
{
    public void Update()
    {
        transform.rotation = Player.Getplayer().transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerdata.Cleareffect();
            playerdata.Addeffect("overload", 20); 
            playerdata.Addeffect("overload", 20);
            playerdata.Addeffect("overload", 20); 
            playerdata.Addeffect("overload", 20);
            playerdata.Addeffect("overload", 20);
            Destroy(gameObject);
        }
    }
}
