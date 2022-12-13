using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public int ammo;        // Initialise Ammo                                                                
    public AudioClip gun;

    public AudioClip noammo;
    IEnumerator Start()
    {
        ammo = 0;
        AudioSource noammo = GetComponent<AudioSource>();
        yield return new WaitForSeconds(noammo.clip.length); 

    }

    void Update()
    {
      
        //Check if left mouse button clicked
        if (Input.GetButtonDown("Fire1"))
        {
            // Check if ammo is 0
            if (ammo == 0)
            {
                Debug.Log("You have no Ammo!!!!");
                AudioSource gun = GetComponent<AudioSource>();
                gun.clip = noammo;
                gun.Play();
            }
            else
            {
                ammo -= 1;                                                                     // Reduce Ammo by 1
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));       // Create ray according to central dot
                Physics.Raycast(ray, out RaycastHit result);
                GameObject g = result.collider.gameObject;
                AudioSource noammo = GetComponent<AudioSource>();
                noammo.clip = gun;
                noammo.Play();
                // Find gameobject that ray has hit
                if (g.name == "Target")                                                        // Check if gameobject is Target
                {
                    Animation a = g.transform.parent.GetComponent<Animation>();
                    a.Play("LowerBridge");
                }
                
            }
            


        }


        }
    


    void OnTriggerEnter(Collider other)
    {
        // Check if Collision is with AmmoBox
        if (other.gameObject.name == "AmmoBox")
        {
            ammo = 20;                          // Set ammo to 20
            other.gameObject.SetActive(false);  // Despawn AmmoBox
        }


    }

}
