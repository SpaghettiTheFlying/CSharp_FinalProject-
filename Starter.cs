namespace CSharp_FinalProject
{
    internal class Starter
    {
        static void Main(string[] args)
        {
            Game gameInstance = new Game();
            gameInstance.GameStart(gameInstance);
        }
    }
}
