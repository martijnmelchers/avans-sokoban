namespace Sokoban.Model.PlacableItems
{
    class Wall : PlacableItem
    {
        public override bool Move(MazeAction action)
        {
            return false;
        }

        public override char ToChar()
        {
            throw new System.NotImplementedException();
        }
    }
}
