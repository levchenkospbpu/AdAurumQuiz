public class CheckAnswerPopupModel : BaseModel
{
	public readonly bool IsCorrect;
	public string CorrectText { get; private set; }
	public string IncorrectText { get; private set; }

	public CheckAnswerPopupModel(bool isCorrect)
	{
		IsCorrect = isCorrect;
		CorrectText = "Верно";
		IncorrectText = "Неверно";
	}
}