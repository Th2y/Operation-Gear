using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    public static StatsController instance;

    [Header("    Start-Stats")]
    public float maxlife;                 // Total de vida      
    public int maxenergy;                 // Total de energia   
    public int usable_energy;             // quanto de energia que o player gasta  

    [Header("    Energy reculperation")]
    public int Idle_energy_recu;          // energia que vai recuperar parado
    public int Move_energy_recu;          // energia que vai recuperar move

    [Header("    Timing Energy reculperation")]
    public float Idle_TimeEnergyRecu;
    private float Idle_T_E_R;
    public float Move_TimeEnergyRecu;
    private float Move_T_E_R;

    [Header("    Update-Stats")]
    public float life;                    // vida do jogador    
    public int energy;                    // energia que o player vai usar
    
    [Header("    UI")]
    public Image UI_energy;               // Sprite da energia  
    public Image UI_life;                 // Sprite da vida

    public bool ismove; //test

    // Start is called before the first frame update
    void Start()
    {
        if (instance==null)
        {
            instance = this;
        }

        life = maxlife;
        energy = maxenergy;
    }

    // Update is called once per frame
    void Update()
    {
        UI_Image(UI_energy, energy, maxenergy);  //atualiza a barra de energia
        UI_Image(UI_life, life, maxlife);        //atualiza a barra de vida

       
        EnergyController();
        TimingEnergy();
    }

    // verifica se esta vivo ou não
    public bool Isalive()
    {
        if (life <= 0)
        {
            return true;
        }
        return false;
    }
    // sistema de energia
    private void EnergyController()
    {
        if (energy <= 0 || energy < usable_energy || !AttackController.IsAttaking)
        {
            if (energy >= maxenergy)
            {
                energy = maxenergy;
            }else if (energy < 0)
            {
                energy = 0;
            }
            if(Idle_T_E_R <= 0)
            {             
                energy += Idle_energy_recu;

                Idle_T_E_R = Idle_TimeEnergyRecu;
            }
            else if (Move_T_E_R <= 0)
            {
                energy += Move_energy_recu;

                Move_T_E_R = Move_TimeEnergyRecu;
            }

            
        }
    }

    private void TimingEnergy()
    {
        // ismove  teste
        if (!ismove)
        {
            Idle_T_E_R -= Time.deltaTime;
        }
        else
        {
            Move_T_E_R -= Time.deltaTime;
        }
    }


    public void RemoveEnergy()
    {
        energy -= usable_energy;
    }
    public void RemoveLife(float dmg)
    {
        life -= dmg;
    }
    private void UI_Image(Image image,float min,float max)
    {
        image.fillAmount = min / max;
    }
}
