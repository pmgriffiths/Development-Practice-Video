using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MainController : MonoBehaviour
{

    public Animator doorAnimator;

    public Animator lightAnimator;

    public Animator personAnimator;

    public Animator cameraAnimator;

    public VideoPlayer videoPlayer;

    public GameObject whiteboard;

    private bool playing = false;

    public RenderTexture renderTexture;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
//            renderTexture.format = RenderTextureFormat.ARGB32;
//            renderTexture.depth = 32;
            
            // renderTexture = new RenderTexture(1000,800, 32 RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);

            playing = true;
            videoPlayer.loopPointReached += EndReached;
            StartCoroutine(PlayItSam());
        }
    }

    IEnumerator PlayItSam()
    {
        whiteboard.SetActive(false);

        yield return new WaitForSeconds(1);

        // open the door
        doorAnimator.SetBool("openDoor", true);
        doorAnimator.SetBool("closeDoor", false);

        yield return new WaitForSeconds(.5f);
        doorAnimator.SetBool("openDoor", false);

        // animate person
        personAnimator.SetBool("walkToPosition", true);
        yield return new WaitForSeconds(1f);


        // Shut the door
        // open the door
        doorAnimator.SetBool("closeDoor", true);
        cameraAnimator.SetBool("zoomCamera", true);
        yield return new WaitForSeconds(1f);

//        cameraAnimator.SetBool("zoomCamera", true);
//        yield return new WaitForSeconds(1f);


        yield return new WaitForSeconds(1f);
        videoPlayer.frame = 0;
        whiteboard.SetActive(true);
        yield return new WaitForSeconds(.1f);

        personAnimator.SetBool("watchVideo", true);
        videoPlayer.Play();

        yield return new WaitForSeconds(5f);
        personAnimator.SetBool("unwatchVideo", true);
        personAnimator.SetBool("watchVideo", false);

        yield return new WaitForSeconds(2f);
        personAnimator.SetBool("point", true);

        yield return new WaitForSeconds(1f);
        personAnimator.SetBool("point", false);

        while (true)
        {
            yield return new WaitForSeconds(Random.value * 5);
            personAnimator.SetBool("unwatchVideo", false);
            personAnimator.SetBool("watchVideo", true);
            yield return new WaitForSeconds(1f + (Random.value * 3f));
            personAnimator.SetBool("unwatchVideo", true);
            personAnimator.SetBool("watchVideo", false);
            yield return new WaitForSeconds(1f + (Random.value * 3f));

            float r = Random.value;
            if (r > 0 && r < 0.2f)
            {
                personAnimator.SetBool("blink", true);
                yield return new WaitForSeconds(2f);
                personAnimator.SetBool("blink", false);
            }
            else if (r > 0.5 && r < 0.7f)
            {
                personAnimator.SetBool("point", true);
                yield return new WaitForSeconds(1f);
                personAnimator.SetBool("point", false);
            }

        }

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Reset video to first frame
        videoPlayer.frame = 0;
    }

}
