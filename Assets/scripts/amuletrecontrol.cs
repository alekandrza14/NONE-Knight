using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class amuletrecontrol: MonoBehaviour
{
    public void Update()
    {
        transform.rotation = Player.Getplayer().transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerdata.Addeffect("recontrol", 60*3);
            Destroy(gameObject);
        }
    }
}
