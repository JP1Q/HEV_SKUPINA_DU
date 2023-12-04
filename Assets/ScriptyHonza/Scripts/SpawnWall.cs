using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    [SerializeField]
    List<String> WallTags;

    [SerializeField]
    List<GameObject> Items;

    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    Transform GhostBlock;
    Vector3 spawn_pos;

    private int wall;
    private bool Pause = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            wall = 0;
            text.text = "->";
        }

        if (Input.GetKey(KeyCode.A))
        {
            wall = 1;
            text.text = "<-";
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                spawn_pos = hit.point;

                Instantiate(Items[wall], spawn_pos, Quaternion.identity);
            }
        }

        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            HandleRightClick();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Pause)
            {
                Time.timeScale = 0;
            }
            if (!Pause)
            {
                Time.timeScale = 1;
            }

            Pause = !Pause;
        }

        RaycastHit GhostPosHit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out GhostPosHit, 100);
        GhostBlock.position = GhostPosHit.point;
    }

    void HandleRightClick()
    {
        Debug.Log("DebugDebug");
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            // Check if the clicked object is a wall
            GameObject clickedObject = hit.collider.gameObject;
            Debug.Log(clickedObject.name);

            if(WallTags.Contains(clickedObject.tag)){
                Destroy(clickedObject);
            }
        }
    }
}
