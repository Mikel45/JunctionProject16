using UnityEngine;
using System.Collections;

public class MoovieScript : MonoBehaviour {

    // Use this for initialization
    void Start () {

        Handheld.PlayFullScreenMovie("mp4test.mp4", Color.blue, FullScreenMovieControlMode.CancelOnInput);
        Application.LoadLevel("GameScene");


    }
      



    // Update is called once per frame
    void Update () {
	
	}
}
