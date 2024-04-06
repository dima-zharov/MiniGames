using NUnit.Framework;


public class ScoreTest
{
    GameController gameController = new GameController();
    int score;

    [Test]
    public void TestScoreOnStartAndRestart()
    {
        score = gameController.currentScore;
        Assert.AreEqual(0, score);
    }



}
