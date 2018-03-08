using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour {

    //Box health points
    public int currentHealth = 3;
        
    public void Damage(int damageAmount)
    {
        // Make the enemy color red
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);

        // Subtract damage amount when Damage function is called
        currentHealth -= damageAmount;
        Debug.LogFormat("You dealt {0} damage!", damageAmount);

        if (currentHealth <= 2)
        {   
            // Add yellow to box color
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.yellow);
        }

        //Check if health has fallen below zero
        // If so set box to inactive
        if (currentHealth <= 0)
        {
            this.transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
            
            Debug.Log("You just killed that box! Shame on you.");
        }
    }
}
