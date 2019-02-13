namespace Epam.Task7.Users.Entities
{
    public class UsersAwards
    {
        public int IdUser { get; set; }

        public int IdAward { get; set; }

       public override string ToString()
        {
            return $"{IdUser} {IdAward}"; 
        }
    }
}
