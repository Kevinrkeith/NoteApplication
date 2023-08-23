using System;
using Microsoft.EntityFrameworkCore;

namespace HelloNoteApp.Commands
{
	public class DeleteNoteCommand : ICommand
	{
        private readonly AppDbContext appDbContext;
        public DeleteNoteCommand(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void Execute()
        {
            Console.WriteLine("Provide the title of the Note that is being deleted");
            var title = Console.ReadLine();
            var note = appDbContext.Notes.FirstOrDefault(n => n.Title == title);

            if (note != null)
            {
                appDbContext.Notes.Remove(note);
                appDbContext.SaveChanges();
                Console.WriteLine("Note was deleted successfully");
            }
            else
            {
                Console.WriteLine("Note was not found");
            }
        }
    }
}

