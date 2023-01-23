using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_diren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        thisthans = this.transform;
        playerPOS = GameObject.Find("Player");
        music = this.GetComponent<AudioSource>();
    }
    public float heart = 50;
    public float speed = 10;
    public float shotSpeed = 10;
    public float shotTime = 2;
    private float time_Time = 0;
    Transform thisthans;
    AudioSource music;
    public AudioClip boomMusic;
    public Transform boom;
    public AudioClip shot;
    public GameObject playerPOS;
    public Transform bulletTran;
    // Update is called once per frame
    void Update()
    {
        if(this.heart <= 0)
        {
            gameInfo.points += 300;
            music.PlayOneShot(boomMusic);
            Destroy(this.gameObject);
            Instantiate(boom, thisthans.position, Quaternion.identity);
        }
        thisthans.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        time_Time += shotSpeed * Time.deltaTime;
        if (time_Time >= shotTime && playerControl.isAlive)
        {
            
            time_Time = 0;
            Vector3 vecc=playerPOS.transform.position - thisthans.position;
            Instantiate(bulletTran, thisthans.position, Quaternion.LookRotation(vecc));
            music.PlayOneShot(shot);
        }
        
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
            Instantiate(boom, thisthans.position, Quaternion.identity);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
