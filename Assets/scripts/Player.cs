using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class useeffect
{
    public string effect = "";
    public float time = 0;
}
public class playerdata
{
    static public int hp = 5;
    static public int damage = 5;
    static public bool inv;
    static public useeffect[] effects = new useeffect[3]
    {
        new useeffect(),
        new useeffect(),
        new useeffect()
    };
    static public useeffect[] Paniceffect = new useeffect[1]
    {
        new useeffect()
    };
    static public void checkeffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].time <= 0)
            {
                playerdata.effects[i].effect = "";
            }
            if (playerdata.effects[i].time >= 0)
            {
                playerdata.effects[i].time -= Time.deltaTime;
            }
        }
        if (playerdata.Paniceffect[0].time <= 0)
        {
            playerdata.Paniceffect[0].effect = "";
        }
        if (playerdata.Paniceffect[0].time >= 0)
        {
            playerdata.Paniceffect[0].time -= Time.deltaTime;
        }

    }
    static public void Addeffect(string name, float time)
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == "")
            {
                playerdata.effects[i].effect = name;
                playerdata.effects[i].time = time;
                i = playerdata.effects.Length;
            }
        }
    }
    static public void SetPaniceffect(string name, float time)
    {
        playerdata.Paniceffect[0].effect = name;
        playerdata.Paniceffect[0].time = time;
    }
    static public void Cleareffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            playerdata.effects[i].effect = "";
            playerdata.effects[i].time = 0;
        }
    }
    static public useeffect Geteffect(string name)
    {
        useeffect ef = null;
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == name)
            {
                ef = playerdata.effects[i];
            }
        }
        if (playerdata.Paniceffect[0].effect != "")
        {
            ef = playerdata.Paniceffect[0];
        }
        return ef;
    }
    public static int overload()
    {
        int defult = 1;
        if (playerdata.Geteffect("overload") != null)
        {
            defult = 2;
        }
        return defult;
    }
}
public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public Collision c;
    public float jumpf;
    public float jump;
    public bool fall;
    public bool isgraund;
    public int jumps;
    public Vector3 tp;
    public Sprite[] sp;
    public SpriteRenderer s;
    public Animator anim1;
    public Vector2 dir;
    public int rot;
    public float helltic;
    public float sansact;
    public PlayerSave ps = new PlayerSave();
    private void Start()
    {
        PlayerSave.Load(ps);
    }
    public static Player Getplayer()
    {
        Player g = GameObject.FindObjectOfType<Player>();
        return g;
    }
    public void EFFECTupdate()
    {
        playerdata.checkeffect();
        invisible();
        hell();
    }
    public void invisible()
    {
        if (playerdata.Geteffect("invisible") != null)
        {
            s.color = new Color(1, 1, 1, 0.1f);
            playerdata.inv = true;
        }
        else
        {
            s.color = new Color(1, 1, 1, 1);
            playerdata.inv = false;
        }
    }
    public void hell()
    {
        if (playerdata.Geteffect("hell") != null)
        {
            helltic += Time.deltaTime;
            if (helltic > 1)
            {
                playerdata.hp += 1;
                if (Random.Range(0,6) ==3)
                {
                    playerdata.hp += 1;
                }
                else
                {


                    helltic = 0;
                }
            }
        }
        else
        {
            
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        c = collision;
    }
    private void OnCollisionExit(Collision collision)
    {
        c = null;
        fall = false;
    }
    public void damage()
    {
        tp += -transform.forward * Random.Range(0, 1.01f);
        playerdata.hp -= 1;
        if (playerdata.hp <=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerdata.hp = 5;
        }
    }
    public void rotates()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            for (int i =0;i<playerdata.overload();i++)
            {
                if (!isgraund && jumps > 0)
                {
                    jumpf = jump;
                    jumps--;
                }
                Instantiate(Resources.Load<damagetrigger>("damagetrigger"), transform.position, Quaternion.identity);
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 h = Vector3.up * Input.GetAxis("Mouse X");
            transform.Rotate(h);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public Vector3 udar()
    {
        Vector3 v3 = Vector3.zero;
        if (rot == 1)
        {
            v3 = transform.forward;
        }
        if (rot == 0)
        {
            v3 = -transform.forward;
        }
        if (rot == 3)
        {
            v3 = transform.right;
        }
        if (rot == 2)
        {
            v3 = -transform.right;
        }
        if (!isgraund)
        {
            v3 = -transform.up;
        }
        if (playerdata.overload() == 2)
        {
            v3 += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        }
        return v3;
    }

    public void phisics()
    {
        
        Ray r = new Ray(transform.position, -Vector3.up);
        Debug.DrawRay(transform.position,- Vector3.up);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit))
        {
            if (hit.distance <= 0.48f)
            {
                isgraund = true;
                jumps = 3;
            }
            else
            {
                isgraund = false;
            }
        }
    }
    public void anim()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0 || Input.GetButton("Jump") || !isgraund || Input.GetKeyDown(KeyCode.Mouse0))
        {
            sansact = 0;
        }
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            sansact += Time.deltaTime;
        }
        if (sansact >= 5)
        {
            PlayerSave.Save(ps);
            anim1.Play("New Animation13");
            Debug.Log("сохранено");
            sansact = 0;
        }
        

        if (sansact < 5)
        {

            dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            anim1.SetFloat("x", dir.x);
            anim1.SetFloat("y", dir.y);
            if (playerdata.Geteffect("recontrol") == null)
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    rot = 1;
                }
                if (Input.GetAxis("Vertical") < 0)
                {
                    rot = 0;
                }
                if (Input.GetAxis("Horizontal") > 0)
                {
                    rot = 3;
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    rot = 2;
                }
            }
            if (playerdata.Geteffect("recontrol") != null)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    rot = 3;
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    rot = 2;
                }
                if (Input.GetAxis("Vertical") > 0)
                {
                    rot = 1;
                }
                if (Input.GetAxis("Vertical") < 0)
                {
                    rot = 0;
                }
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            playerdata.hp = 1;
        }
        phisics();
        EFFECTupdate();
        anim();
        rotates();
        Vector3 h = transform.forward * Input.GetAxis("Vertical") * playerdata.overload();
        Vector3 w = transform.right * Input.GetAxis("Horizontal") * playerdata.overload();
        if (Input.GetButton("Jump") && isgraund) 
        {
            
            jumpf = jump;
        }
        Vector3 j2 = transform.up * Input.GetAxis("Jump");
        if (jumpf > -5 && !isgraund)
        {
            jumpf -= Time.deltaTime * 9.14f;
        }
        if (jumpf <= -5 && !isgraund)
        {
            jumpf -= -5;
        }
        if (!isgraund)
        {
            j2 += Vector3.up * jumpf;
        }
        Vector3 j = j2;
        
        Vector3 f = w + h + j;
        if (playerdata.Geteffect("damage") != null)
        {
            transform.position += tp;
        }
        if (playerdata.Geteffect("damage") == null)
        {
            tp = Vector3.zero ;
        }

        Vector3 vel = f;
        rb.velocity = vel;
        c = null;
    }
}
