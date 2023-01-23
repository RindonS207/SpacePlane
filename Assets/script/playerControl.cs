using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
        playerM = this.GetComponent<AudioSource>();
        toWhere = playerTransform.position;
    }
    Transform playerTransform;
    public Transform boom;
    AudioSource playerM;
    public AudioClip playerC2;
    public AudioClip playerC;
    public Transform bulletTran;
    public float speed = 1;
    public static float heart = 100;
    public static bool isAlive = true;
    public LayerMask inputMask;
    Vector3 toWhere;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            playerTransform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (speed * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            playerTransform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            playerTransform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerTransform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bulletTran,playerTransform.position,playerTransform.rotation);
            playerM.PlayOneShot(playerC);
        }
        if(heart <= 0)
        {
            isAlive = false;
            Instantiate(boom,playerTransform.position,Quaternion.identity);
            playerM.PlayOneShot(playerC2);
            Destroy(this.gameObject);
        }
        mouseDown();
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "direnZidan")
        {
            heart -= gameInfo.direnDamage;
            Destroy(other.gameObject);
        }
    }
    public void mouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 ms = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(ms);
            RaycastHit hit;
            bool iscast = Physics.Raycast(ray, out hit, 1000, inputMask);
            if (iscast)
            {
                toWhere = hit.point;
            }
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, new Vector3(toWhere.x,playerTransform.position.y,toWhere.z), speed * Time.deltaTime);
        }
    }
}
