using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gomd : MonoBehaviour
{
    public Animator anim;
    public float speed;
    bool isdeath;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<damagetrigger>() && !isdeath)
        {
            transform.position += Player.Getplayer().transform.forward;
            playerdata.SetPaniceffect("GomdANARHIA", 1);
        }
    }
    public void Update()
    {
        Vector3 v3 = Player.Getplayer().transform.position - transform.position;
        float dist = Vector3.Distance(Vector3.zero, v3);
        if (playerdata.Geteffect("GomdANARHIA") != null && !isdeath && dist <= 12)
        {
            anim.SetTrigger("death");
            for (int i = 0; i < 10; i++)
            {
                Instantiate(Resources.Load<GameObject>("GomdFly"), transform.position, Quaternion.identity);
            }
            isdeath = true;
        }
        transform.rotation = Player.Getplayer().transform.rotation;
        if (dist <= 6 && playerdata.inv == false && !isdeath)
        {
            playerdata.SetPaniceffect("GomdANARHIA", 1);
        }
    }
}
