using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DeathZone : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Player.Getplayer().anim1.SetTrigger("Damage");
            Player.Getplayer().damage(); 
        }
    }
}
