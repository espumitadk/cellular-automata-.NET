namespace CellularAutomata {

    public class Neighborhood {

        private readonly Cell leftCell;
        private readonly Cell centerCell;
        private readonly Cell rightCell;

        public Neighborhood(Cell leftCell, Cell centerCell, Cell rightCell) {
            this.leftCell = leftCell;
            this.centerCell = centerCell;
            this.rightCell = rightCell;
        }

        protected bool Equals(Neighborhood other) {
            return leftCell == other.leftCell && centerCell == other.centerCell && rightCell == other.rightCell;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Neighborhood) obj);
        }

        public override int GetHashCode() {
            unchecked
            {
                var hashCode = (int) leftCell;
                hashCode = (hashCode*397) ^ (int) centerCell;
                hashCode = (hashCode*397) ^ (int) rightCell;
                return hashCode;
            }
        }

    }

}