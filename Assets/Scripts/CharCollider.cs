using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCollider : MonoBehaviour
{
    [SerializeField] private Character character;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstantClass.GIFTBOX))
        {
            character.PowerUp();
            Destroy(other.gameObject);
        }
    }
}
