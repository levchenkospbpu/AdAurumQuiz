public class ResultPopupModel : BaseModel
{
	public readonly int CorrectAnswers;
	public readonly int QuestionsCount;

	public ResultPopupModel(int correctAnswers, int questionsCount)
	{
		CorrectAnswers = correctAnswers;
		QuestionsCount = questionsCount;
	}
}