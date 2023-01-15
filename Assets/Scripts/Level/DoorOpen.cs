using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public CharacterComponent characterComponent;
    public SpriteRenderer bannerRenderer;
    public bool canBannerDisappear;
    public float disappearSpeed;

    [Range(0, 1)]
    private float T = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterComponent.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canBannerDisappear)
        {
            T += disappearSpeed * Time.deltaTime;

            Color color = bannerRenderer.color;     
            color.a = Mathf.Lerp(1, 0, T);
            bannerRenderer.color = color;

            if (color.a == 0)             
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CharacterComponent>() != null)
        {
            canBannerDisappear = true;
            //Debug.Log("Entered");
        }
    }
}
