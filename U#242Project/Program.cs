using U_242Project;

class HelloWorld
{    
    static void Main()
    {
        var board = new Board();

        board.Display();

        try
        {
            board.PlaceSymbol(1, 1, 'x');
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.Clear();

        board.Display();
    }
}