using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class diren : MonoBehaviour
{
    void Start()
    {
        thistrans = transform;
        music = this.GetComponent<AudioSource>();
    }
    Transform thistrans;
    AudioSource music;
    public Transform boom;
    public float speed = 1;
    public AudioClip boomMusic;
    public int fanWEi = 15;
    public float zLength = 15;
    System.Random rand=new System.Random();
    private bool isMove=false;
    private Vector3 vec=new Vector3();
    public float heart = 15;
    // Update is called once per frame
    void Update()
    {
        int lala=rand.Next(-fanWEi,fanWEi);
        if(!isMove)
        {
            vec = new Vector3(thistrans.position.x + lala, thistrans.position.y, thistrans.position.z - zLength);
            isMove=true;
        }
        else if(thistrans.position == vec)
        {
            isMove=false;
        }
        thistrans.position = Vector3.MoveTowards(thistrans.position,vec,speed*Time.deltaTime);
        if(heart <= 0)
        {
            gameInfo.points += 100;
            music.PlayOneShot(boomMusic);
            PathologicalGames.SpawnPool pool = PathologicalGames.PoolManager.Pools["testPool"];
            if(pool.IsSpawned(thistrans))
            {
                pool.Despawn(thistrans);
            }
            else
            {
                Destroy(this.gameObject);
            }
            //Destroy(this.gameObject);
            Instantiate(boom,thistrans.position,Quaternion.identity);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "zidan")
        {
            this.heart -= gameInfo.bulletDamage;
        }
        if(other.tag == "player")
        {
            playerControl.heart -= this.heart;
            music.PlayOneShot(boomMusic);
            Destroy(this.gameObject);
            Instantiate(boom, thistrans.position, Quaternion.identity);
        }
    }
}
