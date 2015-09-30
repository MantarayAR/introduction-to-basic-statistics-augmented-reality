using System;

/**
 * Question Model
 * 
 * @author Ivan Montiel
 */
public class Question
{
	private string text;
	private string[] answers;
	private string hint;
	private string description;
	private string rightAnswer;
	
	/**
	 * General Constructor
	 */
	public Question ()
	{
		this.text = "";
		this.answers = new string[1];
		this.hint = "";
		this.description = "";
		this.rightAnswer = "";
	}
	
	/**
	 * Set the text of the question
	 */
	public void SetText(string text)
	{
		this.text = text;
	}
	
	/**
	 * Get the text of the question
	 */
	public String GetText()
	{
		return this.text;
	}
	
	/**
	 * Set the answers of the question.  More then 1.  Less than 5.
	 */
	public void SetAnswers(params string[] answers)
	{
		// TODO shuffle
		this.answers = answers;
	}
	
	/**
	 * Get the answers for the question.  They are shuffled randomly.
	 */
	public string[] GetAnswers()
	{
		return this.answers;
	}
	
	/**
	 * Set the hint for the question
	 */
	public void SetHint(string hint)
	{
		this.hint = hint;
	}
	
	/**
	 * Get the hint for the question
	 */
	public string GetHint()
	{
		return this.hint;
	}
	
	/**
	 * Set the description of the right answer
	 */
	public void SetDescriptionOfRightAnswer(string description)
	{
		this.description = description;
	}
	
	/**
	 * Get the description of the right answer
	 */
	public string GetDescriptionOfRightAnswer()
	{
		return this.description;
	}
	
	/**
	 * Set the right answer
	 */
	public void SetRightAnswer(string answer) 
	{
		this.rightAnswer = answer;
	}
	
	/**
	 * Get the right answer
	 */
	public string GetRightAnswer()
	{
		return this.rightAnswer;
	}
}

