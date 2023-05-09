using UnityEngine;
using System.Collections.Generic;


public class Cache
{

    private static Dictionary<float, WaitForSeconds> m_WFS = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWFS(float key)
    {
        if(!m_WFS.ContainsKey(key))
        {
            m_WFS[key] = new WaitForSeconds(key);
        }

        return m_WFS[key];
    }

    //------------------------------------------------------------------------------------------------------------


    private static Dictionary<Collider, Character> m_Character = new Dictionary<Collider, Character>();

    public static Character GetCharacter(Collider key)
    {
        if (!m_Character.ContainsKey(key))
        {
            Character burger = key.GetComponent<Character>();

            if (burger != null)
            {
                m_Character.Add(key, burger);
            }
            else
            {
                return null;
            }
        }

        return m_Character[key];
    }


}

