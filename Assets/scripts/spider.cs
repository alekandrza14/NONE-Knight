using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spider : MonoBehaviour
{
    public int hp = 10;
    public Animator anim;
    public float speed;
    bool isdeath;
    public float fall;
    public float jump = 2;
    public float agr = 1;
    public bool isgraund;
    public float distance = 4;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player" && !isdeath && playerdata.Geteffect("damage") == null)
        {
            Player.Getplayer().anim1.SetTrigger("Damage");
            Player.Getplayer().damage();
            playerdata.Addeffect("overload", 0.3f);
            playerdata.Addeffect("damage", Time.deltaTime);
        }
        if (collision.collider.GetComponent<DeathZone>())
        {
            Destroy(gameObject);
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
    public void physics() 
    {
        Ray r = new Ray(transform.position, -Vector3.up);
        Debug.DrawRay(transform.position, -Vector3.up);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            if (hit.distance <= 0.48f)
            {
                isgraund = true;
            }
            else
            {
                isgraund = false;
            }
        }
    }
    public void Update()
    {
        
        if (Player.Getplayer().transform.position.y > transform.position.y && isgraund)
        {
            fall = jump;
        }
        
        if (fall > 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,Time.deltaTime*150,0);
            fall -= Time.deltaTime;
        }
        if (hp<=0 && !isdeath)
        {
            Destroy(gameObject);
            
        }
        transform.rotation = Player.Getplayer().transform.rotation;
        Vector3 v3 = Player.Getplayer().transform.position - transform.position;
        float dist = Vector3.Distance(Vector3.zero, v3);
        if (dist <= distance && playerdata.inv == false && Player.Getplayer().transform.position.y > transform.position.y +agr)
        {
            physics();
            Vector3 v32 = v3 /dist;
            v32 *= speed;
            transform.position += new Vector3( v32.x,0, v32.z);
        }

    }
}
