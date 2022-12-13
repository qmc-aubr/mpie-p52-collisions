using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        GameObject parent = transform.parent.gameObject;
        Animation animation = parent.GetComponent<Animation>();
        if (!animation.isPlaying)
        {
            animation.Play("OpenDoor");
            AudioSource door = GetComponent<AudioSource>();
            door.Play();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject parent = transform.parent.gameObject;
        Animation animation = parent.GetComponent<Animation>();
        animation.Play("Close");
        AudioSource door = GetComponent<AudioSource>();
        door.Play();
    }

    private void OnTriggerStay(Collider other)
    {

    }

}
