using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoDebug : MonoBehaviour
{
    public VideoPlayer vp;
    public RawImage img;

    void Start()
    {
        vp.Prepare();
        vp.prepareCompleted += (source) =>
        {
            Debug.Log("Video preparado com sucesso!");
            vp.Play();
        };
    }

    void Update()
    {
        if (vp.isPlaying)
        {
            img.color = Color.white;
        }
    }
}
