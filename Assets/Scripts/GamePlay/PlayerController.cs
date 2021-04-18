using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class PlayerController : MonoBehaviour
{
    private Direction direction;   // Current direct of the player.

    private Rigidbody mainBody;    // Parent rigidbody
    private Rigidbody headBody;    // Player head rigidbody

    private List<Vector3> deltaPos;
    private List<Rigidbody> nodes;   // list of nodes of the snake

    private bool isMove = false;
    private bool isGameOver = false;
    private float timer;

    private bool isFoodGrabbed;

    private float stepLength = 0.5f;

    [SerializeField] private GameObject tailPrefab;

    private Food food;

    void Awake()
    {
        mainBody = GetComponent<Rigidbody>();
        InitiateNodes();
        InitiatePlayer();
        

        deltaPos = new List<Vector3>
        {
            new Vector3(-stepLength,0f),  // -x Left
            new Vector3(stepLength , 0f), // x - Right
            new Vector3(0f,stepLength),   // y Up
            new Vector3(0f,-stepLength),  // -y Down
        };
    }

    void InitiateNodes()
    {
        nodes = new List<Rigidbody>();

        nodes.Add(transform.GetChild(0).GetComponent<Rigidbody>());
        nodes.Add(transform.GetChild(1).GetComponent<Rigidbody>());

        headBody = nodes[0];
    }

    void InitiatePlayer()
    {
        // Calculating default direction.
        //int randomDirection = Random.Range(0, (int)Direction.COUNT);
        //direction = (Direction)randomDirection;

        direction = Direction.RIGHT;

        switch (direction)
        {
            case Direction.RIGHT:
                nodes[1].position = nodes[0].position + new Vector3(0.5f, 0, 0);
                break;
            case Direction.LEFT:
                nodes[1].position = nodes[0].position - new Vector3(-0.5f, 0, 0);
                break;
            case Direction.UP:
                nodes[1].position = nodes[0].position + new Vector3(0, 0.5f, 0);
                break;
            case Direction.DOWN:
                nodes[1].position = nodes[0].position - new Vector3(0, -0.5f, 0);

                break;

        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0.1f)
        {
            timer = 0;
            isMove = true;
        }
    }

    private void FixedUpdate()
    {
        if(isMove && !isGameOver)
        {
            isMove = false;
            Move();
        }
    }

    private void Move()
    {
        Vector3 tempPosition = deltaPos[(int)direction];
        Vector3 parentPosition = headBody.position;

        Vector3 prevPos;

        mainBody.position = mainBody.position + tempPosition;
        headBody.position = headBody.position + tempPosition;

        for (int i = 1; i < nodes.Count; i++)
        {
            prevPos = nodes[i].position;
            nodes[i].position = parentPosition;
            parentPosition = prevPos;
        }

        if(isFoodGrabbed)
        {
            isFoodGrabbed = false;
            // New node will created at the tail once ate foods.
            GameObject tailObject = Instantiate(tailPrefab, nodes[nodes.Count - 1].position , Quaternion.identity);
            tailObject.transform.SetParent(transform, true);
            nodes.Add(tailObject.GetComponent<Rigidbody>());
        }
    }

    public void SetDirection(Direction _direction)
    {
        if (isGameOver)
            return;
        if(_direction == Direction.UP && direction == Direction.DOWN ||
            _direction == Direction.DOWN && direction == Direction.UP ||
            _direction == Direction.LEFT && direction == Direction.RIGHT ||
            _direction == Direction.RIGHT && direction == Direction.LEFT )
        {
            return;
        }
        Debug.Log("Direction :: "+ _direction);


        direction = _direction;
        isMove = false;
        timer = 0;
        Move();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COllider Tag :: "+other.tag);
        if(other.tag == Tags.WALL)
        {
            // Game Over
            isMove = false;
            isGameOver = true;

            GamePlayManager.onGameOverUpdate.Invoke();
        }
        else if(other.tag == Tags.FOOD)
        {
            // Update Score
            GamePlayManager.instance.UpdateScore();
            Destroy(other.gameObject);
            isFoodGrabbed = true;
            GamePlayManager.instance.GenerateRandomFood();
        }
    }

   

}
