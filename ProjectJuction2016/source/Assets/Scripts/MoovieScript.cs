using UnityEngine;
using System.Collections;

public class MoovieScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StartCoroutine(PlayMovie());
        }

        protected IEnumerator PlayMovie()
        {

            Handheld.PlayFullScreenMovie("Movie.mp4", Color.blue, FullScreenMovieControlMode.Hidden);

            yield return new WaitForSeconds(1.0f);

            Application.LoadLevel("GameScene");
        }



    // Update is called once per frame
    void Update () {
	
	}
}
