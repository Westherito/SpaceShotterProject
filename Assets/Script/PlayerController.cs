
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : PlayerFatherController
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        TirosPlayer();
    }
    // Criando os tiros do player
    private void TirosPlayer()
    {

        if (Input.GetButton("Fire1"))
        {
            timerBullet -= Time.deltaTime;
            switch (levelTiro)
            {
                case 1:
                    if (timerBullet < 0f)
                    {
                        CriaTiro(tiros, transform.position);
                        timerBullet = 0.15f;
                    }
                    break;

                case 2:
                    if (timerBullet < 0f)
                    {
                        // Tiro esquerdo
                        Vector3 posTiro = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiro);
                        // Tiro direito
                        posTiro = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiro);
                        timerBullet = 0.12f;
                    }
                    break;
                case 3:
                    if (timerBullet < 0f)
                    {
                        CriaTiro(tiros2, transform.position);
                        // Tiro esquerdo
                        Vector3 posTiroE = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiroE);
                        // Tiro direito
                        Vector3 posTiroD = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiroD);
                        timerBullet = 0.20f;
                    }
                    break;
                case 4:
                    if (timerBullet < 0f)
                    {
                        CriaTiro(tiros, transform.position);
                        // Tiro esquerdo
                        Vector3 posTiroE = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros, posTiroE);
                        // Tiro direito
                        Vector3 posTiroD = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros, posTiroD);
                        timerBullet = 0.10f;
                    }
                    break;
                case 5:
                    if (timerBullet < 0f)
                    {
                        var enemy = FindAnyObjectByType<EnemyFatherController>();
                        // Tiro esquerdo
                        Vector3 posTiroE = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros, posTiroE);
                        posTiroE = new Vector3(transform.position.x - 0.6f, transform.position.y - 0.2f, 0f);
                        CriaTiro(tiros2, posTiroE);
                        // Tiro direito
                        Vector3 posTiroD = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros, posTiroD);
                        posTiroD = new Vector3(transform.position.x + 0.6f, transform.position.y - 0.2f, 0f);
                        CriaTiro(tiros2, posTiroD);
                        timerBullet = 0.10f;
                    }
                    break;
            }
        }
    }
    // Criando os tiros com base no tipo de tiro recebido
    private void CriaTiro(GameObject playerTiro, Vector3 pos)
    {
        GameObject Tiro;
        Tiro = Instantiate(playerTiro, pos, transform.rotation);
        Tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velTiro);
        SoundFX[0].Play();
    }
    // Destruindo player caso ele perda todas as vidas e reiniciando o jogo

}
