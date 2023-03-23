using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRotation : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private Transform _raycastTarget;
   [SerializeField] private GameObject _cardFront,_cardBack;
   [SerializeField] private Transform _camera;
   [SerializeField] private LayerMask _mask;


   Vector3 _raycastDirection;
   float _raycastDistance;

    void Start()
    {
                                              
    }

    // Update is called once per frame
    void Update()
    {
        _raycastDirection=(_raycastTarget.position-_camera.position).normalized;
        _raycastDistance=(_camera.transform.position-_raycastTarget.transform.position).magnitude;

        FireRay(_raycastDirection,_raycastDistance);

    }

    private void FireRay(Vector3 raydirection,float distance)
    {
        if(Physics.Raycast(_camera.position,raydirection,distance,_mask))
        {
            _cardFront.SetActive(false);
            _cardBack.SetActive(true);
        }
        else
        {
             _cardFront.SetActive(true);
            _cardBack.SetActive(false);
        }
    }
}

