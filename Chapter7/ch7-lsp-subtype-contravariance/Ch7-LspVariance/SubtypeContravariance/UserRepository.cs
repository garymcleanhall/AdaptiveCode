namespace SubtypeContravariance
{
    public class UserRepository : EntityRepository
    {
        // This will not compile because subtypes cannot exhibit contravariance
        //public override void Save(object user)
        //{

        //}
    }
}
