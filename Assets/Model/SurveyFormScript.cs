using System;
using Feedback.Model;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SurveyFormScript : MonoBehaviour
{
	// field declaration



	private ToggleGroup _deeplyconcentrated;
	private ToggleGroup _lostconnection;
	private Dropdown _wasgood;
	private Dropdown _annoyed;
	private Slider _frustrated;
	private Slider _puteffort;


	void Start()
	{
		// get references from scene



		this._deeplyconcentrated = GameObject.Find("DeeplyConcentrated").transform.Find("Answer").GetComponent<ToggleGroup>();
		this._lostconnection = GameObject.Find("LostConnection").transform.Find("Answer").GetComponent<ToggleGroup>();
		this._wasgood = GameObject.Find("WasGood").transform.Find("Answer").GetComponent<Dropdown>();
		this._annoyed = GameObject.Find("Annoyed").transform.Find("Answer").GetComponent<Dropdown>();
		this._frustrated = GameObject.Find("Frustrated").transform.Find("Answer").GetComponent<Slider>();
		this._puteffort = GameObject.Find("PutEffort").transform.Find("Answer").GetComponent<Slider>();


		// Setup submit button
		GameObject.Find("SubmitButton").GetComponent<Button>().onClick.AddListener(this.Submit);
	}

	 public void Submit()
    {
		try
		{
			using (var context = new Feedback.Model.aml_projectContext())
			{
				var entity = new Feedback.Model.SurveyForm()
				{
					#warning Assign values to commented properties:
//					Id = null,
					PlayerGuid = GameObject.Find("PlayerGuid").GetComponent<PlayerGuidScript>().playerGuid,
					AddTime = DateTime.Now,
					DeeplyConcentrated = this.getIntFromDescription(this._deeplyconcentrated.ActiveToggles().FirstOrDefault()?.GetComponentInChildren<Text>().text),
					LostConnection = this.getIntFromDescription(this._lostconnection.ActiveToggles().FirstOrDefault()?.GetComponentInChildren<Text>().text),
					WasGood = this.getIntFromDescription(this._wasgood.options[this._wasgood.value].text),
					Annoyed = this.getIntFromDescription(this._annoyed.options[this._annoyed.value].text),
					Frustrated = (int)this._frustrated.value,
					PutEffort = (int)this._puteffort.value,

				};
			context.SurveyForm.Add(entity);
			context.SaveChanges();
			}
		}
		catch (Exception e)
		{
			Debug.Log(e);
		}
		finally
		{
			// SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
			Application.Quit();
		}
	}

	private int getIntFromDescription(string description)
	 {
		 if (description == "not at all")
		 {
			 return 0;
		 }

		 if (description == "slightly")
		 {
			 return 1;
		 }

		 if (description == "moderately")
		 {
			 return 2;
		 }

		 if (description == "fairly")
		 {
			 return 3;
		 }

		 return 4;
	 }
}