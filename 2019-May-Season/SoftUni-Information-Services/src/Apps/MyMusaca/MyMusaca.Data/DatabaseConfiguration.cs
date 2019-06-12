namespace MyMusaca.Data
{
    public class DatabaseConfiguration
    {
        public const string ConnectionString =
            @"Server=.\SQLEXPRESS;Database=MyMusacaDB;Trusted_Connection=True;Integrated Security=True;";
        //@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyMusaca;Integrated Security=True";
    }
}