using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody Playerrb;

    [SerializeField]
    float PlayerSpeed;


    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = transform.forward;   // Inicializace smeru chuze <3
    }

    // Update is called once per frame
    void Update()
    {
        Playerrb.AddForce(direction * PlayerSpeed * Time.deltaTime); // delani chuze
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


            Debug.Log("There's second plane incoming");

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


            Debug.Log("There's second plane incoming");

        }


    }
    
}
