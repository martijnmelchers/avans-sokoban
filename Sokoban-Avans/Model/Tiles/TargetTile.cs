using System;

namespace Sokoban
{
    class TargetTile : FloorTile
    {
        public override PlacableItem Content { get; set; }

        public override char ToChar()
        {
            if (!this.IsEmpty() && !(this.Content is Crate))
                return this.Content.ToChar();
            return this.Content is Crate ? '0' : 'x';
        }
    }
}
