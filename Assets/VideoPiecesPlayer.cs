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



    void PlayVideoPieces(string videoPieces)
    {
        videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().url = videoPieces;
        videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().Prepare();
        videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().Play();
    }


    void MakePiecesIntoWhole()
    {
        while (videoIndex <= videoPiecesCount)
        {
            if (videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().isPlaying)
            {
                print("is playing...");
                return;
            }

            PlayVideoPieces(videoPiecesPath + videoIndex + ".mp4");
            print("playing: " + videoIndex);
            videoIndex++;
        }
    }


    void Start() {MakePiecesIntoWhole();}
    void Update() {  }
}
