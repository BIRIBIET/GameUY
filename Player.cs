using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	Rigidbody rb;
  	public GameObject bullet;
  	GameObject cloneBullet;
  	Rigidbody rbClone;
    float HP = 4;
  	public Text HPtext;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      float moveVertical = Input.GetAxis("Vertical");
      rb.AddForce(transform.forward * moveVertical * 15f);
      
      float moveHorizontal =  Input.GetAxis("Horizontal");
      transform.Rotate(0f, moveHorizontal * 5f, 0f);

    if(Input.GetKeyDown("space")){
    	cloneBullet =  Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        rbClone = cloneBullet.GetComponent<Rigidbody>();
        rbClone.AddForce(transform.forward * 40f);
    }
    } 
    void OnCollisionEnter(Collision dad)
    {
     if(dad.gameObject.tag == "Enemy"){
        HP = HP - 1;
        HPtext.text = "HP:" + HP;
        Debug.Log(HP);
        if(HP <= 0){
        	SceneManager.LoadScene(1);
        }
     }
   }
}
