using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
     public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
     public float speed;
     public float tilt;
     public Boundary boundary;
     public GameObject shot;
     public Transform shotSpawn;
     public float fireRate;
     public AudioSource source1;
     public AudioClip clip1;

     private float nextFire;

     public Text ion;

     private Rigidbody rb;
     private bool More;

     private void Start()
     {
          More = false;
          rb = GetComponent<Rigidbody>();
          source1.clip = clip1;
          ion.text = "";
     }

     void Update ()
     {
          if (Input.GetButton("Fire1") && More == true){
              Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
             source1.Play();
         }
         else if (Input.GetButton("Fire1") && Time.time > nextFire)
         {
             nextFire = Time.time + fireRate;
             Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
             source1.Play();
         }
         
     }

     void FixedUpdate()
     {
          float moveHorizontal = Input.GetAxis("Horizontal");
          float moveVertical = Input.GetAxis("Vertical");

          Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
          rb.velocity = movement * speed;

          rb.position = new Vector3
          (
               Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
               0.0f,
               Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
          );

          rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
     }
     void OnTriggerEnter(Collider other){
        if (other.CompareTag ("Faster")){
             More = true;
             other.gameObject.SetActive(false);
             ion.text = "ION LAZER ENGAGED";
        }
     }
}