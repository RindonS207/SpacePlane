using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diren_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        buttetTran = this.transform;
    }
    public float bulletSpeed = 10;
    Transform buttetTran;
    // Update is called once per frame
    void Update()
    {
        buttetTran.Translate(new Vector3(0,0, bulletSpeed * Time.deltaTime));
    }
    void OnBecameInvisible()
    {
        if (this.enabled)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "zidan")
        {
            Destroy(this.gameObject);
        }
    }
}
