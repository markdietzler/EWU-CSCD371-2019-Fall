namespace Mailbox
{
    public class Mailboxes
    {
        public Mailbox[,] mMailBoxesArray { get; }

        public Mailboxes(Mailbox[,] newMailBoxesArray)
        {
            this.mMailBoxesArray = newMailBoxesArray;
        }

        public (int, int) FindValidLocation(Person owner)
        {
            for (int i = 0; i < mMailBoxesArray.GetLength(0); i++)
            {
                for (int j = 0; j < mMailBoxesArray.GetLength(1); j++)
                {
                    if (CanOwnBox(owner, i, j))
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1); // No available box
        }

        private bool CanOwnBox(Person mailboxOwner, int x, int y)
        {
            if (mMailBoxesArray[x, y] != null)
            {
                return false;
            }
            //Checking right
            if (x + 1 < mMailBoxesArray.GetLength(0) && mMailBoxesArray[x + 1, y] != null && mMailBoxesArray[x + 1, y].mOwner.Equals(mailboxOwner))
            {
                return false;
            }
            //Checking left
            if (x - 1 >= 0 && mMailBoxesArray[x - 1, y] != null && mMailBoxesArray[x - 1, y].mOwner.Equals(mailboxOwner))
            {
                return false;
            }
            //Checking up
            if (y - 1 >= 0 && mMailBoxesArray[x, y - 1] != null && mMailBoxesArray[x, y - 1].mOwner.Equals(mailboxOwner))
            {
                return false;
            }
            //Checking down
            if (y + 1 < mMailBoxesArray.GetLength(1) && mMailBoxesArray[x, y + 1] != null && mMailBoxesArray[x, y + 1].mOwner.Equals(mailboxOwner))
            {
                return false;
            }
            return true;
        }

    }
}
