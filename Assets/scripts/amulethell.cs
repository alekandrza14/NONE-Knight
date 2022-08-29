using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class amulethell: MonoBehaviour
{
    public void Update()
    {
        transform.rotation = Player.Getplayer().transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerdata.Addeffect("hell",7);
            Destroy(gameObject);
        }
    }
}
