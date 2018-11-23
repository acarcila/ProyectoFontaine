using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class IndexTest {

    [Test]
    public void IndexTestWorksWithoutQuizManager() {
        // Use the Assert class to test conditions.
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        gameManager.setScene("QuizScene");
        gameManager.conectarServidorBD();
		gameManager.getPreguntasFromBD();
    }

    [Test]
    public void IndexTestSimplePasses() {
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator IndexTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
