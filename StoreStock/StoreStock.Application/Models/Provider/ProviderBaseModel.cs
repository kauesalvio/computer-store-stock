namespace StoreStock.Application.Models.Provider
{
    public abstract class ProviderBaseModel
    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Cnpj { get; private set; }
        public string SocialContract { get; private set; }
    }
}
