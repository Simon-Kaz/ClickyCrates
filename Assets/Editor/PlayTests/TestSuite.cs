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
        public IEnumerator TestWinning()
        {

            SceneManager.LoadScene("Scenes/MainScene", LoadSceneMode.Single);

            var easyButton = (GameObject) null;
            yield return new WaitUntil(() => (easyButton = GameObject.Find("Easy Button")) != null );
            easyButton.GetComponent<Button>().onClick.Invoke();

            while (true)
            {
                var crates = (GameObject[]) null;
                yield return new WaitUntil(() => (crates = GameObject.FindGameObjectsWithTag("Good")).Length > 0);

                foreach (var crate in crates)
                {
                    crate.GetComponent<Target>().OnMouseDown();
                }
            }
        }
    }
}
