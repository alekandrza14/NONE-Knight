using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class amuletInvisible : MonoBehaviour
{
    public void Update()
    {
        transform.rotation = Player.Getplayer().transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerdata.Addeffect("invisible",60);
            Destroy(gameObject);
        }
    }
}
