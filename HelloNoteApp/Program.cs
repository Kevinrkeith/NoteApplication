using HelloNoteApp;
using HelloNoteApp.Commands;

using var dbContext = new AppDbContext();

var commands = new Dictionary<string, ICommand>
{
    {"List", new ListNotesCommand(dbContext) },
    {"Create", new CreateNoteCommand(dbContext) },
    {"Read", new ReadNoteCommand(dbContext) },
    {"Update", new UpdateNoteCommand(dbContext) },
    {"Delete", new DeleteNoteCommand(dbContext) },
    {"Search", new SearchNoteCommand(dbContext) }
};

while (true)
{
    Console.Clear();

    Console.WriteLine("Welcome to the HelloNote App");

    Console.WriteLine("What would you like to do? Enter a Command: ");
    var commandName = Console.ReadLine();

    if (commandName == "quit")
    {
        break;
    }

    if (commands.TryGetValue(commandName, out var command))
    {
        command.Execute();
        Console.WriteLine("Press any Key to continue");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine($"Unknown Command: {commandName}");
        Console.ReadLine();
    }

}