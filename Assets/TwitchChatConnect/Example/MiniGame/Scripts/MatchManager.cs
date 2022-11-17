using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TwitchChatConnect.Example.MiniGame
{
    public class MatchManager : MonoBehaviour
    {
        //[SerializeField] private int size;
        [SerializeField] private GameObject floorPrefab;
        [SerializeField] private GameObject playerPrefab;
        //[SerializeField] private GameObject goalPrefab;

        private static float MIN_DISTANCE_TO_REACH_GOAL = 1f;

        //private float secondsElapsed;
        private GameObject player;
        //private GameObject goal;
        private GameObject floor;

        public GameObject spawnStage;
        public GameObject spawnPlayer;

        //[SerializeField] private Transform laserHolder;
        [SerializeField] private Rigidbody bullet;
        private float launchForce = 700f;
        
        public delegate void OnMatchBegin();
        public OnMatchBegin onMatchBegin;
        
        public delegate void OnMatchEnd(float seconds);
        public OnMatchEnd onMatchEnd;

        public bool HasStarted { get; private set; }

        #region Singleton
        public static MatchManager instance { get; private set; }
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion
        
        private void Start()
        {
            HasStarted = false;
        }

        private void Update()
        {
            //if (!HasStarted) return;
            //secondsElapsed += Time.deltaTime;
        }

        public void Begin()
        {
            if (HasStarted) return;
            Spawn();
            HasStarted = true;
            //secondsElapsed = 0;
            onMatchBegin?.Invoke();
        }

        //public void End()
        //{
        //    if (!HasStarted) return;
        //    Destroy(player);
        //    Destroy(goal);
        //    Destroy(floor);
        //    HasStarted = false;
        //    onMatchEnd?.Invoke(secondsElapsed);
        //}

        public void Fire(int fireRepeat){
            for (int i = 0; i < fireRepeat; i++){
                GameObject originalGameObject = GameObject.FindWithTag("Cannon");
                Transform child = originalGameObject.transform.GetChild(0);

                var projectileInstance = Instantiate(bullet, child.position, child.rotation);
                var rigidbody = projectileInstance.GetComponent<Rigidbody>();
                projectileInstance.AddForce(child.forward * launchForce);
            }
        }

        public void Move(float direction, int moveRepeat)
        {
            
            //player.transform.position = player.transform.position + direction;
            //if (Vector3.Distance(player.transform.position, goal.transform.position) < MIN_DISTANCE_TO_REACH_GOAL)
            //{
            //    End();
            //}
            for(int i = 0; i < moveRepeat; i++){
                float angleX = direction * Time.deltaTime * 50f;
                player.transform.Rotate(0, 0, angleX, Space.Self);
            }
        }

        private void Spawn()
        {
            floor = Instantiate(floorPrefab, spawnStage.transform.position, Quaternion.identity);
            //floor.transform.localScale = new Vector3(size * 2, 1, size * 2);

            //float y = transform.position.y + 1;
            //float xRandom = transform.position.x + Random.Range(-size, size);
            //float zRandom = transform.position.z + Random.Range(-size, size);
            
            Quaternion rotation = Quaternion.Euler(270f, 90f, 0f);
            player = Instantiate(playerPrefab, spawnPlayer.transform.position, rotation);
            
            //xRandom = transform.position.x + Random.Range(-size, size);
            //zRandom = transform.position.z + Random.Range(-size, size);
            //goal = Instantiate(goalPrefab, new Vector3(xRandom, y, zRandom), Quaternion.identity);
        }
        
    }
}