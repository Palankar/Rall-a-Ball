using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObj;
    public GameObject nextStageText;
    public GameObject nextStageText2;
    public GameObject nextStageText3;
    public GameObject deathTextObj;
    public int finScore;
    public Boolean isDead = false;
    public GameObject restartButton;
    public GameObject quitButton;
    public float fallSpeed;
    public SceneEntity sceneEntity;
    public Boolean rotateCamera;

    private Rigidbody rb;
    private Vector3 rawMovement;
    public float cameraMovementX;
    private int collectCount;
    private Boolean isEnd;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collectCount = 0;
        SetCountText();
    }
    
    void OnLook(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        cameraMovementX = movementVector.x;
    }
    

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        rawMovement = new Vector3(movementVector.x, 0, movementVector.y);
    }

    void SetCountText()
    {
        countText.text = "Count: " + collectCount + "/" + finScore + "\nStage: " + sceneEntity.Stage;
    }
    
    void FixedUpdate()
    {
        if (!isEnd)
        {
            rb.AddForce((forX(rawMovement) + forY(rawMovement)) * speed);
        }
    }

    private Vector3 forX(Vector3 vector)
    {
        if (vector.x > 0)
            return new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z);
        if (vector.x < 0)
            return new Vector3(-Camera.main.transform.right.x, 0, -Camera.main.transform.right.z);
        else
            return new Vector3(0, 0, 0);
    }

    private Vector3 forY(Vector3 vector)
    {
        if (vector.z > 0)
            return new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        if (vector.z < 0)
            return new Vector3(-Camera.main.transform.forward.x, 0, -Camera.main.transform.forward.z);
        else
            return new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Проверяем, носит ли объект тег собираемого
        if (other.CompareTag("Collectible"))
        {
            //Отключаем GameObject, к коллайдеру с триггером которого коснулись своим коллайдером
            other.gameObject.SetActive(false);
            collectCount++;

            SetCountText();
            CheckCount();
        }

        if (other.CompareTag("DeathZone"))
            Death();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            Death();
    }

    private void CheckCount()
    {
        if (collectCount == 12)
        {
            nextStageText.SetActive(true);
            //Подождать 4 секунды до деактивации, обязательно в StartCoroutine
            StartCoroutine(WaitBeforeDeactivate(4, nextStageText));
            sceneEntity.Stage = 1;
        }

        if (collectCount == 18)
        {
            nextStageText2.SetActive(true);
            //Подождать 4 секунды до деактивации, обязательно в StartCoroutine
            StartCoroutine(WaitBeforeDeactivate(4, nextStageText2));
            sceneEntity.Stage = 2;
        }

        if (collectCount == 28)
        {
            nextStageText3.SetActive(true);
            //Подождать 4 секунды до деактивации, обязательно в StartCoroutine
            StartCoroutine(WaitBeforeDeactivate(4, nextStageText3));
            sceneEntity.Stage = 3;
        }

        if (collectCount == finScore)
        {
            winTextObj.SetActive(true);
            restartButton.SetActive(false);
            quitButton.SetActive(true);
            isEnd = true;
        }
    }

    //Ожидает некоторое время перед деактивацией объекта
    private IEnumerator WaitBeforeDeactivate(int sec, GameObject obj)
    {
        yield return new WaitForSeconds(sec);
        obj.SetActive(false);
    }
    
    void Death()
    {
        isDead = true;
        deathTextObj.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        isEnd = true;
    }

    public void Respawn()
    {
        isDead = false;
        deathTextObj.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(false);
        isEnd = false;
    }
}
