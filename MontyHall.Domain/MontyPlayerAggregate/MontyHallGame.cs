namespace MontyHall.Domain.MontyPlayerAggregate
{
    public class MontyHallGame
    {
        public PlayerStrategy Strategy { get; private set; }
        public int ChosenDoor { get; private set; }
        public Doors Doors { get; private set; }

        public MontyHallGame(int chosenDoor, PlayerStrategy strategy)
        {
            Doors = new Doors();
            Strategy = strategy;
            ChosenDoor = chosenDoor;
        }

        // code that simulates the game
        public bool PlayGame()
        {
            return Strategy.Equals(PlayerStrategy.SwitchDoor)
                ? Doors.SelectDoor(ChosenDoor).Equals(Door.Goat)
                : Doors.SelectDoor(ChosenDoor).Equals(Door.Car);
        }
    }
}