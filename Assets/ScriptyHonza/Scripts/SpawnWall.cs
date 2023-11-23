using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Items;

    [SerializeField]
    TextMeshProUGUI text;
    
    [SerializeField]
    Transform GhostBlock;
    Vector3 spawn_pos;


    private int wall;
    private bool Pause = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            wall = 0;
            text.text = "->";
        }

        if(Input.GetKey(KeyCode.A)){
            wall = 1;
            text.text = "<-";
        }

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
                
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                spawn_pos = hit.point;

                Instantiate(Items[wall], spawn_pos, Quaternion.identity);
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