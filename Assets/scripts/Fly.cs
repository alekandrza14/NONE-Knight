using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fly : MonoBehaviour
{
    public int hp = 10;
    public Animator anim;
    public float speed;
    bool isdeath;
    public float distance = 4;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player" && !isdeath && playerdata.Geteffect("damage") ==null)
        {
            Player.Getplayer().anim1.SetTrigger("Damage");
            Player.Getplayer().damage();
            playerdata.Addeffect("damage",Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<damagetrigger>() && !isdeath)
        {
            hp -= playerdata.damage;
            transform.position += Player.Getplayer().transform.forward;
        }
    }
    public void Update()
    {
        if (hp<=0 && !isdeath)
        {
            anim.SetTrigger("death");
            hp = 1000;
            isdeath = true;
        }
        transform.rotation = Player.Getplayer().transform.rotation;
        Vector3 v3 = Player.Getplayer().transform.position - transform.position;
        float dist = Vector3.Distance(Vector3.zero, v3);
        if (dist <= distance && playerdata.inv == false && !isdeath)
        {
            Vector3 v32 = v3 /dist;
            v32 *= speed;
            transform.position += v32;
        }
    }
}
