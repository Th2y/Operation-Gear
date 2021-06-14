using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    public static StatsController instance;

    [Header("    Start-Stats")]
    public float maxlife;                 // Total de vida      
    public int maxenergy;                 // Total de energia   


    [Header("    Energy Restoration")]
    public int Idle_energy_res;          // energia que vai recuperar parado
    public int Move_energy_res;          // energia que vai recuperar movendo

    [Header("    Timing Energy Restoration")]
    public float Idle_TimeEnergyRes;            // tempo energia que vai recuperar parado
    [SerializeField]private float Idle_T_E_R;
    public float Move_TimeEnergyRes;            // tempo energia que vai recuperar movendo
    [SerializeField]private float Move_T_E_R;

    [Header("    Update-Stats")]
    public float life;                    // vida do jogador    
    public int energy;                    // energia que o player vai usar
    [SerializeField] private ReloadScene reloadScene;
    
    [Header("    UI")]
    public Image UI_energy;               // Sprite da energia  
    public Image UI_life;                 // Sprite da vida

    public bool ismove;

    [Header("Sounds")]
    public AudioSource SFX_Death;

    [SerializeField]
    private AudioClip damageSound;

    // Start is called before the first frame update
    void Start()
    {
        if (instance==null)
        {
            instance = this;
        }

        life = maxlife;
        energy = maxenergy;

        Idle_T_E_R = Idle_TimeEnergyRes;
        Move_T_E_R = Move_TimeEnergyRes;

    }

    // Update is called once per frame
    void Update()
    {
        UI_Image(UI_energy, energy, maxenergy);  //atualiza a barra de energia
        UI_Image(UI_life, life, maxlife);        //atualiza a barra de vida

        TimingEnergy();
        EnergyController();
        Isalive();
    }

    // verifica se esta vivo ou não
    private void Isalive()
    {
        if (life <= 0)
        {
            SFX_Death.Play();
            reloadScene.Reloadscene();
        }
    }
    // sistema de energia
    private void EnergyController()
    {
        if (energy <= 0 || energy != maxenergy || !AttackController.IsAttaking)
        {
           
            if(Idle_T_E_R <= 0)
            {             
                energy += Idle_energy_res;

                Idle_T_E_R = Idle_TimeEnergyRes;
            }
            else if (Move_T_E_R <= 0)
            {
                energy += Move_energy_res;

                Move_T_E_R = Move_TimeEnergyRes;
            }
            else if (energy >= maxenergy)
            {
                energy = maxenergy;
            }
            else if (energy < 0)
            {
                energy = 0;
            }
        }
    }

    private void TimingEnergy()
    {
        // ismove  teste
        if (energy != maxenergy)
        {
            if (!ismove)
            {
                Idle_T_E_R -= Time.deltaTime;
                Move_T_E_R = Move_TimeEnergyRes;
            }
            else
            {
                Move_T_E_R -= Time.deltaTime;
                Idle_T_E_R = Idle_TimeEnergyRes;
            }
        }
        else
        {

            Idle_T_E_R = Idle_TimeEnergyRes;
            Move_T_E_R = Move_TimeEnergyRes;
        }
    }


    public void RemoveEnergy(int lost_energy)
    {
        //remove a energia baseada na variavel lost_energy

        energy -= lost_energy; 
    }
    public void RemoveLife(float dmg)
    {
        //remove a vida baseada na variavel dmg
        AudioSource.PlayClipAtPoint(damageSound, this.transform.position);
        life -= dmg;
    }
    private void UI_Image(Image image,float min,float max)
    {
        image.fillAmount = min / max;
    }
}
