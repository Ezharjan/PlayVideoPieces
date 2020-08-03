using UnityEngine;
using UnityEngine.Video;

/*by Alexander*/

public class VideoPiecesPlayer : MonoBehaviour
{
    public GameObject videoPlayerPlane = null;

    //Change the path and video pieces count below to your own
    private string videoPiecesPath = "D:/4-th_Grade/UnityVideoPiecesTest/MP4Pieces/";
    private int videoPiecesCount = 23;

    private int videoIndex = 1;
    private int lastVideoIndex = 1;


    void PlayVideoPieces(string videoPieces)
    {
        videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().url = videoPieces;
        videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().Prepare();
        videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().Play();
    }


    void OnVideoEnded(VideoPlayer videoPlayer)
    {
        Debug.Log("Video " + videoIndex + " ended!");
        videoIndex++;
    }

    void Start()
    {
        videoPlayerPlane.gameObject.GetComponent<VideoPlayer>().loopPointReached += OnVideoEnded;
        PlayVideoPieces(videoPiecesPath + videoIndex + ".mp4");//First piece to open all
    }

    void Update()
    {
        if (videoIndex > lastVideoIndex)
        {
            lastVideoIndex++;
            PlayVideoPieces(videoPiecesPath + videoIndex + ".mp4");
            print("Play next piece!");
        }
        //When all have played
        if (videoIndex.Equals(videoPiecesCount))
        {
            print("finished!");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
	Application.Quit();
#endif
        }
    }
}
