
using UnityEngine;
using UnityEngine.UI;
// Controle do Player
public class PlayerFatherController : MonoBehaviour
{
    [SerializeField] protected AudioSource[] SoundFX;
    // Movimentação
    [SerializeField] protected Rigidbody2D rbPlayer;
    protected Vector2 movPlayer;
    [SerializeField] protected float vel;
    // Tiros do Player
    [SerializeField] protected float timerBullet = 0.1f;
    [SerializeField] protected GameObject tiros;
    [SerializeField] protected GameObject tiros2;
    protected float velTiro = 10f;
    [SerializeField] protected int levelTiro = 1;
    // Escudo do player
    [SerializeField] protected GameObject escudo;
    protected GameObject escudoAtual;
    protected float timerEscudo = 0f;
    [SerializeField] protected int qteEscudo = 3;
    // Vida do player
    protected int lifePlayer;
    [SerializeField] protected GameObject Morte;
    // Limite de tela
    [SerializeField] protected float xMin, yMin, xMax, yMax;
    // Mostrando as informações do player
    [SerializeField] protected Text EscudoDisplay;
    [SerializeField] protected Image vidaDisplay;
    [SerializeField] protected int lifeMax;
    // Dash
    protected bool dashBool = false;
    [SerializeField] protected ParticleSystem arrasto;
    // Destruindo player caso ele perda todas as vidas e reiniciando o jogo
    public void PlayerLife(int dano)
    {
        lifePlayer -= dano;
        vidaDisplay.fillAmount = lifePlayer;
        if (lifePlayer <= 0)
        {
            Destroy(gameObject);
            Destroy(escudoAtual);
            Instantiate(Morte, transform.position, transform.rotation);
        }
    }
    // Colisão com os tipos de PowerUp
    protected void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("PowerUp"))//Recompensa PowerUp
        {
            var pontos = FindAnyObjectByType<GeradorInimigos>();
            pontos.GanhaPontos(50);
            levelTiro++;
            Destroy(collision.gameObject);
            SoundFX[3].Play();
            if (levelTiro >= 5)
            {
                levelTiro = 5;
            }   
        }
        if (collision.CompareTag("Life"))//Recompensa Vida
        {
            var pontos = FindAnyObjectByType<GeradorInimigos>();
            pontos.GanhaPontos(30);
            lifePlayer += 2;
            Destroy(collision.gameObject);
            SoundFX[3].Play();
            
        }
        if (collision.CompareTag("Escudo"))//Recompensa Escudo
        {
            var pontos = FindAnyObjectByType<GeradorInimigos>();
            pontos.GanhaPontos(50);
            Destroy(collision.gameObject);
            SoundFX[3].Play();
            if (qteEscudo == 0)
            {
                qteEscudo = 3;
            } 
        }
        if (collision.CompareTag("Special"))//Recompensa Special
        {
            var pontos = FindAnyObjectByType<GeradorInimigos>();
            pontos.GanhaPontos(5000); 
            Destroy(collision.gameObject);
            levelTiro = 5;
            lifePlayer = 10;
            qteEscudo = 3;
            SoundFX[3].Play();
            
        }
    }
}

// Direção para o dash
public enum Direcao { 
    Direita,
    Esquerda,
}