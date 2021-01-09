using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyClass : MonoBehaviour
{
    public int HP = 6;
    public int KnockBackValue = 1;

    public AudioClip SoundHurt;

    public GameObject SpritePlane;
    public GameObject HitVFX;
    public Rigidbody rb;


    private bool Invulnerable = false;
    private Renderer rend;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = SpritePlane.GetComponent<Renderer>();
        GlobalData.EnemyCount++; // Add Enemy to Global Enemy Count
    }


    // check if colliding witih Player Attacks
    private void OnTriggerEnter(Collider collision)
    {
        // collision with damaging object
        if (collision.tag == "Hit" && !Invulnerable)
        {
            RecieveDamage(1);
        }
    }

    public void RecieveDamage(int damageDelt)
    {

        AddToComboCount();
        Invulnerable = true;
        GameObject VFX = Instantiate(HitVFX);
        VFX.transform.position = transform.position;
        SpritePlane.transform.position += new Vector3(Random.Range(-KnockBackValue, KnockBackValue), Random.Range(-KnockBackValue, KnockBackValue), Random.Range(-KnockBackValue, KnockBackValue));
        transform.position = Vector3.MoveTowards(transform.position, GlobalData.Player.transform.position, -2);
        HP -= damageDelt;
        Invoke("ResetCoolDownInvulnerability", .2f);
        
        CheckHP();
        

        
    }

    public void ResetCoolDownInvulnerability()
    {
        Invulnerable = false;
    }

    public void CheckHP()
    {

        if (HP <= 0)
        {
            //LockGame();

            Death();
        }
        else
        {
            LockGame();
        }
    }

    public virtual void Death()
    {
        UnlockGame();
        GlobalData.EnemyCount--;
        Destroy(gameObject);
    }

    public void ResetComboCount()
    {
        GlobalData.ComboCount = 0;
        GlobalData.ComboTimeStamp = 0;
    }

    public void AddToComboCount()
    {
        if (GlobalData.ComboCount == 0 || 0.1f > Time.time - GlobalData.ComboTimeStamp)
        {
            GlobalData.ComboCount++;
            GlobalData.ComboTimeStamp = Time.time;
            Invoke("ResetComboCount", 0.01f);
        }
    }

    private void UnlockGame()
    {
        GlobalData.Locked = false;
    }

    private void LockGame()
    {
        GlobalData.Locked = true;
        Invoke("UnlockGame", .3f);
    }

}
