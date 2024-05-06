using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using UnityEngine;

public static class QuestionsLoader
{
	public static List<Question> FromJSON(string jsonText)
	{
		try
		{
			var questions = new List<Question>();
			var data = JsonStringToObject<QuestionData[]>(jsonText);
			for (int i = 0; i < data.Length; i++)
			{
				int index = data[i].background.IndexOf(".jpg");
				string cleanPath = (index < 0) ? data[i].background : data[i].background.Remove(index, ".jpg".Length);
				var backgroundTexture = Resources.Load<Texture2D>(cleanPath);
				var background = Sprite.Create(backgroundTexture, new Rect(0, 0, backgroundTexture.width, backgroundTexture.height), new Vector2(0, 0), 100);
				questions.Add(new Question(data[i].question, background, data[i].answers));
			}
			return questions;
		}
		finally
		{
		}
	}

	private static T JsonStringToObject<T>(string jsonString)
	{
		try
		{
			using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
			{
				var dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
				return (T)dataContractJsonSerializer.ReadObject(memoryStream);
			}
		}
		finally
        {
        }
	}
}