using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class QuizTest {

    [Test]
    public void QuizTestSetPreguntasToQuizManager() {
        // Use the Assert class to test conditions.
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        QuizManager quizManager = GameObject.Find("QuizManager").GetComponent<QuizManager>();

        gameManager.setScene("QuizScene");
        gameManager.conectarServidorBD();
		gameManager.getPreguntasFromBD();
        
        Assert.That(quizManager.getPreguntas() != null);
    }

    [Test]
    public void QuizTestGetPreguntas() {
        // Use the Assert class to test conditions.
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        gameManager.conectarServidorBD();
		gameManager.getPreguntasFromBD();
        
        Assert.That(gameManager.getPreguntas() != null);
    }

    [Test]
    public void QuizTestConexionBD() {
        // Use the Assert class to test conditions.
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Assert.That(gameManager.conectarServidorBD);
    }

    [Test]
    public void QuizTestSimplePasses() {
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator QuizTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
