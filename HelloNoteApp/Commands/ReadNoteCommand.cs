using System;
namespace HelloNoteApp.Commands
{
	public class ReadNoteCommand : ICommand
	{
		private readonly AppDbContext _dbContext;
		public ReadNoteCommand(AppDbContext appDbContext)
		{
			_dbContext = appDbContext;
		}
		public void Execute()
		{
            var notes = _dbContext.Notes.ToList();
			Console.WriteLine("Which note would you like to read?");

			var title = Console.ReadLine();
			var note = _dbContext.Notes.FirstOrDefault(n => n.Title == title);

			if (note != null)
			{
				Console.WriteLine($"Title: {note.Title}");
				Console.WriteLine($"Content: {note.Content}");
			}
			else
			{
				Console.WriteLine("No note was found.");
			}
        }
	}
}

