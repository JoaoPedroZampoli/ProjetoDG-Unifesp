using UnityEngine;

public class DomClaudioController : MonoBehaviour
{
    public int vidas;
    public int vidaMax;

    public GameObject DomClaudioFogo;
    public Transform DomClaudioLocalDisparo;
    public float tempoMaxEntreDisparos;
    public float tempoAtualDisparos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
        AtirarFogo();
        DeadState();
    }

    void HealthLogic()
    {
        if(vidas>vidaMax)
        {
            vidas = vidaMax;
        }
    }

    void DeadState()
    {
        if(vidas <= 0)
        {
            GetComponent<DomClaudioController>().enabled = false;
            Destroy(gameObject, 1.0f);
        }
    }

    private void AtirarFogo()
    {
        tempoAtualDisparos -= Time.deltaTime;
        if(tempoAtualDisparos <= 0)
        {
            Instantiate(DomClaudioFogo, DomClaudioLocalDisparo.position, Quaternion.Euler(0f, 0f, -90f));
            tempoAtualDisparos = tempoMaxEntreDisparos;
        }
    }
}
