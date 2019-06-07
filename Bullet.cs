using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Bullet : MonoBehaviour
{
    static float Score = 0;
    public Text Scoretext;

    // Start is called before the first frame update
   void OnCollisionEnter(Collision dad){
        if(dad.gameObject.tag == "Enemy"){
        Destroy(dad.gameObject);
        Score = Score + 1;
        Scoretext.text = "Score:" + Score;
        Debug.Log(Score);
        if(Score >= 4){
            SceneManager.LoadScene(0);
                      }
     	}
     }
}
