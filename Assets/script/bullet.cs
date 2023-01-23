using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
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
        buttetTran.position = new Vector3(buttetTran.position.x, buttetTran.position.y, buttetTran.position.z + (bulletSpeed * Time.deltaTime));
    }
    void OnBecameInvisible()
    {
        if(this.enabled)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "diren")
        {
            Destroy(this.gameObject);
        }
        if(other.tag == "direnZidan")
        {
            Destroy(this.gameObject);
        }
    }
}
