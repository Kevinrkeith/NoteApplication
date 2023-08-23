using System;
namespace HelloNoteApp.Commands
{
	public class UpdateNoteCommand : ICommand
	{
		private readonly AppDbContext appDbContext;
		public UpdateNoteCommand(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}
		public void Execute()
		{

			Console.WriteLine("Which note would you like to update?");
			var title = Console.ReadLine();

			var note = appDbContext.Notes.FirstOrDefault(n => n.Title == title);

			if (note != null)
			{
				Console.WriteLine("Please enter the new content for your note: ");
				var newContent = Console.ReadLine();

				note.Content = newContent;
				appDbContext.SaveChanges();

				Console.WriteLine("Your note was updated successfully");
			}
			else
			{
				Console.WriteLine("No note of that title was found");
			}

		}
	}
}

