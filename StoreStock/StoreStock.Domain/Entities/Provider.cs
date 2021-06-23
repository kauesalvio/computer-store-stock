namespace StoreStock.Domain.Entities
{
    public class Provider : BaseEntity
    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Cnpj { get; private set; }
        public string SocialContract { get; private set; }

        public Provider() { }

        public Provider(string name, string cpf, string cnpj, string socialContract)
        {
            Name = name;
            Cpf = cpf;
            Cnpj = cnpj;
            SocialContract = socialContract;
        }
    }
}
