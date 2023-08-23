using System;
namespace HelloNoteApp.Commands
{
	public class SearchNoteCommand : ICommand
	{
		private readonly AppDbContext appDbContext;
		public SearchNoteCommand(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}
		public void Execute()
		{

			Console.WriteLine("Please provide a keyword to search for");
			var keyword = Console.ReadLine();

			var notesQuery = appDbContext.Notes.Where(n => n.Title.Contains(keyword) || n.Content.Contains(keyword));

			var notes = notesQuery.ToList();

			if (notes.Any())
			{
				foreach (var note in notes)
				{
					Console.WriteLine($"Title: {note.Title}");
					Console.WriteLine($"Content: {note.Content}");
					Console.WriteLine("--------------------------");
				}
			}
			else
			{
				Console.WriteLine("No Notes found with the provided keyword");
			}
		}
	}
}

