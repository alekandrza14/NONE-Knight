using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class damagetrigger : MonoBehaviour
{
    public Rigidbody rb;
    private void Start()
    {
        rb.AddForce(Player.Getplayer().udar() *2000);
    }
}
