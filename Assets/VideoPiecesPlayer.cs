using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;

/*by Alexander*/

public class VideoPiecesPlayer : MonoBehaviour
{
    public GameObject videoPlayerPlane = null;

    private string videoPiecesPath = "D:/4-th_Grade/New folder/MP4Pieces/";
    private int videoPiecesCount = 23;

    private int videoIndex = 1;

    private bool isVideoPlaying = false;


    void PlayVideoPieces(string videoPieces)
    {
        videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().url = videoPieces;
        videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().Prepare();
        videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().Play();
        isVideoPlaying = true;
    }


    void MakePiecesIntoWhole()
    {

        if (videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().frameCount.Equals(405))
        {
            isVideoPlaying = false;
        }

        if (isVideoPlaying)
        {
            return;
        }
        else
        {
            PlayVideoPieces(videoPiecesPath + videoIndex + ".mp4");
            //print("playing: " + videoIndex);
            videoIndex++;
        }

    }


    void Start() { }

    void Update()
    {
        MakePiecesIntoWhole();
        print(videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().frameCount);
    }
}
