using System;
namespace TimerApp.WebForms.Models
{
	public class TimerItem
	{
		public Guid Id { get; set; }
		public string TimerName { get; set; }
		public DateTime Date { get; set; }
	}
}

