using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class TestSuite
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestSuiteSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        [UnityTest]
        [Timeout(60000)]
        public IEnumerator TestGetting100Points()
        {
            SceneManager.LoadScene("Scenes/MainScene", LoadSceneMode.Single);

            var easyButton = (GameObject) null;
            yield return new WaitUntil(() => (easyButton = GameObject.Find("Easy Button")) != null );
            easyButton.GetComponent<Button>().onClick.Invoke();

            GameManager gameManager = GameObject.Find("Game Manager").gameObject.GetComponent<GameManager>();

            while (gameManager.score < 100)
            {
                yield return new WaitUntil(() => (GameObject.FindGameObjectsWithTag("Good")).Length > 0);

                foreach (var crate in GameObject.FindGameObjectsWithTag("Good"))
                {
                    crate.GetComponent<Target>().OnMouseDown();
                }
            }
        }
    }
}
