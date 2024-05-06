public class GameModel : BaseModel
{
	public Question Question { get; private set; }

	public GameModel(Question question)
	{
		Question = question;
	}
}