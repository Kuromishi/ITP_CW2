using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public CharacterComponent characterComponent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<CharacterComponent>() != null)
        {
            characterComponent.isPlayerDead = true;
        }
    }
}
