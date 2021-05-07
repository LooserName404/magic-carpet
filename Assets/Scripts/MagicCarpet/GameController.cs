using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagicCarpet
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text highscoreText;

        private int _score;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            int highscore = PlayerPrefs.GetInt("Highscore");
            highscoreText.SetText($"HI: {highscore:000000}");
        }

        private void Update()
        {
            if (Player.Instance)
            {
                _score = (int) Math.Round(Player.Instance.transform.position.z / 3);
                scoreText.SetText(_score.ToString().PadLeft(6, '0'));
            }
        }

        public static void GameOver()
        {
            int highscore = PlayerPrefs.GetInt("Highscore");
            if (Instance._score > highscore)
            {
                PlayerPrefs.SetInt("Highscore", Instance._score);
            }
            Instance.StartCoroutine(Instance.Restart());
        }

        private IEnumerator Restart()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
