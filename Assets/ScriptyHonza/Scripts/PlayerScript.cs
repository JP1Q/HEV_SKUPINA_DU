using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody Playerrb;

    

    [SerializeField]
    float PlayerSpeed;
    float oldPS;


    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = transform.forward;   // Inicializace smeru chuze <3
        oldPS = PlayerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Playerrb.AddForce(direction * PlayerSpeed * Time.deltaTime); // delani chuze rigidbody
        transform.position += direction * PlayerSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision){
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
            Debug.Log("You have died");

        }
        else if(collision.gameObject.tag == "Door"){
            Debug.Log("druwer");
        }



    }
    
}
