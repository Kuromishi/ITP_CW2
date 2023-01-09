using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Component : MonoBehaviour
{
    public CharacterComponent characterComponent;

    // Start is called before the first frame update
    void Start()
    {
        characterComponent.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
