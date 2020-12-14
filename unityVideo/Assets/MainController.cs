using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{

    public Animator doorAnimator;

    public Animator lightAnimator;

    public Animator personAnimator;

    public Animator cameraAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            // open the door
            doorAnimator.SetBool("openDoor", true);
            doorAnimator.SetBool("closeDoor", false);
        }

        if (Input.GetKeyDown("p"))
        {
            // animate person
            personAnimator.SetBool("walkToPosition", true);
        }

        if (Input.GetKeyDown("z"))
        {
            // Animate camera
            cameraAnimator.SetBool("zoomCamera", true);
        }

        if (Input.GetKeyDown("s"))
        {
            // Shut the door
            // open the door
            doorAnimator.SetBool("openDoor", false);
            doorAnimator.SetBool("closeDoor", true);
        }
    }
}
