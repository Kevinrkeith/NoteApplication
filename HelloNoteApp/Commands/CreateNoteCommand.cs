using System;
namespace HelloNoteApp.Commands
{
	public class CreateNoteCommand : ICommand
	{
		private readonly AppDbContext appDbContext;

		public CreateNoteCommand(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}
		public void Execute()
		{

			Console.WriteLine("Provide a title for your note");
			var title = Console.ReadLine();
			Console.WriteLine("Add the content for your note:");
			var content = Console.ReadLine();

			var note = new Note()
			{
				Title = title,
				Content = content
			};
			appDbContext.Notes.Add(note);
			appDbContext.SaveChanges();

			Console.WriteLine("Your note was created successfully!");
		}
	}
}

