using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character1 : MonoBehaviour
{
    public List<Character1> characterList;
    public UnityAction<Character1> onDespawnCallback;
    void Start()
    {
        GetAllCharacterAround();
    }

    public void GetAllCharacterAround()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Character1 tempChar = hitColliders[i].GetComponent<Character1>();
            if (tempChar != this)
            {
                AddCharacter(tempChar);
            }
        }
    }
    public void AddCharacter(Character1 character1)
    {
        if (characterList.Contains(character1)) return;
        characterList.Add(character1);

        /// Add function to call back
        character1.onDespawnCallback += RemoveCharacter;
    }
    public void RemoveCharacter(Character1 character1)
    {        
        /// Debug.Log($"{gameObject.name} remove {character.gameObject.name}");
        if (!characterList.Contains(character1)) return;
        characterList.Remove(character1);
        
        /// Remove callback after character despawn
        onDespawnCallback -= character1.RemoveCharacter;
    }
    
    public void Despawn()
    {
        gameObject.SetActive(false);        
        onDespawnCallback?.Invoke(this);

        /// Clear all function in callback
        onDespawnCallback = null;
    }
}
