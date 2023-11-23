using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    [SerializeField]
    GameObject TurnLeftWall;

    [SerializeField]
    Transform GhostBlock;
    Vector3 spawn_pos;


    private bool Pause = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
                
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                spawn_pos = hit.point;
                Instantiate(TurnLeftWall, spawn_pos, Quaternion.identity);
            }
        }


        if(Input.GetKeyDown(KeyCode.Space)){
            if(Pause){
                Time.timeScale = 0;
                
            }
            if(!Pause){
                Time.timeScale = 1;
            }

            Pause = !Pause;
        }


        RaycastHit GhostPosHit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out GhostPosHit, 100);
        GhostBlock.position = GhostPosHit.point;
    }
}