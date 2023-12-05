using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.SearchService;
//using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody Playerrb;

    [SerializeField]
    int CurrentLevel;


    [SerializeField]
    float PlayerSpeed;
    float oldPS;

    Transform player_s;

    private Vector3 direction;
    private int thisLvlScore;
    // Start is called before the first frame update
    void Start()
    {
        player_s = transform;
        direction = transform.forward;   // Inicializace smeru chuze <3
        oldPS = PlayerSpeed;
        thisLvlScore=0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKey(KeyCode.R)){
            Debug.Log("Mackam D jako dick i kdyz mackam R ja nvm");
            transform.position = player_s.position; // JA AKSUALY NVM PROC TOHLE NEFUNGUJE XDDDDDDDDDDDDD
            // Cas udelat kocku na odreagovani

/* 

^   ^
(0-0)
 ( )              <- Legendy pravy ze to mela byt kocka ale jsem kkt asi idk :D
 | | 

*/
        }
        else if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
        //Playerrb.AddForce(direction * PlayerSpeed * Time.deltaTime); // delani chuze rigidbody <- tohle byl hnus pomoc
        transform.position += direction * PlayerSpeed * Time.deltaTime;
    }   



    void OnCollisionEnter(Collision collision){


        // Kdyz to funguje nedotykej se toho ->

        if(collision.gameObject.tag == "TurnRightWall"){

            if(direction == transform.right){
                direction = -transform.forward;
            }else if(direction == -transform.forward){
                direction = -transform.right;
            }else if(direction == -transform.right){
                direction = transform.forward;
            }else if(direction == transform.forward){
                direction = transform.right;
            }

        }
        else if(collision.gameObject.tag == "TurnLeftWall"){

            if(direction == transform.right){
                direction = transform.forward;
            }else if(direction == transform.forward){
                direction = -transform.right;
            }else if(direction == -transform.right){
                direction = -transform.forward;
            }else if(direction == -transform.forward){
                direction = transform.right;
            }

        }
        else if(collision.gameObject.tag == "Wall"){
            Score.currentScore -= thisLvlScore;
            thisLvlScore = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        else if(collision.gameObject.tag == "Door"){
            thisLvlScore = 0;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Ano pomalej kod je ale taky kod <3
            Score.currentScore += 1;
            if(currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1){ // Tady to dela to ehmm dalsi level Ano :D
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
            else{
                SceneManager.LoadScene(0); //  s p a t
            }
            
            
        }
        else if(collision.gameObject.tag == "Coin"){
            thisLvlScore++;
            Destroy(collision.gameObject);
            Score.currentScore += 1; // Jeste musim udelat visualizaci dokeluuu
            
        }



    }
    
}
